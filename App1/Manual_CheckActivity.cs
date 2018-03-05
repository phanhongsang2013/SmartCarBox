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
    [Activity(Label = "Manual_CheckActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Manual_CheckActivity : Activity
    {
        string itemCurrent;
        List<string> listItems = new List<string>();
        ArrayAdapter<string> adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Manual_Check);

            // Create your application here
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            img_Back.Click += Img_Back_Click;
            Button btn_check = FindViewById<Button>(Resource.Id.btn_check);
            Spinner spinner1 = FindViewById<Spinner>(Resource.Id.spinner);
            spinner1.ItemSelected += (s, e) =>
            {
                if (e.Position != -1)
                {
                    itemCurrent = spinner1.GetItemAtPosition(e.Position).ToString();
                }
            };
            btn_check.Click += (s,e) =>
            {
                if (itemCurrent=="Wheel")
                {
                    StartActivity(typeof(Manual_SelectionActivity));
                }
            }; 
             //spinner
             /*
             listItems.Add("Wheel");
             listItems.Add("Brake");
             listItems.Add("Exhaust fumes");
             spinner = FindViewById<MaterialSpinner>(Resource.Id.spinner);
             adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);
             adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
             spinner.Adapter = adapter;
             spinner.ItemSelected += (s, e) =>
             {
                 if(e.Position != -1)
                 {
                     string selected = spinner.GetItemAtPosition(e.Position).ToString();
                 }
             };*/
             
        }
        private void Img_Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CheckError));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            StartActivity(intent);
        }
    }
}