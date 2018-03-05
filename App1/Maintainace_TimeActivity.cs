using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace App1
{
    [Activity(Label = "Maintainace_TimeActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Maintainace_TimeActivity : Activity
    {
        TextView text_content;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Maintenance_Time);

            // Create your application here
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
           
            text_content = FindViewById<TextView>(Resource.Id.text_content);

            //
            img_Back.Click += Img_Back_Click;
        }

        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MaintainaceActivity));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}