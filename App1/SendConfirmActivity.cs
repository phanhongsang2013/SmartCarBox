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
using CN.Iwgang.Countdownview;
using System.Timers;
using Android.Content.PM;
using System.Threading.Tasks;

namespace App1
{
    [Activity(Label = "SendConfirmActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SendConfirmActivity : AppCompatActivity
    {
        EditText edittext_confirm;
        TextView Countdown;
        int count = 60;
        Timer timer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SenCofirm);
            //
            edittext_confirm = FindViewById<EditText>(Resource.Id.edittext_confirm);
            Button button_forgotPW = FindViewById<Button>(Resource.Id.button_forgetPW);
            Countdown = FindViewById<TextView>(Resource.Id.Countdown);
            ImageView img_logo = FindViewById<ImageView>(Resource.Id.imageView1);
            img_logo.SetImageResource(Resource.Drawable.c);
            Button Confirm_bt = FindViewById<Button>(Resource.Id.Confirm_bt);

            Confirm_bt.Click += Confirm_bt_Click;
            button_forgotPW.Click += btn_forgotPS_click;
        }

        private void Confirm_bt_Click(object sender, EventArgs e)
        {
            String str_confirm = edittext_confirm.Text.ToString();
            if (str_confirm.Contains("1234"))
            {
                var intent = new Intent(this, typeof(ChangePasswordActivity));
                intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
                StartActivity(intent);
            }
            else
            {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Failed confirmation");
                    alert.SetMessage("Check it again!");
                    alert.SetButton("OK", (c, ev) =>
                    {
                        edittext_confirm.Text = "";
                        count = 60;
                    });
                    alert.Show();
                }           
        }

        private void btn_forgotPS_click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ForgotPWActivity));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
        protected override void OnResume()
        {
            base.OnResume();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Elapsed += Elapsed;
        }
        private void Elapsed(object sender, ElapsedEventArgs e)
        {
            RunCountDown();
        }

        private async Task RunCountDown()
        {
            if (count > 0)
            {
                count--;
                RunOnUiThread(() => { Countdown.Text = "" + count; });
            }
            else
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Failed confirmation");
                alert.SetMessage("Check it again!");
                alert.SetButton("OK", (c, ev) =>
                {
                    RunOnUiThread(() =>
                    {
                        count = 60;
                        edittext_confirm.Text = "";
                        Countdown.Text = "" + count;
                    });

                });
                alert.Show();
            }
        }
    }
}