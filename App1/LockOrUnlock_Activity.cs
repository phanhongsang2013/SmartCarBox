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
    [Activity(Label = "LockOrUnlock_Activity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class LockOrUnlock_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CarStatus);

            // Create your application here
            ImageView img_icon = FindViewById<ImageView>(Resource.Id.imageView_lockIcon);
            img_icon.SetImageResource(Resource.Drawable.Lock_Icon);
            TextView text_Title = FindViewById<TextView>(Resource.Id.textView_Title);
            Button btn_Lock = FindViewById<Button>(Resource.Id.btn_Lock);
            Button btn_Unlock = FindViewById<Button>(Resource.Id.btn_Unlock);
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            img_Back.Click += Img_Back_Click;

            // Click
            btn_Lock.Click += Btn_Lock_Click;
            btn_Unlock.Click += Btn_Unlock_Click;
        }
        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainPage));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }

        private void Btn_Unlock_Click(object sender, EventArgs e)
        {
            //Open car
        }

        private void Btn_Lock_Click(object sender, EventArgs e)
        {
            //Close car
        }
    }
}