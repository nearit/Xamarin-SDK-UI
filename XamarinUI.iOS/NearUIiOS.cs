using System;
using NearUI;
using UIKit;
using Xamarin.Forms;
using XamarinBridge.PCL.Types;
using XamarinUI.Interfaces;

[assembly: Dependency(typeof(XamarinUI.iOS.NearUIiOS))]
namespace XamarinUI.iOS
{
    public partial class NearUIiOS : UIViewController, IManager
    {
        private string TypeToCall;

        public override void ViewDidLoad()
        {
            System.Diagnostics.Debug.WriteLine("ViewDidLoad");

            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            Switcher();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void PermissionTypeFromPCL(string mode, Action<int> result)
        {
            
        }

        public void CouponTypeFromPCL(string mode, XCCouponNotification coupon)
        {
            System.Diagnostics.Debug.WriteLine("CouponTypeFromPCL ios");
            TypeToCall = Global.VALID_MODE;
            ViewDidLoad();
        }

        public void ContentTypeFromPCL(string mode, XCContentNotification content)
        {
            
        }

        public void FeedbackTypeFromPCL(string mode, XCFeedbackNotification feedback)
        {
            
        }

        public void CouponListTypeFromPCL()
        {
            
        }



        // SWITCHER
        private void Switcher()
        {
            switch(TypeToCall)
            {
                case "default_permissions_mode":
                    System.Diagnostics.Debug.WriteLine("default_permissions_mode");
                    NITPermissionsViewController Permissions = new NITPermissionsViewController();
                    Permissions.Show();
                    break;
                case "valid_mode":
                    NITCouponViewController CouponView = new NITCouponViewController();
                    System.Diagnostics.Debug.WriteLine("valid_mode");
                    CouponView.Show();

                    break;
                /*case "valid_mode":

                    break;
                case "valid_mode":

                    break;
                case "valid_mode":

                    break;*/

            }
        }
    }
}

