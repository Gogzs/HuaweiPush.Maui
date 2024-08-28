using Android.App;
using Android.Content.PM;
using Android.Nfc;
using Android.OS;
using Android.Util;
using Huawei.Agconnect.Config;
using Huawei.Hms.Aaid;
using Huawei.Hms.Common;

namespace ConsumeApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

                System.Threading.Thread thread = new System.Threading.Thread(() =>
                {
                    try
                    {
                        var smece = HmsInstanceId.GetInstance(this.ApplicationContext);
                        var uhh = smece?.GetToken("hehehe");
                    }
                    catch (Exception e)
                    {
                        var uhhh = e.Message;
                    }
                });

                thread.Start();
        }
    }
}
