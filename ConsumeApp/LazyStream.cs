using Android.Content;
using Android.Util;
using Huawei.Agconnect.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeApp
{
    class HmsLazyInputStream : LazyInputStream
    {
        public HmsLazyInputStream(Context context) : base(context)
        {
        }

        public override Stream Get(Context context)
        {
            try
            {
                return context.Assets.Open("agconnect-services.json");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString(), "Can't open agconnect file");
                return null;
            }
        }
    }
}
