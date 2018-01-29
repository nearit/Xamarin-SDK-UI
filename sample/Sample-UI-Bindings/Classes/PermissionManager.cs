using System;
using SampleUIBindings.Interfaces;
using Xamarin.Forms;

namespace SampleUIBindings.Classes
{
    public class PermissionManager
    {
        public static void SetPermission(int mode)
        {
            //DependencyService.Get<IPermissions>().Permissions(mode);
        }
    }
}