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

namespace App1
{
    [Activity(Label = "FAQActivity")]
    public class FAQActivity : Activity
    {
        TextView textView1;
        TextView textView2;
        ImageButton IconPlus1, IconPlus2;
        bool kt1 = false, kt2 = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FAQ);

            // Create your application here
            IconPlus1 = FindViewById<ImageButton>(Resource.Id.IconPlus1);
            IconPlus1.SetImageResource(Resource.Drawable.plus_icon);
            IconPlus2 = FindViewById<ImageButton>(Resource.Id.IconPlus2);
            IconPlus2.SetImageResource(Resource.Drawable.plus_icon);

            textView1 = FindViewById<TextView>(Resource.Id.textview1);
            textView2 = FindViewById<TextView>(Resource.Id.textview2);

            //
            IconPlus1.Click += IconPlus1_Click;
            IconPlus2.Click += IconPlus2_Click;

            //
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            img_Back.Click += Img_Back_Click;
        }

        private void IconPlus1_Click(object sender, EventArgs e)
        {
            if (kt1 == false)
            {
                kt1 = true;
                textView1.Visibility = ViewStates.Visible;
                IconPlus1.SetImageResource(Resource.Drawable.minus_icon);
            }
            else
            {
                kt1 = false;
                textView1.Visibility = ViewStates.Gone;
                IconPlus1.SetImageResource(Resource.Drawable.plus_icon);
            }
        }
        private void IconPlus2_Click(object sender, EventArgs e)
        {
            if (kt2 == false)
            {
                kt2 = true;
                textView2.Visibility = ViewStates.Visible;
                IconPlus2.SetImageResource(Resource.Drawable.minus_icon);
            }
            else
            {
                kt2 = false;
                textView2.Visibility = ViewStates.Gone;
                IconPlus2.SetImageResource(Resource.Drawable.plus_icon);
            }
        }
        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainPage));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}