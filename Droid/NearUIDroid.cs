using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XamarinUI.Interfaces;
using Xamarin.Forms;
using XamarinUI.Types;

namespace XamarinUI.Droid
{
    [Activity(Label = "NearUIDroid")]
    public class NearUIDroid : Activity, IManager
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
        }

        public void PermissionType(int type, int mode)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra(PERMISSION_MODE, mode);

            (Forms.Context).StartActivity(typeof(NearUIDroid));
        }
    }
}
