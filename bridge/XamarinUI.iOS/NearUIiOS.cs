using System;
using NearIT;
using UIKit;
using Xamarin.Forms;
using XamarinBridge.PCL.Types;
using XamarinUI.Interfaces;
using XamarinUI.iOS.Adapter;

[assembly: Dependency(typeof(XamarinUI.iOS.NearUIiOS))]
namespace XamarinUI.iOS
{
    public enum iOSCouponListFilterOption
    {
        All = 0,
        Valid = 1,
        Expired = 2,
        Disabled = 3,
        ValidAndExpired = 4,
        ValidAndDisabled = 5,
        ExpiredAndDisabled = 6
    }

    public partial class NearUIiOS : UIViewController, IManager
    {
        private static Action<int> resultHandler;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        //METHODS FROM PCL

        public void PermissionTypeFromPCL(string mode, Action<int> result)
        {
            resultHandler = result;
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

        public void FeedbackTypeFromPCL(XCFeedbackNotification feedback, bool comment)
        {
            OurUIFeedback(AdapterFeedback.GetNativeType(feedback), comment);
        }

        public void CouponListTypeFromPCL(bool includeRedeemed, int option)
        {
            OurUICouponList(includeRedeemed, option);
        }




        // STATIC METHODS


        //Permissions
        public static void UIPermission(Action<int> result)       //mode = LOCATION + BLUETOOTH
        {
            resultHandler = result;
            OurUIPermissions(Global.DEFAULT_PERMISSIONS_MODE);
        }

        public static void UIOnlyLocation(Action<int> result)      //only location
        {
            resultHandler = result;
            OurUIPermissions(Global.LOCATION_MODE);
        }


        //Coupon

        public static void UICoupon(NITCoupon coupon)
        {
            OurUICoupon(coupon);
        }

        public static void UICoupon(NITCoupon coupon, UIImage iconPlaceHolder)
        {
            OurUICoupon(coupon, iconPlaceHolder);
        }

        public static void UICoupon(NITCoupon coupon, UINavigationController navigationController)
        {
            OurUICoupon(coupon, navigationController);
        }

        public static void UICoupon(NITCoupon coupon, UIImage iconPlaceHolder, UINavigationController navigationController)
        {
            OurUICoupon(coupon, iconPlaceHolder, navigationController);
        }


        //Content

        public static void UIContent(NITContent content)
        {
            OurUIContent(content);
        }

        public static void UIContent(NITContent content, UINavigationController navigationController)
        {
            OurUIContent(content, navigationController);
        }


        //Feedback

        public static void UIFeedback(NITFeedback feedback)
        {
            OurUIFeedback(feedback, true);
        }

        public static void UIFeedback(NITFeedback feedback, bool comment)
        {
            OurUIFeedback(feedback, comment);
        }


        //CouponList

        public static void UICouponList()
        {
            iOSCouponListFilterOption option = iOSCouponListFilterOption.All;
            int optionFilter = (int)option;
            OurUICouponList(false, optionFilter);
        }

        public static void UICouponList(bool includeRedeemed)
        {
            iOSCouponListFilterOption option = iOSCouponListFilterOption.All;
            int optionFilter = (int)option;
            OurUICouponList(includeRedeemed, optionFilter);
        }

        public static void UICouponList(iOSCouponListFilterOption option)
        {
            int optionFilter = (int)option;
            OurUICouponList(false, optionFilter);
        }

        public static void UICouponList(UINavigationController navigationController)
        {
            CouponListFilterOption option = CouponListFilterOption.All;
            int optionFilter = (int)option;
            OurUICouponList(false, optionFilter, navigationController);
        }

        public static void UICouponList(iOSCouponListFilterOption option, UINavigationController navigationController)
        {
            int optionFilter = (int)option;
            OurUICouponList(false, optionFilter, navigationController);
        }

        public static void UICouponList(bool includeRedeemed, UINavigationController navigationController)
        {
            CouponListFilterOption option = CouponListFilterOption.All;
            int optionFilter = (int)option;
            OurUICouponList(includeRedeemed, optionFilter, navigationController);
        }

        public static void UICouponList(bool includeRedeemed, iOSCouponListFilterOption option)
        {
            int optionFilter = (int)option;
            OurUICouponList(includeRedeemed, optionFilter);
        }

        public static void UICouponList(bool includeRedeemed, iOSCouponListFilterOption option, UINavigationController navigationController)
        {
            int optionFilter = (int)option;
            OurUICouponList(includeRedeemed, optionFilter, navigationController);
        }


        //Permission Handler

        public interface IPermissionResultHandler
        {
            void OnSuccess();
            void OnFailure();
        }




        // PRIVATE METHODS

        //permissions

        private static void OurUIPermissions(string mode)
        {
            Switcher.PermissionsClass.SwitchMode(mode);
        }

        //coupon

        private static void OurUICoupon(NITCoupon coupon)
        {
            NITCouponViewController Coupon = new NITCouponViewController(coupon);
            Coupon.Show();
        }

        private static void OurUICoupon(NITCoupon coupon, UIImage placeHolder)
        {
            NITCouponViewController Coupon = new NITCouponViewController(coupon);
            Coupon.IconPlaceholder = placeHolder;
            Coupon.Show();
        }

        private static void OurUICoupon(NITCoupon coupon, UINavigationController navigationController)
        {
            NITCouponViewController Coupon = new NITCouponViewController(coupon);
            Coupon.ShowWithNavigationController(navigationController);
        }

        private static void OurUICoupon(NITCoupon coupon, UIImage placeHolder, UINavigationController navigationController)
        {
            NITCouponViewController Coupon = new NITCouponViewController(coupon);
            Coupon.IconPlaceholder = placeHolder;
            Coupon.ShowWithNavigationController(navigationController);
        }


        //coupon list

        private static void OurUICouponList(bool includeRedeemed, int option)
        {
            NITCouponListViewController CouponList = new NITCouponListViewController();
            Switcher.CouponListClass.SwitchMode(CouponList, includeRedeemed, option);
        }

        private static void OurUICouponList(UINavigationController navigationController)
        {
            CouponListFilterOption option = CouponListFilterOption.All;
            int optionFilter = (int)option;

            NITCouponListViewController CouponList = new NITCouponListViewController();
            Switcher.CouponListClass.SwitchMode(CouponList, false, optionFilter, navigationController);
        }

        private static void OurUICouponList(bool includeRedeemed, int option, UINavigationController navigationController)
        {
            NITCouponListViewController CouponList = new NITCouponListViewController();
            Switcher.CouponListClass.SwitchMode(CouponList, includeRedeemed, option, navigationController);
        }


        //content

        private static void OurUIContent(NITContent content)
        {
            NITContentViewController Content = new NITContentViewController(content);
            Content.Show();
        }

        private static void OurUIContent(NITContent content, UINavigationController navigationController)
        {
            NITContentViewController Content = new NITContentViewController(content);
            Content.ShowWithNavigationController(navigationController);
        }


        //feedback

        private static void OurUIFeedback(NITFeedback feedback, bool comment)
        {
            NITFeedbackViewController Feedback = new NITFeedbackViewController(feedback);

            if (comment == false) Feedback.CommentVisibility = NITFeedbackCommentVisibility.Hidden;

            Feedback.Show();
        }

    }
}

