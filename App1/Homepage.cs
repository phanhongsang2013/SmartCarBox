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
using Android.Support.V7.App;
using Android.Content.PM;

namespace App1
{
    [Activity(Label = "App1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Homepage : Activity
    {
        EditText editText_username;
        EditText editText_password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);

            // Create your application here
            ImageView img_logo = FindViewById<ImageView>(Resource.Id.imageView1);
            img_logo.SetImageResource(Resource.Drawable.IconApp);
            ImageView img_name = FindViewById<ImageView>(Resource.Id.imageView_NameApp);
            img_name.SetImageResource(Resource.Drawable.NameApp);
            Button button_login = FindViewById<Button>(Resource.Id.button_login);
            Button button_aboutus = FindViewById<Button>(Resource.Id.button_aboutus);
            Button button_forgotPW = FindViewById<Button>(Resource.Id.button_forgetPW);
            editText_username = FindViewById<EditText>(Resource.Id.username_id);
            editText_password = FindViewById<EditText>(Resource.Id.password);
            TextView textViewAbout = FindViewById<TextView>(Resource.Id.text2);
            // Click
            button_forgotPW.Click += btn_forgotPS_click;
            button_login.Click += btn_login_click;
            button_aboutus.Click += btn_aboutus_click;
        }

        private void btn_forgotPS_click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Application.Context, typeof(ForgotPWActivity)));
        }

        private void btn_aboutus_click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Application.Context, typeof(AboutusActivity)));
        }

        private void btn_login_click(object sender, EventArgs e)
        {
            String str_username = editText_username.Text.ToString();
            String str_password = editText_password.Text.ToString();

            if (str_username.Contains("admin"))
            {
                if (str_password.Contains("admin"))
                {                
                    StartActivity(new Android.Content.Intent(Application.Context, typeof(DeviceListActivitycs)));
                }
                else
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Login Information");
                    alert.SetMessage("Failed Login");
                    alert.SetMessage("Please Check Again");
                    alert.SetButton("Try Again", (c, ev) =>
                    {
                        editText_username.Text = "";
                        editText_password.Text = "";
                        editText_password.ClearFocus();

                    });
                    alert.Show();
                }
            }
            else
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Login Information");
                alert.SetMessage("Please Check Again");
                alert.SetButton("Try Again", (c, ev) =>
                {
                    editText_username.Text = "";
                    editText_password.Text = "";
                    editText_password.ClearFocus();

                });
                alert.Show();
            }
        }
    }
}
