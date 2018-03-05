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
using Android.Support.V7.App;

namespace App1
{
    [Activity(Label = "ForgotPWActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ForgotPWActivity : Activity
    {
        EditText editext1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForgotPassword);
            // Create your application here
            ImageView img_logo = FindViewById<ImageView>(Resource.Id.imageView1);
            img_logo.SetImageResource(Resource.Drawable.IconApp);
            editext1 = FindViewById<EditText>(Resource.Id.edittext_forgot);
            TextView textView1 = FindViewById<TextView>(Resource.Id.textview1);
            TextView textView2 = FindViewById<TextView>(Resource.Id.textview2);
            Button button1 = FindViewById<Button>(Resource.Id.btn1);

            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String str_edittext1 = editext1.Text.ToString();
            if (str_edittext1.Contains("0123456789"))
            {
                var intent = new Intent(this, typeof(SendConfirmActivity));
                StartActivity(intent);
            }            
            else
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Failed Sending");
                alert.SetMessage("Check your phone number again!");
                alert.SetButton("OK", (c, ev) =>
                {
                    editext1.Text = "";
                });
                alert.Show();
            }
        }
    }
}