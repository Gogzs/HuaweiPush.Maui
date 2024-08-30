using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Nfc;
using Android.OS;
using Android.Util;
using Huawei.Agconnect.Config;
using Huawei.Hms.Aaid;
using Huawei.Hms.Common;
using Huawei.Hms.Push;

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
                        string appid = AGConnectServicesConfig.FromContext(this.ApplicationContext).GetString("client/app_id");
                        var smece = HmsInstanceId.GetInstance(this.ApplicationContext);
                        var uhh = smece?.GetToken(appid, "HCM");
                        ShareMe.SetSmece(uhh);
                        HmsMessaging.GetInstance(this.ApplicationContext).TurnOnPush();

                        HmsMessaging.GetInstance(this.ApplicationContext).AutoInitEnabled = true;
                    }
                    catch (Exception e)
                    {
                        var uhhh = e.Message;
                    }
                });

                thread.Start();
        }

        protected override void AttachBaseContext(Context? context)
        {
            base.AttachBaseContext(context);

            AGConnectServicesConfig config = AGConnectServicesConfig.FromContext(context);
            config.OverlayWith(new HmsLazyInputStream(context));
        }
    }
}
