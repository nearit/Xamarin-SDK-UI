using System;
using System.Collections.Generic;
using System.Linq;
using NearIT;
using XamarinUI.iOS;
using Foundation;
using UIKit;
using CoreLocation;
using UserNotifications;

namespace SampleUIBindings.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            System.Diagnostics.Debug.WriteLine("FinishedLaunching");
            XamarinUI.iOS.Initializer.Init();

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            NITManager.SetupWithApiKey("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiI4ZTUzYTIwNWE4MDQ0YTZlOWFjODllYWZmZWI4YjJkMSIsImlhdCI6MTUwNzcwOTEwMCwiZXhwIjoxNjMzOTk2Nzk5LCJkYXRhIjp7ImFjY291bnQiOnsiaWQiOiIwMTczOWQwNS1kYzZmLTRjMGYtODA0Ni03MmFkYWM1Mzk1ZjUiLCJyb2xlX2tleSI6ImFwcCJ9fX0.P1yEbi3dXHiLVAtJWiNSRqA6MJRGBxXbFD-ENLt7R7w");
            //NITManager.DefaultManager.ShowForegroundNotification = true;
            //NITManager.DefaultManager.Start();



            return base.FinishedLaunching(app, options);
        }
    }
}
