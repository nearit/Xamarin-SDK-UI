using System;
using XamarinUI.Interfaces;
using Xamarin.Forms;
using XamarinBridge.PCL.Types;

namespace XamarinUI
{
    public class NearUIPCL
    {
        public static void UIPermission(string mode)       //mode = LOCATION + BLUETOOTH, ...
        {
            DependencyService.Get<IManager>().PermissionTypeFromPCL(mode);
        }

        public static void UICoupon(string mode, XCCouponNotification coupon)
        {
            DependencyService.Get<IManager>().CouponTypeFromPCL(mode, coupon);
        }

        public static void UIContent(string mode, XCContentNotification content)
        {
            DependencyService.Get<IManager>().ContentTypeFromPCL(mode, content);
        }

        public static void UIFeedback(string mode, XCFeedbackNotification feedback)
        {
            DependencyService.Get<IManager>().FeedbackTypeFromPCL(mode, feedback);
        }
    }
}
