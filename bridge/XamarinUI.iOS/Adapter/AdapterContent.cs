using System;
using System.Collections.Generic;
using Foundation;
using NearIT;
using XamarinBridge.PCL.Types;

namespace XamarinUI.iOS.Adapter
{
    public class AdapterContent
    {
        public static NITContent GetNativeType(XCContentNotification XContent)
        {
            NITContent NContent = new NITContent();

            NContent.NotificationMessage = XContent.NotificationMessage;
            NContent.Title = XContent.Title;
            NContent.Content = XContent.Content;

            if(XContent.ImageLink != null)
            {
                NContent.Image.Image = new NSDictionary<NSString, NSObject>();
                NContent.Image.Image = From(XContent.ImageLink);
            }

            if(XContent.Cta != null)
            {
                NContent.Link.Label = XContent.Cta.Label;
                NContent.Link.Url = (Foundation.NSUrl)NSUrl.FromObject(XContent.Cta.Url);
            }

            NContent.ID = XContent.Id;

            return NContent;
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
