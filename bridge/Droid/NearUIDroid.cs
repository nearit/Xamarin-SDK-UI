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
    [Activity(Theme = "@android:style/Theme.Translucent")]
    public class NearUIDroid : Activity, IManager
    {
        private static Action<int> resultHandler;

        private static int NEAR_PERMISSION_REQUEST = 1000;
        private static int NEAR_CONTENT_REQUEST = 2000;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            OnNewIntent((Intent)Intent);
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
                Coupon coupon = (Coupon)intent.GetParcelableExtra("coupon");
                StartActivityForResult(NearITUIBindings.GetInstance(this)
                                       .CreateCouponDetailIntentBuilder(coupon)
                                       .Build(), NEAR_CONTENT_REQUEST);
            }
            else if(type.Equals("couponList"))
            {
                StartActivityForResult(NearITUIBindings.GetInstance(this)
                                                       .CreateCouponListIntentBuilder()
                                                       .Build(), NEAR_CONTENT_REQUEST);
            }
            else if (type.Equals("feedback"))
            {
                Feedback feedback = (Feedback)intent.GetParcelableExtra("feedback");
                StartActivityForResult(NearITUIBindings.GetInstance(this)
                                                       .CreateFeedbackIntentBuilder(feedback)
                                                       .Build(), NEAR_CONTENT_REQUEST);
            }
            else if (type.Equals("content"))
            {
                Content content = (Content)intent.GetParcelableExtra("content");
                StartActivityForResult(NearITUIBindings.GetInstance(this)
                                                       .CreateContentDetailIntentBuilder(content)
                                                       .Build(), NEAR_CONTENT_REQUEST);
            }

        }




        // Methods from PCL

        public void PermissionTypeFromPCL(string mode, Action<int> result)
        {
            resultHandler = result;
            OurUIPermissions(mode);
        }

        public void CouponTypeFromPCL(XCCouponNotification coupon)
        {
            Coupon NCoupon = new Coupon();
            NCoupon = Adapter.AdapterCoupon.GetNativeType(coupon);
            OurUICoupon(NCoupon);
        }

        public void ContentTypeFromPCL(XCContentNotification content)
        {
            Content NContent = new Content();
            NContent = Adapter.AdapterContent.GetNativeType(content);
            OurUIContent(NContent);
        }

        public void FeedbackTypeFromPCL(XCFeedbackNotification feedback)
        {
            Feedback NFeedback = new Feedback();
            NFeedback = Adapter.AdapterFeedback.GetNativeType(feedback);
            OurUIFeedback(NFeedback);
        }

        public void CouponListTypeFromPCL()
        {
            OurUICouponList();
        }



        // Methods from the native fragment

        public static void UINoBluetoothPermission(Action<int> result)      //only location
        {
            resultHandler = result;
            OurUIPermissions(Global.LOCATION_MODE);
        }

        public static void UIPermission(Action<int> result)       //mode = LOCATION + BLUETOOTH
        {
            resultHandler = result;
            OurUIPermissions(Global.DEFAULT_PERMISSIONS_MODE);
        }

        public static void UIValidCoupon(XCCouponNotification coupon)
        {
            Coupon NCoupon = new Coupon();
            NCoupon = Adapter.AdapterCoupon.GetNativeType(coupon);
            OurUICoupon(NCoupon);
        }

        public static void UIInactiveCoupon(XCCouponNotification coupon)
        {
            Coupon NCoupon = new Coupon();
            NCoupon = Adapter.AdapterCoupon.GetNativeType(coupon);
            OurUICoupon(NCoupon);
        }

        public static void UIExpiredCoupon(XCCouponNotification coupon)
        {
            Coupon NCoupon = new Coupon();
            NCoupon = Adapter.AdapterCoupon.GetNativeType(coupon);
            OurUICoupon(NCoupon);
        }

        public static void UIContent(XCContentNotification content)
        {
            Content NContent = new Content();
            NContent = Adapter.AdapterContent.GetNativeType(content);
            OurUIContent(NContent);
        }

        public static void UIFeedback(XCFeedbackNotification feedback)
        {
            Feedback NFeedback = new Feedback();
            NFeedback = Adapter.AdapterFeedback.GetNativeType(feedback);
            OurUIFeedback(NFeedback);
        }

        public static void UICouponList()
        {
            OurUICouponList();
        }

        public interface IPermissionResultHandler
        {
            void OnSuccess();
            void OnFailure();
        }




        // Our private methods

        private static void OurUIPermissions(string mode)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("mode", mode);
            intent.SetAction("permissions");

            (Forms.Context).StartActivity(intent);
        }

        private static void OurUICoupon(Coupon coupon)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("coupon", coupon);
            intent.SetAction("coupon");

            (Forms.Context).StartActivity(intent);
        }

        private static void OurUICouponList()
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.SetAction("couponList");

            (Forms.Context).StartActivity(intent);
        }

        private static void OurUIContent(Content content)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("content", content);
            intent.SetAction("content");

            (Forms.Context).StartActivity(intent);
        }

        private static void OurUIFeedback(Feedback feedback)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("feedback", feedback);
            intent.SetAction("feedback");

            (Forms.Context).StartActivity(intent);
        }





        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == NEAR_PERMISSION_REQUEST)
            {
                if (resultHandler != null)
                {
                    if (resultCode == Result.Ok)
                    {
                        resultHandler.Invoke(0);
                    }
                    else
                    {
                        resultHandler.Invoke(1);
                    }
                    resultHandler = null;
                }
            }
            Finish();
        }
    }
}