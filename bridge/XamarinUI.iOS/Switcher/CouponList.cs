using System;
using NearIT;
using UIKit;
using Xamarin.Forms;

namespace XamarinUI.iOS.Switcher
{
    public class CouponListClass
    {
        public static void SwitchMode(NITCouponListViewController CouponList, bool includeRedeemed, int filterOption)
        {
            if(includeRedeemed == false)        //without reedmed coupon
            {
                CouponList.FilterRedeemed = NITCouponListViewControllerFilterRedeemed.Hide;
                switch (filterOption)
                {
                    case 0:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.All;
                        CouponList.Show();
                        break;
                    case 1:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Valid;
                        CouponList.Show();
                        break;
                    case 2:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Expired;
                        CouponList.Show();
                        break;
                    case 3:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Disabled;
                        CouponList.Show();
                        break;
                    case 4:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ValidAndExpired;
                        CouponList.Show();
                        break;
                    case 5:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ValidAndDisabled;
                        CouponList.Show();
                        break;
                    case 6:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ExpiredAndDisabled;
                        CouponList.Show();
                        break;
                    default:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.All;
                        CouponList.Show();
                        break;
                }
            }
            else
            {
                CouponList.FilterRedeemed = NITCouponListViewControllerFilterRedeemed.Show;
                switch (filterOption)
                {
                    case 0:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.All;
                        CouponList.Show();
                        break;
                    case 1:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Valid;
                        CouponList.Show();
                        break;
                    case 2:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Expired;
                        CouponList.Show();
                        break;
                    case 3:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Disabled;
                        CouponList.Show();
                        break;
                    case 4:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ValidAndExpired;
                        CouponList.Show();
                        break;
                    case 5:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ValidAndDisabled;
                        CouponList.Show();
                        break;
                    case 6:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ExpiredAndDisabled;
                        CouponList.Show();
                        break;
                    default:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.All;
                        CouponList.Show();
                        break;
                }
            }


        }

        public static void SwitchMode(NITCouponListViewController CouponList, bool includeRedeemed, int filterOption, UINavigationController navigationController)
        {
            if (includeRedeemed == false)
            {
                CouponList.FilterRedeemed = NITCouponListViewControllerFilterRedeemed.Hide;
                switch (filterOption)
                {
                    case 0:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.All;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 1:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Valid;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 2:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Expired;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 3:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Disabled;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 4:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ValidAndExpired;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 5:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ValidAndDisabled;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 6:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ExpiredAndDisabled;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    default:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.All;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                }
            }
            else        //with reedmed coupon
            {
                CouponList.FilterRedeemed = NITCouponListViewControllerFilterRedeemed.Show;
                switch (filterOption)
                {
                    case 0:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.All;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 1:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Valid;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 2:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Expired;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 3:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.Disabled;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 4:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ValidAndExpired;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 5:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ValidAndDisabled;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    case 6:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.ExpiredAndDisabled;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                    default:
                        CouponList.FilterOption = NITCouponListViewControllerFilterOptions.All;
                        CouponList.ShowWithNavigationController(navigationController);
                        break;
                }
            }


        }
    }
}