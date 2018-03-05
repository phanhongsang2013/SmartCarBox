using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Android.Util;
using Android.Views;

namespace App1
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : Activity, IOnMapReadyCallback
    {
        String strGoogleDirectionUrl = "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&key=" + "AIzaSyCiiH49rDtM58eFyrVtQX1AbLKWNxepssw" + "";
        String strSourceLocation = "Pham Ngoc Thach,Tan An,Hoi An,Quang Nam";
        String strDestinationLocation = "Thanh Hà, Hội An, Quang Nam Province, Vietnam";
        String strException = "Please turn on the Internet";
        String strTextSource = "Your Location";
        String strTextDestination = "The nearest garage";
        String strPleaseWait = "Waiting...";
        String strUnableToConnect = "Unable to connect server!";

        GoogleMap map;
        LocationManager locationManager;
        String provider;
        LatLng latLngSource;
        LatLng latLngDestination;
        WebClient webclient;
        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Map);

            // Create your application here           
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            img_Back.Click += Img_Back_Click;
            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
            locationManager = (LocationManager)GetSystemService(Context.LocationService);
            provider = locationManager.GetBestProvider(new Criteria(), false);

            Location location = locationManager.GetLastKnownLocation(provider);
            if (location == null) 
                System.Diagnostics.Debug.WriteLine("ERROR");
            //
            FnProcessOnMap();
        }
        private void Img_Back_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainPage));
        }
        /*protected override void OnResume()
        {
            base.OnResume();
            locationManager.RequestLocationUpdates(provider, 1, 1, this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        }*/
        async void FnProcessOnMap()
        {
            try
            {
                await FnLocationToLatLng();

                FnUpdateCameraPosition(latLngSource);
            }
            catch (Exception e)
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("No Connection");
                alert.SetMessage("Please turn on the Internet");
                alert.SetButton("OK", (c, ev) =>
                {
                    StartActivity(new Android.Content.Intent(Application.Context, typeof(MainPage)));
                });
                alert.Show();
            }

            if (latLngSource != null && latLngDestination != null)
                FnDrawPath(strSourceLocation, strDestinationLocation);
        }
        async void FnDrawPath(string strSource, string strDestination)
        {
            string strFullDirectionURL = string.Format(strGoogleDirectionUrl, strSource, strDestination);// combine a full direction URL
            string strJSONDirectionResponse = await FnHttpRequest(strFullDirectionURL);
            if (strJSONDirectionResponse != strException)
            {
                RunOnUiThread(() =>
                {
                    if (map != null)
                    {
                        map.Clear();
                        MarkOnMap(strTextSource, latLngSource, Resource.Drawable.MarkerSource);
                        MarkOnMap(strTextDestination, latLngDestination, Resource.Drawable.MarkerDest);
                    }
                });
                FnSetDirectionQuery(strJSONDirectionResponse);
            }
            else
            {
                RunOnUiThread(() =>
                   Toast.MakeText(this, strUnableToConnect, ToastLength.Short).Show());
            }
        }
        void FnSetDirectionQuery(string strJSONDirectionResponse)
        {
            var objRoutes = JsonConvert.DeserializeObject<GoogleDirectionClass>(strJSONDirectionResponse);
            //objRoutes.routes.Count  --may be more then one 
            if (objRoutes.routes.Count > 0)
            {
                string encodedPoints = objRoutes.routes[0].overview_polyline.points;

                var lstDecodedPoints = FnDecodePolylinePoints(encodedPoints);
                //convert list of location point to array of latlng type
                var latLngPoints = new LatLng[lstDecodedPoints.Count];
                int index = 0;
                foreach (Location loc in lstDecodedPoints)
                {
                    latLngPoints[index++] = new LatLng(loc.Latitude, loc.Longitude);
                }

                var polylineoption = new PolylineOptions();
                polylineoption.InvokeColor(Android.Graphics.Color.Red);
                polylineoption.Geodesic(true);
                polylineoption.Add(latLngPoints);
                RunOnUiThread(() =>
                map.AddPolyline(polylineoption));
            }
        }
        async Task<string> FnHttpRequest(string strUri)
        {
            webclient = new WebClient();
            string strResultData;
            try
            {
                strResultData = await webclient.DownloadStringTaskAsync(new Uri(strUri));
                Console.WriteLine(strResultData);
            }
            catch
            {
                strResultData = strException;
            }
            finally
            {
                if (webclient != null)
                {
                    webclient.Dispose();
                    webclient = null;
                }
            }

            return strResultData;
        }
        List<Location> FnDecodePolylinePoints(string encodedPoints)
        {
            if (string.IsNullOrEmpty(encodedPoints))
                return null;
            var poly = new List<Location>();
            char[] polylinechars = encodedPoints.ToCharArray();
            int index = 0;

            int currentLat = 0;
            int currentLng = 0;
            int next5bits;
            int sum;
            int shifter;

            try
            {
                while (index < polylinechars.Length)
                {
                    // calculate next latitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5bits = (int)polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length)
                        break;

                    currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                    //calculate next longitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5bits = (int)polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length && next5bits >= 32)
                        break;

                    currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
                    Location q = new Location("");
               
                    q.Latitude = Convert.ToDouble(currentLat) / 100000.0;
                    q.Longitude = Convert.ToDouble(currentLng) / 100000.0;
                    poly.Add(q);
                }
            }
            catch
            {
                RunOnUiThread(() =>
                  Toast.MakeText(this, strPleaseWait, ToastLength.Short).Show());
            }
            return poly;
        }
        void MarkOnMap(string title, LatLng pos, int resourceId)
        {
            RunOnUiThread(() =>
            {
                try
                {
                    var marker = new MarkerOptions();
                    marker.SetTitle(title);
                    marker.SetPosition(pos); //Resource.Drawable.BlueDot
                    marker.SetIcon(BitmapDescriptorFactory.FromResource(resourceId));                  
                    map.AddMarker(marker);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
        private void FnUpdateCameraPosition(LatLng pos)
        {
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(pos);
            builder.Zoom(10);
            builder.Bearing(45);
            builder.Tilt(10);
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            map.AnimateCamera(cameraUpdate);
        }

        async Task<bool> FnLocationToLatLng()
        {
            try
            {
                var geo = new Geocoder(this);                
                var sourceAddress = await geo.GetFromLocationNameAsync(strSourceLocation, 1);
                sourceAddress.ToList().ForEach((addr) =>
                {
                    latLngSource = new LatLng(addr.Latitude, addr.Longitude);
                });
                var destAddress = await geo.GetFromLocationNameAsync(strDestinationLocation, 1);
                destAddress.ToList().ForEach((addr) =>
                {
                    latLngDestination = new LatLng(addr.Latitude, addr.Longitude);
                });

                return true;
            }
            catch
            {
                return false;
            }
            
        }     
        string FnHttpRequestOnMainThread(string strUri)
        {
            webclient = new WebClient();
            string strResultData;
            try
            {
                strResultData = webclient.DownloadString(new Uri(strUri));
                Console.WriteLine(strResultData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                strResultData = strException;
            }
            finally
            {
                if (webclient != null)
                {
                    webclient.Dispose();
                    webclient = null;
                }
            }

            return strResultData;
        }

        /*public void OnLocationChanged(Location location)
        {
            Double lat, lon;
            lat = location.Latitude;
            lon = location.Longitude;
            MarkerOptions markerOptions = new MarkerOptions();

            markerOptions.SetPosition(new LatLng(lat, lon));
            markerOptions.SetTitle("Your Location");
            map.AddMarker(markerOptions);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(new LatLng(lat, lon));
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            map.MoveCamera(cameraUpdate);
            //LatLng YourLocation = new LatLng(lat, lon);
            //map.MoveCamera(CameraUpdateFactory.NewLatLngZoom(YourLocation, 30));
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {      
        }*/
    }
}