using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeApp
{
    public static class ShareMe
    {
        private static string _smece;

        public static void SetSmece(string smece)
        {
            _smece = smece;
        }

        public static string Smece => _smece;
    }
}
