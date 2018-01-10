using System;
using System.Collections.Generic;
using IT.Near.Sdk.Reactions.Contentplugin.Model;
using XamarinBridge.PCL.Types;

namespace XamarinUI.Droid.Adapter
{
    public class AdapterContent
    {
        public static Content GetNativeType(XCContentNotification XContent)
        {
            Content NContent = new Content();

            NContent.NotificationMessage = XContent.NotificationMessage;
            NContent.Title = XContent.Title;
            NContent.ContentString = XContent.Content;

            if(XContent.ImageLink != null)
            {
                IList<ImageSet> Images = new List<ImageSet>();
                ImageSet image = new ImageSet();
                image.FullSize = XContent.ImageLink.FullSize;
                image.SmallSize = XContent.ImageLink.SmallSize;
                Images.Add(image);
                NContent.Images_links = Images;
            }

            if(XContent.Cta != null)
            {
                NContent.Cta = new ContentLink(XContent.Cta.Label, XContent.Cta.Url);
            }

            NContent.Id = XContent.Id;

            return NContent;
        }
    }
}
