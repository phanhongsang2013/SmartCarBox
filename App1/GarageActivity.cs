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
    [Activity(Label = "GarageActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class GarageActivity : Activity
    {
        TextView text_address, text_time;
        ImageButton btn_location, btn_gr1, btn_gr2, btn_gr3, btn_gr4, btn_gr5;
        Button btn_direction;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Garage);

            // Create your application here
            ImageButton btn_gr1 = FindViewById<ImageButton>(Resource.Id.btn_gr1);
            ImageButton btn_gr2 = FindViewById<ImageButton>(Resource.Id.btn_gr2);
            ImageButton btn_gr3 = FindViewById<ImageButton>(Resource.Id.btn_gr3);
            ImageButton btn_gr4 = FindViewById<ImageButton>(Resource.Id.btn_gr4);
            ImageButton btn_gr5 = FindViewById<ImageButton>(Resource.Id.btn_gr5);
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            btn_location = FindViewById<ImageButton>(Resource.Id.btn_location);
            text_address = FindViewById<TextView>(Resource.Id.textView1);
            text_time = FindViewById<TextView>(Resource.Id.textview0);
            btn_direction = FindViewById<Button>(Resource.Id.btn_direction);

            //
            img_Back.Click += Img_Back_Click;
            btn_gr1.Click += Btn_gr1_Click;
            btn_gr2.Click += Btn_gr2_Click;
            btn_gr3.Click += Btn_gr3_Click;
            btn_gr4.Click += Btn_gr4_Click;
            btn_gr5.Click += Btn_gr5_Click;
            btn_location.Click += Btn_location_Click;
            btn_direction.Click += Btn_direction_Click;
        }

        private void Btn_direction_Click(object sender, EventArgs e)
        {
            btn_location.SetImageResource(Resource.Drawable.DirectionGarage1);
        }

        private void Btn_location_Click(object sender, EventArgs e)
        {
            btn_location.SetImageResource(Resource.Drawable.LocationZoom);
        }

        private void Btn_gr5_Click(object sender, EventArgs e)
        {
            text_address.Text = "Address: 83 Trần Não, Thảo Điền, Quận 2, Hồ Chí Minh.";
            text_address.Visibility = ViewStates.Visible;
            text_time.Text = "Time: 08:00–17:30";
            text_time.Visibility = ViewStates.Visible;        
        }

        private void Btn_gr4_Click(object sender, EventArgs e)
        {
            text_address.Text = "Address: 462 Phan Văn Trị, Phường 7, Quận 5, Hồ Chí Minh.";
            text_address.Visibility = ViewStates.Visible;
            text_time.Text = "Time: 07:30–17:30";
            text_time.Visibility = ViewStates.Visible;
        }

        private void Btn_gr3_Click(object sender, EventArgs e)
        {
            text_address.Text = "Address: 45 Nguyễn Quý Cảnh, Khu đô thị An Phú An Khánh, An Phú, Quận 2, Hồ Chí Minh.";
            text_address.Visibility = ViewStates.Visible;
            text_time.Text = "Time: 08:00–18:00";
            text_time.Visibility = ViewStates.Visible;
        }

        private void Btn_gr2_Click(object sender, EventArgs e)
        {
            text_address.Text = "Address: Số 7, Thảo Điền, Quận 2, Hồ Chí Minh.";
            text_address.Visibility = ViewStates.Visible;
            text_time.Text = "Time: 08:00–18:00";
            text_time.Visibility = ViewStates.Visible;
        }

        private void Btn_gr1_Click(object sender, EventArgs e)
        {
            text_address.Text = "Address: 4 Đường số 12 Trần Não, P. Bình An, Quận 2, Hồ Chí Minh.";
            text_address.Visibility = ViewStates.Visible;
            text_time.Text = "Time: 08:00–17:30";
            text_time.Visibility = ViewStates.Visible;
            btn_location.SetImageResource(Resource.Drawable.Garage1);
        }
    
        
        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainPage));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}