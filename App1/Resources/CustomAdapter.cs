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
using Java.Lang;
namespace App1.Resources
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtDescrip { get; set; }
        public ImageView image { get; set; }
    }
    class CustomAdapter : BaseAdapter
    {
        private Activity activity;
        private List<CarContent> carContent;

        public CustomAdapter(Activity activity, List<CarContent> carContent)
        {
            this.activity = activity;
            this.carContent = carContent;
        }
        public override int Count
        {
            get
            {
                return carContent.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return carContent[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.ItemCustomLayout, parent, false);

            var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
      
            var txtDescrip = view.FindViewById<TextView>(Resource.Id.textView3);

            var image = view.FindViewById<ImageView>(Resource.Id.imageView);

            txtName.Text = carContent[position].Name;
            txtDescrip.Text = carContent[position].Descrip;
            image.SetImageResource(carContent[position].Image);

            return view;

        }
    }
}