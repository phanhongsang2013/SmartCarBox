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
	[Activity(Label = "DeleteDeviceActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class DeleteDeviceActivity : Activity
	{
        bool kt1 = true, kt2 = true, kt3 = true;
        ImageView icon_ok2, icon_car2;
        TextView text_item2, text_model2;
        Button btn2;
        View view2;
        //
        ImageView icon_ok3, icon_car3;
        TextView text_item3, text_model3;
        Button btn3;
        View view3;
        protected override void OnCreate(Bundle savedInstanceState)
		{
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DeleteDevice);

            // Create your application here
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            Button btn1 = FindViewById<Button>(Resource.Id.btn1);         

            //item 2
            icon_ok2 = FindViewById<ImageView>(Resource.Id.icon_ok2);
            text_item2 = FindViewById<TextView>(Resource.Id.text_item2);
            icon_car2 = FindViewById<ImageView>(Resource.Id.icon_car2);
            text_model2 = FindViewById<TextView>(Resource.Id.text_model2);
            btn2 = FindViewById<Button>(Resource.Id.btn2);
            view2 = FindViewById<View>(Resource.Id.view2);

            //item 2
            icon_ok3 = FindViewById<ImageView>(Resource.Id.icon_ok3);
            text_item3 = FindViewById<TextView>(Resource.Id.text_item3);
            icon_car3 = FindViewById<ImageView>(Resource.Id.icon_car3);
            text_model3 = FindViewById<TextView>(Resource.Id.text_model3);
            btn3 = FindViewById<Button>(Resource.Id.btn3);
            view3 = FindViewById<View>(Resource.Id.view3);

            //
            img_Back.Click += Img_Back_Click;
            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
        }
        private void Btn1_Click(object sender, EventArgs e)
        {

        }
        private void Btn2_Click(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Delete Device");
            alert.SetMessage("Are you sure to delete this device?");
            alert.SetButton("OK", (c, ev) =>
            {
                kt2 = false;
                icon_ok2.Visibility = ViewStates.Gone;
                icon_car2.Visibility = ViewStates.Gone;
                text_item2.Visibility = ViewStates.Gone;
                text_model2.Visibility = ViewStates.Gone;
                btn2.Visibility = ViewStates.Gone;
                view2.Visibility = ViewStates.Gone;
            });
            alert.Show();
        }
        private void Btn3_Click(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Delete Device");
            alert.SetMessage("Are you sure to delete this device?");
            alert.SetButton("OK", (c, ev) =>
            {
                kt3 = false;
                icon_ok3.Visibility = ViewStates.Gone;
                icon_car3.Visibility = ViewStates.Gone;
                text_item3.Visibility = ViewStates.Gone;
                text_model3.Visibility = ViewStates.Gone;
                btn3.Visibility = ViewStates.Gone;
                view3.Visibility = ViewStates.Gone;
            });
            alert.Show();
        }
        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(DeviceListActivitycs));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}