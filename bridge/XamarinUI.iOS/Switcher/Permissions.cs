using System;
using NearIT;

namespace XamarinUI.iOS.Switcher
{
    public class PermissionsClass
    {
        public static void SwitchMode(string mode, LocationType locationType)
        {
            if(mode.Equals(Global.DEFAULT_PERMISSIONS_MODE))
            {
                if(locationType.Equals(0))
                {
                    NITPermissionsViewController permissions = new NITPermissionsViewController();
                    permissions.LocationType = NITPermissionsLocationType.WhenInUse;
                    permissions.Show();
                }
                else
                {
                    NITPermissionsViewController permissions = new NITPermissionsViewController();
                    permissions.LocationType = NITPermissionsLocationType.Always;
                    permissions.Show();
                }
            }
            else        //only location
            {
                if (locationType.Equals(0))
                {
                    NITPermissionsViewController permissions = new NITPermissionsViewController(NITPermissionsType.LocationOnly);
                    permissions.LocationType = NITPermissionsLocationType.WhenInUse;
                    permissions.Show();
                }
                else
                {
                    NITPermissionsViewController permissions = new NITPermissionsViewController(NITPermissionsType.LocationOnly);
                    permissions.LocationType = NITPermissionsLocationType.Always;
                    permissions.Show();
                }
            }
        }
    }
}
