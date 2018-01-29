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
            NearUIiOS.UIPermission((obj) => 
            {
                
            });
        }

        public void LocationPermissions()
        {
            NearUIiOS.UIOnlyLocation((obj) => {
                
            });
        }

        public void DefaultFeedback(XCFeedbackNotification feedback)
        {
            NearUIiOS.UIFeedback(AdapterFeedback.GetNativeType(feedback), false);
        }

        public void Coupon(XCCouponNotification coupon)
        {
            NearUIiOS.UICoupon(AdapterCoupon.GetNativeType(coupon), FromUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Cara_Delevingne_by_Gage_Skidmore.jpg/1200px-Cara_Delevingne_by_Gage_Skidmore.jpg"));
        }

        public void CouponList()
        {
            
        }

        public void DefaultContent(XCContentNotification content)
        {
            NearUIiOS.UIContent(AdapterContent.GetNativeType(content));
        }







        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}

