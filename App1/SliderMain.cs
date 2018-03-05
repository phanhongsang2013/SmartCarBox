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
using Android.Support.V4.View;
using Java.Lang;

namespace App1
{

    public class SliderMain : PagerAdapter
    {
        private Context context1;
        private int[] imageList =
        {
            Resource.Drawable.slider_Image1,
            Resource.Drawable.ADsWheel,
            Resource.Drawable.slider_Image2,            
            Resource.Drawable.ADsCar,
            Resource.Drawable.ADsSale
        };
        public SliderMain(Context context1)
        {
            this.context1 = context1;
        }
        public override int Count
        {
            get
            {
                return imageList.Length;
            }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view == ((ImageView)@object);
        }
        
        public override Java.Lang.Object InstantiateItem(View container, int position)
        {
            ImageView imageView = new ImageView(context1);
            imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
            imageView.SetImageResource(imageList[position]);
            ((ViewPager)container).AddView(imageView, 0);
            return imageView;


        }
        public override void DestroyItem(View container, int position, Java.Lang.Object @object)
        {
            ((ViewPager)container).RemoveView((ImageView)@object);
        }

    }
}