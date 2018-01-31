using System;
using Foundation;
using NearIT;
using SampleUIBindings.Interfaces;
using UIKit;
using Xamarin.Forms;
using XamarinBridge.PCL.Types;
using XamarinUI.iOS;
using XamarinUI.iOS.Adapter;

[assembly: Dependency(typeof(SampleUIBindings.iOS.MyViewController))]
namespace SampleUIBindings.iOS
{
    public partial class MyViewController : UIViewController, IPermissions
    {
        public MyViewController() : base("MyViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }





        public void DefaultPermissions()
        {
            var vc = new NITPermissionsViewController();
            vc.HeaderImage = FromUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Cara_Delevingne_by_Gage_Skidmore.jpg/1200px-Cara_Delevingne_by_Gage_Skidmore.jpg");
            vc.TextColor = UIColor.Blue;
            vc.IsEnableTapToClose = true;
            vc.UnknownButton = FromUrl("https://www.w3schools.com/howto/img_fjords.jpg");
            vc.GrantedButton = FromUrl("https://static.pexels.com/photos/248797/pexels-photo-248797.jpeg");
            //vc.GrantedIcon = FromUrl("http://keenthemes.com/preview/metronic/theme/assets/global/plugins/jcrop/demos/demo_files/image1.jpg");
            vc.LocationText = "Turn on location";
            vc.NotificationsText = "Turn on notications";
            vc.ExplainText = "We'll notify you of content that's interesting";
            vc.AutoCloseDialog = NITPermissionsAutoCloseDialog.ff;
            vc.Show();
            /*
            NearUIiOS.UIPermission((obj) => 
            {
                
            });*/
        }

        public void LocationPermissions()
        {
            NearUIiOS.UIOnlyLocation((obj) => {
                
            });
        }

        public void DefaultFeedback(XCFeedbackNotification feedback)
        {
            var vc = new NITFeedbackViewController(AdapterFeedback.GetNativeType(feedback));
            vc.SendButton = FromUrl("https://www.w3schools.com/howto/img_fjords.jpg");
            //vc.RateEmptyButton = FromUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Cara_Delevingne_by_Gage_Skidmore.jpg/1200px-Cara_Delevingne_by_Gage_Skidmore.jpg");
            vc.RateFullButton = FromUrl("https://static.pexels.com/photos/248797/pexels-photo-248797.jpeg");
            vc.CommentDescriptionText = "Anything to say?";
            vc.CloseText = "Not interested";
            vc.SendText = "Rate";
            vc.TextColor = UIColor.Blue;
            vc.OkText = "Thank you for taking the time to provide us with your feedback.\n\nYour feedback is important to us and we will endeavour to respond to your feedback within 100 working days.\n\nIf your feedback is of an urgent nature, you can contact the Developer on +800HackerMenn";
            vc.TextFont = UIFont.BoldSystemFontOfSize(15);
            vc.ErrorFont = UIFont.BoldSystemFontOfSize(20);
            vc.DisappearTime = 2.0;
            vc.Show();

            //NearUIiOS.UIFeedback(AdapterFeedback.GetNativeType(feedback), false);
        }

        public void Coupon(XCCouponNotification coupon)
        {
            var vc = new NITCouponViewController(AdapterCoupon.GetNativeType(coupon));
            //vc.SeparatorImage = FromUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Cara_Delevingne_by_Gage_Skidmore.jpg/1200px-Cara_Delevingne_by_Gage_Skidmore.jpg");
            vc.SeparatorBackgroundColor = UIColor.Black;
            vc.CouponValidColor = UIColor.Yellow;
            vc.ValidFont = UIFont.SystemFontOfSize(18);
            vc.FromToFont = UIFont.SystemFontOfSize(22);
            vc.DescriptionFont = UIFont.BoldSystemFontOfSize(25);
            vc.ValueFont = UIFont.ItalicSystemFontOfSize(25);
            vc.ValueColor = UIColor.Purple;
            //vc.IconPlaceholder = FromUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Cara_Delevingne_by_Gage_Skidmore.jpg/1200px-Cara_Delevingne_by_Gage_Skidmore.jpg");
            vc.Show();

            //NearUIiOS.UICoupon(AdapterCoupon.GetNativeType(coupon), FromUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Cara_Delevingne_by_Gage_Skidmore.jpg/1200px-Cara_Delevingne_by_Gage_Skidmore.jpg"));
        }

        public void CouponList()
        {
            NearUIiOS.UICouponList();
        }

        public void DefaultContent(XCContentNotification content)
        {
            var vc = new NITContentViewController(AdapterContent.GetNativeType(content));
            vc.CallToActionButton = FromUrl("https://www.w3schools.com/howto/img_fjords.jpg");
            vc.ContentMainFont = UIFont.SystemFontOfSize(20);
            vc.ImagePlaceholder = FromUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Cara_Delevingne_by_Gage_Skidmore.jpg/1200px-Cara_Delevingne_by_Gage_Skidmore.jpg");
            vc.Show();
            //NearUIiOS.UIContent(AdapterContent.GetNativeType(content));
        }







        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}

