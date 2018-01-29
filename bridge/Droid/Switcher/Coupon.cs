using System;
using Android.Content;
using Com.Nearit.Ui_bindings;
using IT.Near.Sdk.Reactions.Couponplugin.Model;

namespace XamarinUI.Droid.Switcher
{
    public class CouponClass
    {
        public static Intent SwitchMode(Context context, Coupon coupon, int placeHolder, bool tapOutside)
        {
            if (tapOutside == true)
            {
                if (placeHolder.Equals(0))
                {
                    return NearITUIBindings.GetInstance(context)
                                           .CreateCouponDetailIntentBuilder(coupon)
                                           .EnableTapOutsideToClose()
                                           .Build();
                }
                else
                {
                    return NearITUIBindings.GetInstance(context)
                                           .CreateCouponDetailIntentBuilder(coupon)
                                           .SetIconPlaceholderResourceId(placeHolder)
                                           .EnableTapOutsideToClose()
                                           .Build();
                }
            }
            else    //without UI
            {
                if (placeHolder.Equals(0))
                {
                    return NearITUIBindings.GetInstance(context)
                                           .CreateCouponDetailIntentBuilder(coupon)
                                           .Build();
                }
                else
                {
                    return NearITUIBindings.GetInstance(context)
                                           .CreateCouponDetailIntentBuilder(coupon)
                                           .SetIconPlaceholderResourceId(placeHolder)
                                           .Build();
                }
            }
        }
    }
}
