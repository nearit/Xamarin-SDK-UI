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
        private static bool TAP_OUTSIDE_TO_CLOSE = false;


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

            if(type.Equals("permissions"))
            {
                var layoutUI = intent.GetBooleanExtra("layoutUI", true);
                StartActivityForResult(Switcher.PermissionsClass.SwitchMode(this, mode, layoutUI, TAP_OUTSIDE_TO_CLOSE), NEAR_PERMISSION_REQUEST);
            }


            else if(type.Equals("coupon"))
            {
                var placeHolder = intent.GetIntExtra("placeHolder", 0);
                Coupon coupon = (Coupon)intent.GetParcelableExtra("coupon");
                StartActivityForResult(Switcher.CouponClass.SwitchMode(this, coupon, placeHolder, TAP_OUTSIDE_TO_CLOSE), NEAR_CONTENT_REQUEST);
            }


            else if(type.Equals("couponList"))
            {
                var includeRedeemed = intent.GetBooleanExtra("includeRedeemed", false);
                var filterOption = intent.GetIntExtra("filterOption", 0);

                StartActivityForResult(Switcher.CouponListClass.SwitchMode(this, includeRedeemed, filterOption), NEAR_CONTENT_REQUEST);
            }


            else if (type.Equals("feedback"))
            {
                var comment = intent.GetBooleanExtra("comment", true);
                Feedback feedback = (Feedback)intent.GetParcelableExtra("feedback");
                StartActivityForResult(Switcher.FeedbackClass.SwitchMode(this, feedback, comment, TAP_OUTSIDE_TO_CLOSE), NEAR_CONTENT_REQUEST);
            }


            else if (type.Equals("content"))
            {
                Content content = (Content)intent.GetParcelableExtra("content");
                if(TAP_OUTSIDE_TO_CLOSE == true) StartActivityForResult(NearITUIBindings.GetInstance(this)
                                                       .CreateContentDetailIntentBuilder(content)
                                                       .EnableTapOutsideToClose()
                                                       .Build(), NEAR_CONTENT_REQUEST);
                
                else StartActivityForResult(NearITUIBindings.GetInstance(this)
                                                       .CreateContentDetailIntentBuilder(content)
                                                       .Build(), NEAR_CONTENT_REQUEST);
            }

        }




        // Methods from PCL

        public void PermissionTypeFromPCL(string mode, Action<int> result)
        {
            resultHandler = result;
            OurUIPermissions(mode, true);
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

        public void FeedbackTypeFromPCL(XCFeedbackNotification feedback, bool comment)
        {
            Feedback NFeedback = new Feedback();
            NFeedback = Adapter.AdapterFeedback.GetNativeType(feedback);
            OurUIFeedback(NFeedback, comment);
        }

        public void CouponListTypeFromPCL(bool includeRedeemed, int option)
        {
            OurUICouponList(includeRedeemed, option);
        }



        // Methods from the native fragment


        //Enable tapoutsidetoclose
        public static void UIEnableTapOutsideToClose()
        {
            TAP_OUTSIDE_TO_CLOSE = true;
        }


        //Permissions
        public static void UIOnlyLocation(Action<int> result)      //only location
        {
            resultHandler = result;
            OurUIPermissions(Global.LOCATION_MODE, true);
        }

        public static void UIOnlyLocation(Action<int> result, bool layoutUI)      //only location
        {
            resultHandler = result;
            OurUIPermissions(Global.LOCATION_MODE, layoutUI);
        }

        public static void UIPermission(Action<int> result)       //mode = LOCATION + BLUETOOTH
        {
            resultHandler = result;
            OurUIPermissions(Global.DEFAULT_PERMISSIONS_MODE, true);
        }

        public static void UIPermission(Action<int> result, bool layoutUI)       //mode = LOCATION + BLUETOOTH
        {
            resultHandler = result;
            OurUIPermissions(Global.DEFAULT_PERMISSIONS_MODE, layoutUI);
        }


        //Coupon

        public static void UICoupon(Coupon coupon)
        {
            OurUICoupon(coupon);
        }

        public static void UICoupon(Coupon coupon, int iconPlaceHolder)
        {
            OurUICoupon(coupon, iconPlaceHolder);
        }


        //Content

        public static void UIContent(Content content)
        {
            OurUIContent(content);
        }


        //Feedback

        public static void UIFeedback(Feedback feedback)
        {
            OurUIFeedback(feedback, true);
        }

        public static void UIFeedback(Feedback feedback, bool comment)
        {
            OurUIFeedback(feedback, comment);
        }


        //CouponList

        public static void UICouponList()
        {
            int optionFilter = (int)AndroidCouponListFilterOption.All;
            OurUICouponList(false, optionFilter);
        }

        public static void UICouponList(AndroidCouponListFilterOption option)
        {
            int optionFilter = (int)option;
            OurUICouponList(false, optionFilter);
        }

        public static void UICouponList(bool includeRedeemed, AndroidCouponListFilterOption option)
        {
            int optionFilter = (int)option;
            OurUICouponList(includeRedeemed, optionFilter);
        }

        public interface IPermissionResultHandler
        {
            void OnSuccess();
            void OnFailure();
        }






        // Our private methods

        private static void OurUIPermissions(string mode, bool layoutUI)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("mode", mode);
            intent.PutExtra("layoutUI", layoutUI);
            intent.SetAction("permissions");

            (Forms.Context).StartActivity(intent);
        }

        private static void OurUICoupon(Coupon coupon)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("coupon", coupon);
            intent.PutExtra("placeHolder", 0);
            intent.SetAction("coupon");

            (Forms.Context).StartActivity(intent);
        }

        private static void OurUICoupon(Coupon coupon, int placeHolder)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("coupon", coupon);
            intent.PutExtra("placeHolder", placeHolder);
            intent.SetAction("coupon");

            (Forms.Context).StartActivity(intent);
        }

        private static void OurUICouponList(bool includeRedeemed, int option)
        {
            int filterOption = (int)option;

            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("includeRedeemed", includeRedeemed);
            intent.PutExtra("filterOption", filterOption);
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

        private static void OurUIFeedback(Feedback feedback, bool comment)
        {
            Intent intent = new Intent(Forms.Context, typeof(NearUIDroid));
            intent.PutExtra("feedback", feedback);

            if (comment == false) intent.PutExtra("comment", false);

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