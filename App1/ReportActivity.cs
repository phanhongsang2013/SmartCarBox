﻿using System;
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
    [Activity(Label = "ReportActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ReportActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Report);

            // Create your application here
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            img_Back.Click += Img_Back_Click;
        }
        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainPage));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}