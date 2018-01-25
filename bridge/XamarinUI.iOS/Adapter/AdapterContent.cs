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
                NContent.Images = new NITImage[1];
                NContent.Images = From(XContent.ImageLink);
            }

            if(XContent.Cta != null)
            {
                NContent.InternalLink = new NSDictionary<NSString, NSObject>();
                NContent.InternalLink = FromContentLink(XContent.Cta);
            }

            NContent.ID = XContent.Id;

            return NContent;
        }

        private static NITImage[] From(XCImageSet IconSet)
        {
            var image = new NITImage[1];

            var Keys = new NSString[2];
            var Obj = new NSObject[2];

            Keys[0] = (Foundation.NSString)"square_300";
            Keys[1] = (Foundation.NSString)"url";

            Obj[0] = NSString.FromObject(IconSet.SmallSize);
            Obj[1] = NSString.FromObject(IconSet.FullSize);

            image[0] = new NITImage();
            image[0].Image = new NSDictionary<NSString, NSObject>(Keys, Obj);

            return image;
        }

        private static NSDictionary<NSString, NSObject> FromContentLink(XCContentLink ContentLink)
        {
            var Keys = new NSString[2];
            var Obj = new NSObject[2];

            Keys[0] = (Foundation.NSString)"url";
            Keys[1] = (Foundation.NSString)"label";

            Obj[0] = NSString.FromObject(ContentLink.Url);
            Obj[1] = NSString.FromObject(ContentLink.Label);

            NSDictionary<NSString, NSObject> images = new NSDictionary<NSString, NSObject>(Keys, Obj);

            return images;
        }
    }
}
