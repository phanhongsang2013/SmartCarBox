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
    [Activity(Label = "ParkingActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ParkingActivity : Activity
    {
        TextView text_address, text_time;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Parking);

            // Create your application here
            ImageButton btn_gr1 = FindViewById<ImageButton>(Resource.Id.btn_gr1);
            ImageButton btn_gr2 = FindViewById<ImageButton>(Resource.Id.btn_gr2);
            ImageButton btn_gr3 = FindViewById<ImageButton>(Resource.Id.btn_gr3);
            ImageButton btn_gr4 = FindViewById<ImageButton>(Resource.Id.btn_gr4);          
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);       
            text_address = FindViewById<TextView>(Resource.Id.text_address);
            text_time = FindViewById<TextView>(Resource.Id.text_time);
            //
            img_Back.Click += Img_Back_Click;
            btn_gr1.Click += Btn_gr1_Click;
            btn_gr2.Click += Btn_gr2_Click;
            btn_gr3.Click += Btn_gr3_Click;
            btn_gr4.Click += Btn_gr4_Click;
        }
        private void Btn_gr4_Click(object sender, EventArgs e)
        {
            text_address.Text = "Address: phường 2 Quận 5, 672A Đường Trần Hưng Đạo, Phường 2, Quận 5, Hồ Chí Minh.";
            text_address.Visibility = ViewStates.Visible;
            text_time.Text = "Time: all day";
            text_time.Visibility = ViewStates.Visible;
        }
        private void Btn_gr3_Click(object sender, EventArgs e)
        {
            text_address.Text = "Address: 240 Ba Tháng Hai, Phường 10, Quận 10, Hồ Chí Minh.";
            text_address.Visibility = ViewStates.Visible;
            text_time.Text = "Time: 07:00-21:00";
            text_time.Visibility = ViewStates.Visible;
        }

        private void Btn_gr2_Click(object sender, EventArgs e)
        {
            text_address.Text = "Address: Huỳnh Thúc Kháng, Bến Nghé, Quận 1, Hồ Chí Minh.";
            text_address.Visibility = ViewStates.Visible;
            text_time.Text = "Time: all day";
            text_time.Visibility = ViewStates.Visible;
        }

        private void Btn_gr1_Click(object sender, EventArgs e)
        {
            text_address.Text = "Address: 2B Phạm Ngũ Lão, Phường Phạm Ngũ Lão, Quận 1, Hồ Chí Minh.";
            text_address.Visibility = ViewStates.Visible;
            text_time.Text = "Time: all day";
            text_time.Visibility = ViewStates.Visible;
        }
        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainPage));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}