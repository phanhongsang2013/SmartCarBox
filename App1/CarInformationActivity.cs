using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;

namespace App1
{
    [Activity(Label = "CarInformationActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class CarInformationActivity : Activity, IOnMapReadyCallback, ILocationListener
    {
        GoogleMap map;
        LocationManager locationManager;
        String provider;
        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
        }
        public void OnLocationChanged(Location location)
        {
            Double lat, lon;
            lat = location.Latitude;
            lon = location.Longitude;

            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(new LatLng(lat, lon));
            markerOptions.SetTitle("Your Location");
            map.AddMarker(markerOptions);
            //
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(new LatLng(lat, lon));
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            map.MoveCamera(cameraUpdate);
        }
        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CarInformation);

            // Create your application here
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            TextView text_Title = FindViewById<TextView>(Resource.Id.textView_Title);
            img_Back.Click += Img_Back_Click;
            //
            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map1);
            mapFragment.GetMapAsync(this);
            //
            locationManager = (LocationManager)GetSystemService(Context.LocationService);
            provider = locationManager.GetBestProvider(new Criteria(), false);
            Location location = locationManager.GetLastKnownLocation(provider);

        }
        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainPage));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
        protected override void OnResume()
        {
            base.OnResume();
            locationManager.RequestLocationUpdates(provider, 1, 1, this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        }
    }
}