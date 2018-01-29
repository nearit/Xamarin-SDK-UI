using System;
using XamarinBridge.PCL.Types;

namespace SampleUIBindings.Interfaces
{
    public interface IPermissions
    {
        void DefaultPermissions();
        void LocationPermissions();
        void DefaultFeedback(XCFeedbackNotification feedback);
        void Coupon(XCCouponNotification coupon);
        void CouponList();
        void DefaultContent(XCContentNotification content);
    }
}
