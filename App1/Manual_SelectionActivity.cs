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
    [Activity(Label = "Manual_SelectionActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Manual_SelectionActivity : Activity
    {
        TextView Text_error;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Manual_Selection);

            // Create your application here
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);            
            Button btn_no = FindViewById<Button>(Resource.Id.btn_no);
            Button btn_yes = FindViewById<Button>(Resource.Id.btn_yes);
            ImageButton dropArrow = FindViewById<ImageButton>(Resource.Id.dropArrow);
            Text_error = FindViewById<TextView>(Resource.Id.Text_error);
            //
            img_Back.Click += Img_Back_Click;
            btn_no.Click += Btn_no_Click;
            btn_yes.Click += Btn_yes_Click;
            dropArrow.Click += DropArrow_Click;
        }

        private void DropArrow_Click(object sender, EventArgs e)
        {
            Text_error.Visibility = ViewStates.Visible;
        }

        private void Btn_yes_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_no_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Manual_CheckActivity));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }

        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Manual_CheckActivity));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}