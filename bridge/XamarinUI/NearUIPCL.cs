using System;
using XamarinUI.Interfaces;
using Xamarin.Forms;
using XamarinBridge.PCL.Types;

namespace XamarinUI
{
    public class NearUIPCL
    {
        public static void UINoBluetoothPermission(Action<int> result)      //only location
        {
            DependencyService.Get<IManager>().PermissionTypeFromPCL(Global.LOCATION_MODE, result);
        }

        public static void UIPermission(Action<int> result)       //mode = LOCATION + BLUETOOTH
        {
            DependencyService.Get<IManager>().PermissionTypeFromPCL(Global.DEFAULT_PERMISSIONS_MODE, result);
        }

        public static void UIValidCoupon(XCCouponNotification coupon)
        {
            DependencyService.Get<IManager>().CouponTypeFromPCL(Global.VALID_MODE, coupon);
        }

        public static void UIInactiveCoupon(XCCouponNotification coupon)
        {
            DependencyService.Get<IManager>().CouponTypeFromPCL(Global.INACTIVE_MODE, coupon);
        }

        public static void UIExpiredCoupon(XCCouponNotification coupon)
        {
            DependencyService.Get<IManager>().CouponTypeFromPCL(Global.EXPIRED_MODE, coupon);
        }

        public static void UIContent(XCContentNotification content)
        {
            DependencyService.Get<IManager>().ContentTypeFromPCL(Global.DEFAULT_CONTENT_MODE, content);
        }

        public static void UIFeedback(XCFeedbackNotification feedback)
        {
            DependencyService.Get<IManager>().FeedbackTypeFromPCL(Global.DEFAULT_FEEDBACK_MODE, feedback);
        }

        public static void UICouponList()
        {
            DependencyService.Get<IManager>().CouponListTypeFromPCL();
        }
    }
}
