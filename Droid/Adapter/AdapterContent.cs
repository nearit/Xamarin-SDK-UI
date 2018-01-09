using System;
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
                //NContent.ImageLink = new ImageSet();
                NContent.ImageLink.FullSize = XContent.ImageLink.FullSize;
                NContent.ImageLink.SmallSize = XContent.ImageLink.SmallSize;
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
