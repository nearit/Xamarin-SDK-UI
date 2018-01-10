using System;
using XamarinBridge.PCL.Types;

namespace XamarinUI.Interfaces
{
    public interface IManager
    {
        void PermissionTypeFromPCL(string mode, Action<int> result);
        void CouponTypeFromPCL(string mode, XCCouponNotification coupon);
        void ContentTypeFromPCL(string mode, XCContentNotification content);
        void FeedbackTypeFromPCL(string mode, XCFeedbackNotification feedback);
        void CouponListTypeFromPCL();
    }
}
