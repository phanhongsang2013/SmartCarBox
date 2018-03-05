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
    [Activity(Label = "RatingActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class RatingActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Rating);

            // Create your application here
            RatingBar ratingBar = FindViewById<RatingBar>(Resource.Id.ratingBar);
            var btn_submit = FindViewById<Button>(Resource.Id.btn_submit);
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            img_Back.Click += Img_Back_Click;
            btn_submit.Click += (s, e) =>
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Rating Garage");
                alert.SetMessage("Thanks a lot for your feedback!");
                alert.SetButton("Back", (c, ev) =>
                {
                    StartActivity(typeof(MainPage));
                });
                alert.Show();
            };
        }
        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainPage));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}