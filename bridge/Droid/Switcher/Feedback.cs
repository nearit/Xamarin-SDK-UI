using System;
using Android.Content;
using Com.Nearit.Ui_bindings;
using IT.Near.Sdk.Reactions.Feedbackplugin.Model;

namespace XamarinUI.Droid.Switcher
{
    public class FeedbackClass
    {
        public static Intent SwitchMode(Context context, Feedback feedback, bool comment, bool tapOutside)
        {
            if(tapOutside == true)
            {
                if (comment == true)
                {
                    return NearITUIBindings.GetInstance(context)
                                           .CreateFeedbackIntentBuilder(feedback)
                                           .EnableTapOutsideToClose()
                                           .Build();
                }
                else
                {
                    return NearITUIBindings.GetInstance(context)
                                           .CreateFeedbackIntentBuilder(feedback)
                                           .WithoutComment()
                                           .EnableTapOutsideToClose()
                                           .Build();
                }
            }
            else
            {
                if (comment == true)
                {
                    return NearITUIBindings.GetInstance(context)
                                           .CreateFeedbackIntentBuilder(feedback)
                                           .Build();
                }
                else
                {
                    return NearITUIBindings.GetInstance(context)
                                           .CreateFeedbackIntentBuilder(feedback)
                                           .WithoutComment()
                                           .Build();
                }
            }

        }
    }
}
