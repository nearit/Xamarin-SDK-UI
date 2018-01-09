using System;
using Android.Content;

namespace XamarinUI.Droid
{
    public class NearUIDroidInitializer
    {
        public static Context AppContext;

        public static void init(Context context) {
            AppContext = context;
        }
    }
}
