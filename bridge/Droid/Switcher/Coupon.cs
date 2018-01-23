using System;
using Com.Nearit.Ui_bindings;
using Android.Content;
using IT.Near.Sdk.Reactions.Couponplugin.Model;
using Android.Widget;

namespace XamarinUI.Droid.Switcher
{
    public class CouponClass
    {
        public static Intent SwitchMode(string mode, Context context, Coupon coupon)
        {
            mode = mode.ToLower();

            if(mode.Equals(Global.INACTIVE_MODE))
            {
                return NearITUIBindings.GetInstance(context)
                                       .CreateCouponDetailIntentBuilder(coupon)
                                       .Build();
            }
            else if(mode.Equals(Global.EXPIRED_MODE))
            {
                return NearITUIBindings.GetInstance(context)
                                       .CreateCouponDetailIntentBuilder(coupon)
                                       .EnableTapOutsideToClose()
                                       .Build();
            }
            else      //valid coupon
            {
                return NearITUIBindings.GetInstance(context)
                                       .CreateCouponDetailIntentBuilder(coupon)
                                       .Build();

            }
        }
    }
}
