using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.Support.V7.App;
using Android.Support.V4.View;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Content.PM;
using App1.Resources;
using Android.Content;
using System.Threading.Tasks;
using System.Timers;

namespace App1
{
    [Activity(Label = "Smart Car Box", Theme = "@style/MyTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainPage : ActionBarActivity
    {
        SupportToolbar toolbar1;
        MyActionBarDrawerToggle mDrawerToggle;
        DrawerLayout mDrawerLayout;
        ListView listView1;
        List<string> list1;
        Timer timer;
        ViewPager viewPager;
        
        //ListView mLeftDrawer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainPage);
            // Create your application here

            //tool bar + action bar         
            toolbar1 = FindViewById<SupportToolbar>(Resource.Id.toolbar1);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            SetSupportActionBar(toolbar1);
            mDrawerToggle = new MyActionBarDrawerToggle(this, mDrawerLayout, Resource.String.app_name, Resource.String.app_name);
            mDrawerLayout.AddDrawerListener(mDrawerToggle);

            SupportActionBar.SetTitle(Resource.String.app_name);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            mDrawerToggle.SyncState();


            // android v4 support view slider main
            viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            SliderMain imageAdapter = new SliderMain(this);
            viewPager.Adapter = imageAdapter;
            timer = new Timer();
            timer.Interval = 3000;
            timer.Start();
            timer.Elapsed += Elapsed;

            // Handler to list view1
            listView1 = FindViewById<ListView>(Resource.Id.listView1);          
            list1 = new List<string>();
            list1.Add("Account Setting");
            list1.Add("Reward Points");
            list1.Add("Rating Garage");
            list1.Add("FAQ");
            list1.Add("About Us");
            list1.Add("Log Out");
            ArrayAdapter<string> arrayAdapter1 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, list1);
            listView1.Adapter = arrayAdapter1;
            listView1.ItemClick += ListView1_ItemClick;   

            //
            ImageView account_Setting = FindViewById<ImageView>(Resource.Id.account_Setting);
            account_Setting.SetImageResource(Resource.Drawable.ICO1);
            ImageView account_Reward = FindViewById<ImageView>(Resource.Id.account_Reward);
            account_Reward.SetImageResource(Resource.Drawable.ICO2);
            ImageView rating_Garage = FindViewById<ImageView>(Resource.Id.rating_Garage);
            rating_Garage.SetImageResource(Resource.Drawable.ICO3);
            ImageView Faq = FindViewById<ImageView>(Resource.Id.Faq);
            Faq.SetImageResource(Resource.Drawable.ICO4);
            ImageView aboutUs = FindViewById<ImageView>(Resource.Id.aboutUs);
            aboutUs.SetImageResource(Resource.Drawable.ICO5);
            ImageView logOut = FindViewById<ImageView>(Resource.Id.logOut);
            logOut.SetImageResource(Resource.Drawable.ICO6);
            TextView txt_hello = FindViewById<TextView>(Resource.Id.textViewHello);
            TextView txt_bonus = FindViewById<TextView>(Resource.Id.bonuspoint);

            //
            ImageButton btn_checkError = FindViewById<ImageButton>(Resource.Id.btn_checkError);
            ImageButton btn_carStatus = FindViewById<ImageButton>(Resource.Id.btn_carStatus);
            ImageButton btn_sos = FindViewById<ImageButton>(Resource.Id.btn_sos);            

            //
            ImageButton btn_findGarage = FindViewById<ImageButton>(Resource.Id.btn_findGarage);           
            ImageButton btn_findParking = FindViewById<ImageButton>(Resource.Id.btn_findParking);
            ImageButton btn_lockUnlock = FindViewById<ImageButton>(Resource.Id.btn_lockUnlock);

            //
            ImageButton btn_maintain = FindViewById<ImageButton>(Resource.Id.btn_maintain);
            ImageButton btn_aboutUs = FindViewById<ImageButton>(Resource.Id.btn_aboutUs);

            //
            btn_checkError.Click += Btn_checkError_Click;
            btn_carStatus.Click += Btn_Car_Status_Click;
            btn_sos.Click += Btn_SOS_Click;
            btn_findGarage.Click += Btn_Find_Garage_Click;
            btn_findParking.Click += Btn_Find_Parking_Click;
            btn_lockUnlock.Click += Btn_Lock_Unlock_Click;
            btn_maintain.Click += Btn_maintain_Click;
            btn_aboutUs.Click += Btn_aboutUs_Click;


        }       
        private void Elapsed(object sender, ElapsedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                if (viewPager.CurrentItem.ToString()=="0") { viewPager.SetCurrentItem(1, true); }
                else 
                    if (viewPager.CurrentItem.ToString() == "1") { viewPager.SetCurrentItem(2, true); }
                    else
                        if (viewPager.CurrentItem.ToString() == "2") { viewPager.SetCurrentItem(3, true); }
                        else
                            if (viewPager.CurrentItem.ToString() == "3") { viewPager.SetCurrentItem(4, true); }
                            else { viewPager.SetCurrentItem(0, true); }
            });
        }
        private void ListView1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            switch(e.Position)
            {
                case 0:
                    StartActivity(typeof(AccountActivity));
                    break;
                case 1:
                    StartActivity(typeof(Personal_InforActivity));
                    break;
                case 2:
                    StartActivity(typeof(RatingActivity));
                    break;
                case 3:
                    StartActivity(typeof(FAQActivity));
                    break;
                case 4:
                    StartActivity(typeof(AboutusActivity));
                    break;
                case 5:
                    var intent = new Intent(this, typeof(Homepage));
                    intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
                    StartActivity(intent);
                    break;
            }

        }
        //------------------------
        private void Btn_checkError_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Application.Context, typeof(SearchActivity)));
        }
        private void Btn_Car_Status_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Application.Context, typeof(CarInformationActivity)));
        }
        private void Btn_SOS_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Application.Context, typeof(S_O_S)));
        }       
        //---------------------------
        private void Btn_Find_Garage_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Application.Context, typeof(GarageActivity)));
        }
        private void Btn_Find_Parking_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Application.Context, typeof(ParkingActivity)));
        }
        private void Btn_Lock_Unlock_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Application.Context, typeof(LockOrUnlock_Activity)));
        }
        //------------------
        private void Btn_maintain_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Application.Context, typeof(MaintainaceActivity)));
        }
        private void Btn_aboutUs_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Application.Context, typeof(ReportActivity)));
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);            
            return base.OnOptionsItemSelected(item);
        }

    }
}