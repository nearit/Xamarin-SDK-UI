using System;
using Android.Content;
using Com.Nearit.Ui_bindings;
using Xamarin.Forms;
using Android.Widget;

namespace XamarinUI.Droid.Switcher
{
    public class PermissionsClass
    {
        public static Intent SwitchMode(Context context, string mode, bool layoutUI, bool tapOutside)
        {
            if(tapOutside == true)
            {
                if (layoutUI == true)
                {
                    if (mode.Equals(Global.DEFAULT_PERMISSIONS_MODE))
                    {
                        return NearITUIBindings.GetInstance(context)
                                        .CreatePermissionRequestIntentBuilder()
                                        .EnableTapOutsideToClose()
                                        .Build();
                    }
                    else        //only location
                    {
                        return NearITUIBindings.GetInstance(context)
                                        .CreatePermissionRequestIntentBuilder()
                                        .EnableTapOutsideToClose()
                                        .NoBeacon()
                                        .Build();
                    }
                }
                else    //without UI
                {
                    if (mode.Equals(Global.DEFAULT_PERMISSIONS_MODE))
                    {
                        return NearITUIBindings.GetInstance(context)
                                        .CreatePermissionRequestIntentBuilder()
                                        .InvisibleLayoutMode()
                                        .EnableTapOutsideToClose()
                                        .Build();
                    }
                    else        //only location
                    {
                        return NearITUIBindings.GetInstance(context)
                                        .CreatePermissionRequestIntentBuilder()
                                        .InvisibleLayoutMode()
                                        .EnableTapOutsideToClose()
                                        .NoBeacon()
                                        .Build();
                    }
                }
            }
            else    //without TAP_OUTSIDE_TO_CLOSE
            {
                if (layoutUI == true)
                {
                    if (mode.Equals(Global.DEFAULT_PERMISSIONS_MODE))
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
                else    //without UI
                {
                    if (mode.Equals(Global.DEFAULT_PERMISSIONS_MODE))
                    {
                        return NearITUIBindings.GetInstance(context)
                                        .CreatePermissionRequestIntentBuilder()
                                        .InvisibleLayoutMode()
                                        .Build();
                    }
                    else        //only location
                    {
                        return NearITUIBindings.GetInstance(context)
                                        .CreatePermissionRequestIntentBuilder()
                                        .InvisibleLayoutMode()
                                        .NoBeacon()
                                        .Build();
                    }
                }
            }
        }
    }
}
