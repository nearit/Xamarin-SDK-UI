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
using System.Collections.Generic;
using IT.Near.Sdk.Reactions.Couponplugin.Model;
using IT.Near.Sdk.Reactions.Contentplugin.Model;
using IT.Near.Sdk.Reactions.Feedbackplugin.Model;
using Com.Nearit.Ui_bindings;
using XamarinBridge.PCL.Types;

[assembly: Dependency(typeof(XamarinUI.Droid.NearUIDroid))]
namespace XamarinUI.Droid
{
    [Activity(Label = "NearUIDroid")]
    public class NearUIDroid : Activity, IManager
    {
        private static int NEAR_PERMISSION_REQUEST = 1000;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            System.Diagnostics.Debug.WriteLine("OnPostCreate");
            OnNewIntent(Intent);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            System.Diagnostics.Debug.WriteLine("OnNewIntent");

            var type = intent.Action;
            var mode = intent.GetStringExtra("mode");

            System.Diagnostics.Debug.WriteLine("type: " + type);
            System.Diagnostics.Debug.WriteLine("mode: " + mode);

            if(type.Equals("permissions"))
            {
                StartActivityForResult(Switcher.PermissionsClass.SwitchMode(mode, this), NEAR_PERMISSION_REQUEST);
            }
            else if(type.Equals("coupon"))
            {
                Coupon coupon = (IT.Near.Sdk.Reactions.Couponplugin.Model.Coupon)intent.GetParcelableExtra("coupon");
                StartActivityForResult(Switcher.CouponClass.SwitchMode(mode, this, coupon), NEAR_PERMISSION_REQUEST);
            }
            else if (type.Equals("feedback"))
            {
                Feedback feedback = (IT.Near.Sdk.Reactions.Feedbackplugin.Model.Feedback)intent.GetParcelableExtra("feedback");
                StartActivityForResult(Switcher.FeedbackClass.SwitchMode(mode, this, feedback), NEAR_PERMISSION_REQUEST);
            }
            else if (type.Equals("content"))
            {
                Content content = (IT.Near.Sdk.Reactions.Contentplugin.Model.Content)intent.GetParcelableExtra("content");
                StartActivityForResult(Switcher.ContentClass.SwitchMode(mode, this, content), NEAR_PERMISSION_REQUEST);
            }

        }




        public void PermissionTypeFromPCL(string mode)
        {
            UIPermissions(mode);
        }

        public void CouponTypeFromPCL(string mode, XCCouponNotification coupon)
        {
            Coupon NCoupon = new Coupon();
            NCoupon = Adapter.AdapterCoupon.GetNativeType(coupon);
            UICoupon(mode, NCoupon);
        }

        public void ContentTypeFromPCL(string mode, XCContentNotification content)
        {
            Content NContent = new Content();
            NContent = Adapter.AdapterContent.GetNativeType(content);
            UIContent(mode, NContent);
        }

        public void FeedbackTypeFromPCL(string mode, XCFeedbackNotification feedback)
        {
            Feedback NFeedback = new Feedback();
            NFeedback = Adapter.AdapterFeedback.GetNativeType(feedback);
            UIFeedback(mode, NFeedback);
        }



        public static void UIPermissions(string mode)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("mode", mode);
            intent.SetAction("permissions");

            (Forms.Context).StartActivity(intent);
        }

        public static void UICoupon(string mode, Coupon coupon)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("mode", mode);
            intent.PutExtra("coupon", coupon);
            intent.SetAction("coupon");

            (Forms.Context).StartActivity(typeof(NearUIDroid));
        }

        public static void UIContent(string mode, Content content)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("mode", mode);
            intent.PutExtra("content", content);
            intent.SetAction("content");

            (Forms.Context).StartActivity(typeof(NearUIDroid));
        }

        public static void UIFeedback(string mode, Feedback feedback)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("mode", mode);
            intent.PutExtra("feedback", feedback);
            intent.SetAction("feedback");

            (Forms.Context).StartActivity(typeof(NearUIDroid));

        }
    }
}