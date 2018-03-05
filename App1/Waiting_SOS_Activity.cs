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

namespace App1
{
    [Activity(Label = "Waiting_SOS_Activity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Waiting_SOS_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Waiting_SOS);
            // Create your application here
            ImageView img_icon = FindViewById<ImageView>(Resource.Id.imageView_CarProblem);
            TextView text_content = FindViewById<TextView>(Resource.Id.textView_Content);
        }
    }
}