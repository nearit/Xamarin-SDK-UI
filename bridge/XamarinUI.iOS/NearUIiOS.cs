using System;
using NearIT;
using NearUI;
using UIKit;
using Xamarin.Forms;
using XamarinBridge.PCL.Types;
using XamarinUI.Interfaces;
using XamarinUI.iOS.Adapter;

[assembly: Dependency(typeof(XamarinUI.iOS.NearUIiOS))]
namespace XamarinUI.iOS
{
    public partial class NearUIiOS : UIViewController, IManager
    {
        private static Action<int> resultHandler;

        public override void ViewDidLoad()
        {
            System.Diagnostics.Debug.WriteLine("ViewDidLoad");

            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }




        public void PermissionTypeFromPCL(string mode, Action<int> result)
        {
            resultHandler = result;
            Switcher.PermissionsClass.SwitchMode(mode);
            OurUIPermissions(mode);
        }

        public void CouponTypeFromPCL(XCCouponNotification coupon)
        {
            OurUICoupon(AdapterCoupon.GetNativeType(coupon));
        }

        public void ContentTypeFromPCL(XCContentNotification content)
        {
            OurUIContent(AdapterContent.GetNativeType(content));
        }

        public void FeedbackTypeFromPCL(XCFeedbackNotification feedback)
        {
            OurUIFeedback(AdapterFeedback.GetNativeType(feedback));
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
            NITCoupon NCoupon = new NITCoupon();
            NCoupon = AdapterCoupon.GetNativeType(coupon);
            OurUICoupon(NCoupon);
        }

        public static void UIInactiveCoupon(XCCouponNotification coupon)
        {
            NITCoupon NCoupon = new NITCoupon();
            NCoupon = AdapterCoupon.GetNativeType(coupon);
            OurUICoupon(NCoupon);
        }

        public static void UIExpiredCoupon(XCCouponNotification coupon)
        {
            NITCoupon NCoupon = new NITCoupon();
            NCoupon = AdapterCoupon.GetNativeType(coupon);
            OurUICoupon(NCoupon);
        }

        public static void UIContent(XCContentNotification content)
        {
            NITContent NContent = new NITContent();
            NContent = AdapterContent.GetNativeType(content);
            OurUIContent(NContent);
        }

        public static void UIFeedback(XCFeedbackNotification feedback)
        {
            NITFeedback NFeedback = new NITFeedback();
            NFeedback = AdapterFeedback.GetNativeType(feedback);
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
            
        }

        private static void OurUICoupon(NITCoupon coupon)
        {
            NITCouponViewController Coupon = new NITCouponViewController(coupon);
            Coupon.Show();
        }

        private static void OurUICouponList()
        {
            NITCouponListViewController CouponList = new NITCouponListViewController();
            CouponList.Show();
        }

        private static void OurUIContent(NITContent content)
        {
            NITContentViewController Content = new NITContentViewController(content);
            Content.Show();
        }

        private static void OurUIFeedback(NITFeedback feedback)
        {
            NITFeedbackViewController Feedback = new NITFeedbackViewController(feedback);
            Feedback.Show();
        }

    }
}

