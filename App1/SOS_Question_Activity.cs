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

namespace App1
{
    [Activity(Label = "SOS_Question_Activity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SOS_Question_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SOS_Question);
            // Create your application here
            ImageView img_icon = FindViewById<ImageView>(Resource.Id.imageView_CarProblem);
            img_icon.SetImageResource(Resource.Drawable.car_problem);
            TextView text_Title = FindViewById<TextView>(Resource.Id.textView_Title);
            TextView text_Question = FindViewById<TextView>(Resource.Id.textview_question);
            Button btn_Yes = FindViewById<Button>(Resource.Id.btn_Yes);
            Button btn_No = FindViewById<Button>(Resource.Id.btn_No);

            // Click
            btn_Yes.Click += Btn_Yes_Click;
            btn_No.Click += Btn_No_Click;
        }

        private void Btn_No_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainPage));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }

        private void Btn_Yes_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Waiting_SOS_Activity));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}