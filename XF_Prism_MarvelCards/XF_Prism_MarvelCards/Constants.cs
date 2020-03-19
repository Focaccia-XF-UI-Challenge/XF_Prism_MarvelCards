using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_Prism_MarvelCards
{
    public static class Constants
    {
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        //[Android可以使用模擬器取得WebAPI URL]
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "http://10.0.2.2:94" : "http://localhost:94";
        public static string MarvelCardsItemsUrl = BaseAddress + "/api/{0}";

    }
}
