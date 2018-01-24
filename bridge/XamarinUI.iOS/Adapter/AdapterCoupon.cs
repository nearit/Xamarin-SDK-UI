using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Foundation;
using NearIT;
using XamarinBridge.PCL.Types;

namespace XamarinUI.iOS.Adapter
{
    public class AdapterCoupon
    {
        public static NITCoupon GetNativeType(XCCouponNotification XCoupon)
        {
            NITCoupon NCoupon = new NITCoupon();

            NCoupon.NotificationMessage = XCoupon.NotificationMessage;
            NCoupon.CouponDescription = XCoupon.Description;
            NCoupon.Value = XCoupon.Value;
            NCoupon.ExpiresAt = XCoupon.ExpiresAt;
            NCoupon.RedeemableFrom = XCoupon.RedeemableFrom;

            if(XCoupon.IconSet != null)
            {
                NCoupon.Icon = new NITImage();
                NCoupon.Icon.Image = From(XCoupon.IconSet);
            }

            NCoupon.ID = XCoupon.Id;

            var claims = new NITClaim[1];
            NITClaim Claim = new NITClaim();

            Claim.SerialNumber = XCoupon.Serial;

            if (XCoupon.ClaimedAt != null)
            {
                Claim.ClaimedAt = XCoupon.ClaimedAt;
            }

            Claim.RedeemedAt = XCoupon.RedeemedAt;

            claims[0] = Claim;

            NCoupon.Claims = claims;
            System.Diagnostics.Debug.WriteLine(NCoupon.Claims[0].SerialNumber);

            return NCoupon;
        }


        private static NSDictionary<NSString, NSObject> From(XCImageSet IconSet)
        {
            var Keys = new NSString[2];
            var Obj = new NSObject[2];

            Keys[0] = (Foundation.NSString)"square_300";
            Keys[1] = (Foundation.NSString)"url";

            Obj[0] = NSString.FromObject(IconSet.SmallSize);
            Obj[1] = NSString.FromObject(IconSet.FullSize);

            NSDictionary<NSString, NSObject> image = new NSDictionary<NSString, NSObject>(Keys, Obj);
            return image;
        }


    }
}
