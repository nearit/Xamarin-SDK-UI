using System;
using IT.Near.Sdk.Reactions.Feedbackplugin.Model;
using XamarinBridge.PCL.Types;

namespace XamarinUI.Droid.Adapter
{
    public class AdapterFeedback
    {
        public static Feedback GetNativeType(XCFeedbackNotification XFeedback)
        {
            Feedback NFeedback = new Feedback();

            NFeedback.NotificationMessage = XFeedback.NotificationMessage;
            NFeedback.Question = XFeedback.Question;
            NFeedback.RecipeId = XFeedback.RecipeId;
            NFeedback.Id = XFeedback.Id;

            return NFeedback;
        }
    }
}
