using System;
using Android.Content;
using Com.Nearit.Ui_bindings;
using Xamarin.Forms;
using Android.Widget;

namespace XamarinUI.Droid.Switcher
{
    public class PermissionsClass
    {
        public static Intent SwitchMode(string mode, Context context)
        {
            mode = mode.ToLower();

            if(mode.Equals(Global.DEFAULT_PERMISSIONS_MODE))
            {
                return NearITUIBindings.GetInstance(context)
                                .CreatePermissionRequestIntentBuilder()
                                .Build();
            }
            else        //only location
            {
                return NearITUIBindings.GetInstance(context)
                                .CreatePermissionRequestIntentBuilder()
                                .NoBeacon()
                                .Build();
            }
        }
    }
}
