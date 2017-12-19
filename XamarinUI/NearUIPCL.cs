using System;
using XamarinUI.Interfaces;
using Xamarin.Forms;

namespace XamarinUI
{
    public class NearUIPCL
    {
        public static void SetPermission(int type, int mode)       //type = PERMISSIONS_MODE, COUPON_MODE, ...    mode = LOCATION + BLUETOOTH, ...
        {
            DependencyService.Get<IManager>().PermissionType(type, mode);
        }
    }
}
