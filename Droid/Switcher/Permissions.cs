using System;
using Android.Content;
using Com.Nearit.Ui_bindings;
using XamarinUI.Global;
using Xamarin.Forms;
using Android.Widget;

namespace XamarinUI.Droid.Switcher
{
    public class PermissionsClass
    {
        public static Intent SwitchMode(string mode, Context context)
        {
            mode = mode.ToLower();

            if(mode.Equals(Global.Global.DEFAULT_PERMISSIONS_MODE))
            {
                return NearITUIBindings.GetInstance(context)
                                .CreatePermissionRequestIntentBuilder()
                                .EnableTapOutsideToClose()
                                .Build();
            }
            else if (mode.Equals(Global.Global.LOCATION_MODE))
            {
                return NearITUIBindings.GetInstance(context)
                                .CreatePermissionRequestIntentBuilder()
                                .NoBeacon()
                                .EnableTapOutsideToClose()
                                .Build();
            }
            else
            {
                Intent inte = new Intent();
                inte.SetType("invalid");
                int resId = Resource.Layout.nearit_ui_activity_feedback;

                return inte;
            }
        }
    }
}
