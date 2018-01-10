using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using IT.Near.Sdk.Reactions.Couponplugin.Model;
using XamarinBridge.PCL.Types;

namespace XamarinUI.Droid.Adapter
{
    public class AdapterCoupon
    {
        public static Coupon GetNativeType(XCCouponNotification XCoupon)
        {
            Coupon NCoupon = new Coupon();

            NCoupon.NotificationMessage = XCoupon.NotificationMessage;
            NCoupon.Description = XCoupon.Description;
            NCoupon.Value = XCoupon.Value;
            NCoupon.ExpiresAt = XCoupon.ExpiresAt;
            NCoupon.RedeemableFrom = XCoupon.RedeemableFrom;

            if(XCoupon.IconSet != null)
            {
                NCoupon.IconSet = new IT.Near.Sdk.Reactions.Contentplugin.Model.ImageSet();
                NCoupon.IconSet.FullSize = XCoupon.IconSet.FullSize;
                NCoupon.IconSet.SmallSize = XCoupon.IconSet.SmallSize;
            }

            NCoupon.Id = XCoupon.Id;

            IList<Claim> Claims = new List<Claim>();
            Claim Claim = new Claim();
            Claim.SerialNumber = XCoupon.Serial;
            Claim.ClaimedAt = XCoupon.ClaimedAt;
            Claim.RedeemedAt = XCoupon.RedeemedAt;
            Claims.Add(Claim);
            NCoupon.Claims = (System.Collections.IList)Claims;

            return NCoupon;
        }


    }
}
