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
	[Activity(Label = "TroubleShootingActivitycs", ScreenOrientation = ScreenOrientation.Portrait)]
	public class TroubleShootingActivitycs : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TroubleShooting);

            // Create your application here
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            img_Back.Click += Img_Back_Click;
        }

        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CheckError));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}