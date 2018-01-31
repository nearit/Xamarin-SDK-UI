using System;
using NearIT;

namespace XamarinUI.iOS.Switcher
{
    public class PermissionsClass
    {
        public static void SwitchMode(string mode)
        {
            if(mode.Equals(Global.DEFAULT_PERMISSIONS_MODE))
            {
                NITPermissionsViewController permissions = new NITPermissionsViewController();
                permissions.LocationType = NITPermissionsLocationType.Always;
                permissions.Show();
            }
            else        //only location
            {
                NITPermissionsViewController permissions = new NITPermissionsViewController(NITPermissionsType.LocationOnly);
                permissions.LocationType = NITPermissionsLocationType.Always;
                permissions.Show();
            }
        }
    }
}
