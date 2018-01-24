using System;
using NearIT;
using XamarinBridge.PCL.Types;

namespace XamarinUI.iOS.Adapter
{
    public class AdapterFeedback
    {
        public static NITFeedback GetNativeType(XCFeedbackNotification XFeedback)
        {
            NITFeedback NFeedback = new NITFeedback();

            NFeedback.NotificationMessage = XFeedback.NotificationMessage;
            NFeedback.Question = XFeedback.Question;
            NFeedback.RecipeId = XFeedback.RecipeId;
            NFeedback.ID = XFeedback.Id;

            return NFeedback;
        }
    }
}
