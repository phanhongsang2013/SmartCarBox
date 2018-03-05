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
	[Activity(Label = "DeviceListActivitycs", ScreenOrientation = ScreenOrientation.Portrait)]
	public class DeviceListActivitycs : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DeviceList);

            // Create your application here
            ImageButton IconApp = FindViewById<ImageButton>(Resource.Id.IconApp);
            Button btn_camryMainpage = FindViewById<Button>(Resource.Id.btn_camryMainpage);            
            ImageButton imageButton_plus = FindViewById<ImageButton>(Resource.Id.imageButton_plus);
            ImageButton imageButton_garbage = FindViewById<ImageButton>(Resource.Id.imageButton_garbage);

            //
            IconApp.Click += IconApp_Click;
            btn_camryMainpage.Click += Btn_camryMainpage_Click;
            imageButton_plus.Click += ImageButton_plus_Click;
            imageButton_garbage.Click += ImageButton_garbage_Click;
        }

        private void IconApp_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Homepage));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }

        private void ImageButton_garbage_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(DeleteDeviceActivity));
        }

        private void ImageButton_plus_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AddDeviceActivity));
        }

        private void Btn_camryMainpage_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainPage));
        }
    }
}