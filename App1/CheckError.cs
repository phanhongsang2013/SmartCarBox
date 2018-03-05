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
using App1.Resources;

namespace App1
{
    [Activity(Label = "CheckErrorActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class CheckError : Activity
    {
        string[] arrayList1 = new string[] { "A matching wheel set either too large.", "Missing the front, middle or rear axel set.", "Your battery seem to be too low." };
        string[] arrayList2 = new string[] { "Time: 08:09 09/03/2018",
                                             "Time: 06:07 07/03/2018",
                                             "Time: 04:05 09/03/2018"};
        ListView lstData;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CheckError);

            // Create your application here
            Button button_scan = FindViewById<Button>(Resource.Id.button_scan);
            Button button_check = FindViewById<Button>(Resource.Id.button_check);
            ImageButton img_Back = FindViewById<ImageButton>(Resource.Id.imageButton_Back);
            img_Back.Click += Img_Back_Click;
            //
            lstData = FindViewById<ListView>(Resource.Id.listView);
            List<CarContent> lstSource = new List<CarContent>();
            //add item 1
            CarContent carContent1 = new CarContent()
            {
                Id = 1,
                Name = arrayList1[0],
                Descrip = arrayList2[0],
                Image = Resource.Drawable.ICE1
            };
            lstSource.Add(carContent1);
            //add item 2
            CarContent carContent2 = new CarContent()
            {
                Id = 2,
                Name = arrayList1[1],
                Descrip = arrayList2[1],
                Image = Resource.Drawable.ICE2
            };
            lstSource.Add(carContent2);
            //add item 3
            CarContent carContent3 = new CarContent()
            {
                Id = 3,
                Name = arrayList1[2],
                Descrip = arrayList2[2],
                Image = Resource.Drawable.ICE3
            };
            //
            lstSource.Add(carContent3);
            var adapter = new CustomAdapter(this, lstSource);
            lstData.Adapter = adapter;
            lstData.ItemClick += LstData_ItemClick;
            button_check.Click += Button_check_Click;
        }

        private void Button_check_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Manual_CheckActivity));
        }

        private void LstData_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    break;
                case 1:
                    StartActivity(typeof(TroubleShootingActivitycs));
                    break;
                case 2:
                    break;
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