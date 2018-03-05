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
using SupportActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;

namespace App1
{

    class MyActionBarDrawerToggle : SupportActionBarDrawerToggle
    {
        ActionBarActivity mHostActivity;
        int mopenedResource;
        int mclosedResource;
        public MyActionBarDrawerToggle(ActionBarActivity host, DrawerLayout drawerLayout, int openedResource, int closedResource) 
            : base(host, drawerLayout, openedResource, closedResource)
        {
            mHostActivity = host;
            mopenedResource = openedResource;
            mclosedResource = closedResource;
        }
        public override void OnDrawerOpened(View drawerView)
        {
            base.OnDrawerOpened(drawerView);
            mHostActivity.SupportActionBar.SetTitle(mopenedResource);
        }
        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);
            mHostActivity.SupportActionBar.SetTitle(mopenedResource);
        }
        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
        }
    }
}