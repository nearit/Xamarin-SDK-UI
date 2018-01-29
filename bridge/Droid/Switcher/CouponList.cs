using System;
using Android.Content;
using Com.Nearit.Ui_bindings;
using Xamarin.Forms;
using Android.Widget;

namespace XamarinUI.Droid.Switcher
{
    public class CouponListClass
    {
        public static Intent SwitchMode(Context context, bool includeRedeemed, int filterOption)
        {
            if(includeRedeemed == false)        //without reedmed coupon
            {
                switch (filterOption)
                {
                    case 0:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .Build();
                    case 1:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyValidCoupons()
                                               .Build();
                    case 2:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyExpiredCoupons()
                                               .Build();
                    case 3:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyInactiveCoupons()
                                               .Build();
                    /*case 4:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyValidCoupons()
                                               .OnlyExpiredCoupons()
                                               .Build();
                    case 5:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyValidCoupons()
                                               .OnlyInactiveCoupons()
                                               .Build();
                    case 6:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyExpiredCoupons()
                                               .OnlyInactiveCoupons()
                                               .Build();*/
                    default:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .Build();
                }
            }
            else
            {
                switch (filterOption)
                {
                    case 0:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .IncludeRedeemed()
                                               .Build();
                    case 1:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyValidCoupons()
                                               .IncludeRedeemed()
                                               .Build();
                    case 2:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyExpiredCoupons()
                                               .IncludeRedeemed()
                                               .Build();
                    case 3:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyInactiveCoupons()
                                               .IncludeRedeemed()
                                               .Build();
                    /*case 4:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyValidCoupons()
                                               .OnlyExpiredCoupons()
                                               .IncludeRedeemed()
                                               .Build();
                    case 5:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyValidCoupons()
                                               .OnlyInactiveCoupons()
                                               .IncludeRedeemed()
                                               .Build();
                    case 6:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .OnlyExpiredCoupons()
                                               .OnlyInactiveCoupons()
                                               .IncludeRedeemed()
                                               .Build();*/

                    default:
                        return NearITUIBindings.GetInstance(context)
                                               .CreateCouponListIntentBuilder()
                                               .IncludeRedeemed()
                                               .Build();
                }
            }


        }
    }
}
