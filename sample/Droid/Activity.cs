
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SampleUIBindings.Interfaces;
using Xamarin.Forms;
using XamarinBridge.PCL.Types;
using XamarinUI.Droid;
using XamarinUI.Droid.Adapter;

[assembly: Dependency(typeof(SampleUIBindings.Droid.MyActivity))]
namespace SampleUIBindings.Droid
{
    [Activity(Label = "MyActivity")]
    public class MyActivity : Activity, IPermissions
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }



        public void Coupon(XCCouponNotification coupon)
        {
            NearUIDroid.UICoupon(AdapterCoupon.GetNativeType(coupon), Resource.Drawable.dadi);
        }

        public void CouponList()
        {
            NearUIDroid.UICouponList();
        }

        public void DefaultContent(XCContentNotification content)
        {
            NearUIDroid.UIContent(AdapterContent.GetNativeType(content));
        }

        public void DefaultFeedback(XCFeedbackNotification feedback)
        {
            NearUIDroid.UIFeedback(AdapterFeedback.GetNativeType(feedback));
        }

        public void DefaultPermissions()
        {
            NearUIDroid.UIPermission((int obj) => 
            {
                if (obj == 0)
                {
                    Console.WriteLine("granted!");
                }
                else
                {
                    Console.WriteLine("denied");
                }
            }, false);
        }

        public void LocationPermissions()
        {
            NearUIDroid.UIOnlyLocation((int obj) =>
            {
                if (obj == 0)
                {
                    Console.WriteLine("granted!");
                }
                else
                {
                    Console.WriteLine("denied");
                }
            }, false);
        }

    }
}
