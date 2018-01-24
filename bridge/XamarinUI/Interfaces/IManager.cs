using System;
using XamarinBridge.PCL.Types;

namespace XamarinUI.Interfaces
{
    public interface IManager
    {
        void PermissionTypeFromPCL(string mode, Action<int> result);
        void CouponTypeFromPCL(XCCouponNotification coupon);
        void ContentTypeFromPCL(XCContentNotification content);
        void FeedbackTypeFromPCL(XCFeedbackNotification feedback);
        void CouponListTypeFromPCL();
    }
}
