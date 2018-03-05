using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android.Util;
using Android.Content.PM;

namespace App1
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() =>
            {

                Task.Delay(3000);
                StartActivity(new Android.Content.Intent(Application.Context, typeof(Homepage)));
            });
            startupWork.Start();

        }

    }
}

