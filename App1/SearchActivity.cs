using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

namespace App1
{
    [Activity(Label = "SearchActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SearchActivity : Activity
    {
        TextView Dot1, Dot2, Dot3;
        Timer timer;
        bool kt1 = true, kt2 = false, kt3 = false;
        int count = 0;
        Button button_ok;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Waiting_Search);
            // Create your application here

            ImageView img_icon = FindViewById<ImageView>(Resource.Id.imageView_Search);
            TextView text_Title = FindViewById<TextView>(Resource.Id.textView_Title);
            button_ok = FindViewById<Button>(Resource.Id.button_ok);
            button_ok.Click += Button_ok_Click;
            Dot1 = FindViewById<TextView>(Resource.Id.Dot1);
            Dot2 = FindViewById<TextView>(Resource.Id.Dot2);
            Dot3 = FindViewById<TextView>(Resource.Id.Dot3);
            timer = new Timer();
            timer.Interval = 120;
            timer.Start();
            timer.Elapsed += Elapsed;

        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CheckError));
        }

        private void Elapsed(object sender, ElapsedEventArgs e)
        {
            RunWaiting();

        }
        private async Task RunWaiting()
        {
            if (count < 20)
            {
                count++;
                RunOnUiThread(() =>
                {

                    if (kt1 == true)
                    {
                        kt1 = false;
                        kt2 = true;
                        Dot1.Visibility = ViewStates.Invisible;
                        Dot2.Visibility = ViewStates.Visible;
                    }
                    else
                    {
                        if (kt2 == true)
                        {
                            kt2 = false;
                            kt3 = true;
                            Dot2.Visibility = ViewStates.Invisible;
                            Dot3.Visibility = ViewStates.Visible;
                        }
                        else
                        {
                            if (kt3 == true)
                            {
                                kt3 = false;
                                kt1 = true;
                                Dot3.Visibility = ViewStates.Invisible;
                                Dot1.Visibility = ViewStates.Visible;
                            }
                        }

                    }
                });
            }
            else
            {
                RunOnUiThread(() =>
                {
                    button_ok.Visibility= ViewStates.Visible;
                });
            }
        }
    }
}