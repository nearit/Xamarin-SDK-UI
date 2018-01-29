using System;
using XamarinUI.Interfaces;
using Xamarin.Forms;
using XamarinBridge.PCL.Types;

namespace XamarinUI
{
    public enum iOSCouponListFilterOption
    {
        All = 0,
        Valid = 1,
        Expired = 2,
        ValidAndExpired = 3,
        Disabled = 4,
        ValidAndDisabled = 5,
        ExpiredAndDisabled = 6
    }

    public enum AndroidCouponListFilterOption
    {
        All = 0,
        Valid = 1,
        Expired = 2,
        Disabled = 4,
    }

    public class NearUIPCL
    {

        public iOSCouponListFilterOption iOSFilterOption { get; set; }
        public AndroidCouponListFilterOption AndroidFilterOption { get; set; }


        //Permissions

        public static void UIOnlyLocation(Action<int> result)      //only location
        {
            DependencyService.Get<IManager>().PermissionTypeFromPCL(Global.LOCATION_MODE, result);
        }

        public static void UIPermission(Action<int> result)       //mode = LOCATION + BLUETOOTH
        {
            DependencyService.Get<IManager>().PermissionTypeFromPCL(Global.DEFAULT_PERMISSIONS_MODE, result);
        }


        //Coupon

        public static void UICoupon(XCCouponNotification coupon)
        {
            DependencyService.Get<IManager>().CouponTypeFromPCL(coupon);
        }


        //Content

        public static void UIContent(XCContentNotification content)
        {
            DependencyService.Get<IManager>().ContentTypeFromPCL(content);
        }


        //Feedback

        public static void UIFeedback(XCFeedbackNotification feedback)
        {
            DependencyService.Get<IManager>().FeedbackTypeFromPCL(feedback, true);
        }

        public static void UIFeedback(XCFeedbackNotification feedback, bool comment)
        {
            DependencyService.Get<IManager>().FeedbackTypeFromPCL(feedback, comment);
        }


        //CouponList

        public static void UICouponList()
        {
            DependencyService.Get<IManager>().CouponListTypeFromPCL(false, 0);
        }

        public static void UICouponList(iOSCouponListFilterOption option)
        {
            int optionFilter = (int)option;
            DependencyService.Get<IManager>().CouponListTypeFromPCL(false, optionFilter);
        }

        public static void UICouponList(AndroidCouponListFilterOption option)
        {
            int optionFilter = (int)option;
            DependencyService.Get<IManager>().CouponListTypeFromPCL(false, optionFilter);
        }

        public static void UICouponList(bool includeRedeemed, iOSCouponListFilterOption option)
        {
            int optionFilter = (int)option;
            DependencyService.Get<IManager>().CouponListTypeFromPCL(includeRedeemed, optionFilter);
        }

        public static void UICouponList(bool includeRedeemed, AndroidCouponListFilterOption option)
        {
            int optionFilter = (int)option;
            DependencyService.Get<IManager>().CouponListTypeFromPCL(includeRedeemed, optionFilter);
        }
    }
}
