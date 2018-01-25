using System.Collections.Generic;
using System.Collections.ObjectModel;
using SampleUIBindings.Classes;
using XamarinUI;
using Xamarin.Forms;
using XamarinBridge.PCL.Types;

namespace SampleUIBindings
{
    public partial class Sample_UI_BindingsPage : ContentPage
    {
        private ObservableCollection<TypeL> Groups { get; set; }
        string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public Sample_UI_BindingsPage()
        {
            InitializeComponent();

            System.Diagnostics.Debug.WriteLine("Bindings Page");

            Groups = new ObservableCollection<TypeL>();
            var permissionGroup = new TypeL() { LongName = "Permissions" };
            var feedbackGroup = new TypeL() { LongName = "Feedback" };
            var couponGroup = new TypeL() { LongName = "Coupon" };
            var contentGroup = new TypeL() { LongName = "Content" };
            var couponListGroup = new TypeL() { LongName = "Coupon List" };
            //var permissionBarGroup = new TypeL() { LongName = "Permission Bar", ShortName = "PB" };

            permissionGroup.Add(new Typology() { Title = "Default Permissions", Description = "Request permissions for locations and notifications" });
            permissionGroup.Add(new Typology() { Title = "Location Permissions", Description = "Location Only" });

            feedbackGroup.Add(new Typology() { Title = "Default Feedback", Description = "With comment field" });

            couponGroup.Add(new Typology() { Title = "Valid Coupon", Description = "Show qrcode and all informations" });
            couponGroup.Add(new Typology() { Title = "Inactive Coupon", Description = "With remote icon" });
            couponGroup.Add(new Typology() { Title = "Expired Coupon", Description = "Only details" });

            couponListGroup.Add(new Typology() { Title = "Coupon List", Description = "List of your coupons" });

            contentGroup.Add(new Typology() { Title = "Default Content", Description = "A link and text" });
            contentGroup.Add(new Typology() { Title = "Short Content", Description = "Simple list" });

            Groups.Add(permissionGroup);
            Groups.Add(feedbackGroup);
            Groups.Add(couponGroup);
            Groups.Add(contentGroup);
            Groups.Add(couponListGroup);
            //Groups.Add(permissionBarGroup);

            lstView.ItemsSource = Groups;
        }

        void Tap_Handle(object sender, System.EventArgs e)
        {
            var textCell = (TextCell)sender;

            if(textCell.Text == "Default Permissions")
            {
                NearUIPCL.UIPermission((result) => {
                    if (result == 0)
                    {
                        DisplayAlert("Permissions", "granted!", "ok");
                    }
                    else
                    {
                        DisplayAlert("Permissions", "denied", "ok");
                    }
                });
            }
            else if(textCell.Text == "Location Permissions")
            {
                NearUIPCL.UINoBluetoothPermission((result) =>
                {
                    if (result == 0)
                    {
                        DisplayAlert("Permissions", "granted!", "ok");
                    }
                    else
                    {
                        DisplayAlert("Permissions", "denied", "ok");
                    }
                });
            }
            else if(textCell.Text == "Default Feedback")
            {
                XCFeedbackNotification XFeedback = new XCFeedbackNotification();
                XFeedback.NotificationMessage = "Notification Message";
                XFeedback.Question = "Default Feedback Question";
                XFeedback.RecipeId = "cia0";

                NearUIPCL.UIFeedback(XFeedback);
            }
            else if (textCell.Text == "Valid Coupon")
            {
                XCCouponNotification XCoupon = new XCCouponNotification();

                XCoupon.NotificationMessage = "Notification message";
                XCoupon.Description = "Description example for valid coupon";
                XCoupon.RedeemableFrom = "2017-04-01T00:00:00.000Z";
                XCoupon.Value = "100€";
                XCoupon.ExpiresAt = "3017-04-01T00:00:00.000Z";
                XCoupon.Serial = "0123456789";

                NearUIPCL.UIValidCoupon(XCoupon);
            }
            else if (textCell.Text == "Inactive Coupon")
            {
                XCCouponNotification XCoupon = new XCCouponNotification();
                XCoupon.NotificationMessage = "Notification Message";
                XCoupon.Description = "Description example for valid coupon";
                XCoupon.Value = "100€";
                XCoupon.ExpiresAt = "3017-04-01T00:00:00.001Z";
                XCoupon.RedeemableFrom = "3017-04-01T00:00:00.000Z";
                XCoupon.Serial = "0123456789";

                NearUIPCL.UIInactiveCoupon(XCoupon);
            }
            else if (textCell.Text == "Expired Coupon")
            {
                XCCouponNotification XCoupon = new XCCouponNotification();
                XCoupon.NotificationMessage = "Notification Message";
                XCoupon.Description = "Description example for valid coupon";
                XCoupon.Value = "100€";
                XCoupon.ExpiresAt = "2017-04-01T00:00:00.000Z";
                XCoupon.RedeemableFrom = "2017-03-31T00:00:00.000";
                XCoupon.Serial = "0123456789";

                NearUIPCL.UIExpiredCoupon(XCoupon);
            }
            else if (textCell.Text == "Coupon List")
            {
                NearUIPCL.UICouponList();
            }
            else if (textCell.Text == "Default Content")
            {
                XCContentLink XContentLink = new XCContentLink();
                XContentLink.Label = "NearIT";
                XContentLink.Url = "https://www.nearit.com";

                XCImageSet XImage = new XCImageSet();
                XImage.FullSize = "https://www.nearit.com/wp-content/uploads/2017/05/brand@2x.png";
                XImage.SmallSize = "https://www.nearit.com/wp-content/uploads/2017/05/brand@2x.png";

                XCContentNotification XContent = new XCContentNotification();
                XContent.NotificationMessage = "Notification Message";
                XContent.Content = lorem;
                XContent.Title = "Content title";
                XContent.Cta = XContentLink;
                XContent.ImageLink = XImage;

                NearUIPCL.UIContent(XContent);
            }
            else if (textCell.Text == "Short Content")
            {
                XCContentNotification XContent = new XCContentNotification();
                XContent.NotificationMessage = "Notification Message";
                XContent.Title = "Drinks";
                XContent.Content = "<ul><li> Coffee </li><li> Tea </li><li> Milk </li></ul>";

                NearUIPCL.UIContent(XContent);
            }
        }
    }
}
