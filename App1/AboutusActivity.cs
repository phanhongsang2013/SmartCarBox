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
    [Activity(Label = "AboutusActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class AboutusActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AboutUs);
            // Create your application here

            ImageView Iconapp = FindViewById<ImageView>(Resource.Id.IconApp);
            Iconapp.SetImageResource(Resource.Id.IconApp);
            ImageView img_nameApp = FindViewById<ImageView>(Resource.Id.imageView_NameApp);
            img_nameApp.SetImageResource(Resource.Drawable.NameApp);
            ImageView img_aboutus = FindViewById<ImageView>(Resource.Id.imageView_Aboutus);
            //img_aboutus.SetImageResource(Resource.Drawable.car);
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            img_Back.Click += Img_Back_Click;
        }
        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Homepage));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
        
    }
}