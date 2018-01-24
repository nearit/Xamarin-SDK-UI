using System;
using NearUI;

namespace XamarinUI.iOS.Switcher
{
    public class PermissionsClass
    {
        public static void SwitchMode(string mode)
        {
            mode = mode.ToLower();

            if(mode.Equals(Global.DEFAULT_PERMISSIONS_MODE))
            {
                NITPermissionsViewController permissions = new NITPermissionsViewController();
                permissions.Show();
            }
            else        //only location
            {
                NITPermissionsViewController permissions = new NITPermissionsViewController(NITPermissionsType.LocationOnly);
                permissions.Show();
            }
        }
    }
}
