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
    [Activity(Label = "S_O_S", ScreenOrientation = ScreenOrientation.Portrait)]
    public class S_O_S : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.S_O_S);

            // Create your application here
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            Button btn_call = FindViewById<Button>(Resource.Id.btn_call);
            //
            img_Back.Click += Img_Back_Click;
            btn_call.Click += Btn_call_Click;
        }

        private void Btn_call_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("tel:01284679504");
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);
        }

        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainPage));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}