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
    public class CarContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrip { get; set; }
        public int Image { get; set; }
    }
}