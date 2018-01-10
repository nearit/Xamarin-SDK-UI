using System;
using Com.Nearit.Ui_bindings;
using Android.Content;
using IT.Near.Sdk.Reactions.Feedbackplugin.Model;
using IT.Near.Sdk;
using IT.Near.Sdk.Reactions.Feedbackplugin;
using IT.Near.Sdk.Recipes;

namespace XamarinUI.Droid.Switcher
{
    public class FeedbackClass
    {
        public static Intent SwitchMode(string mode, Context context, Feedback feedback)
        {
            mode = mode.ToLower();

            if(mode.Equals(Global.Global.DEFAULT_FEEDBACK_MODE))
            {
                return NearITUIBindings.GetInstance(context)
                                       .CreateFeedbackIntentBuilder(feedback)
                                       .Build();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("invalid feedback");
                Intent inte = new Intent();
                inte.SetType("invalid");

                return inte;
            }
        }
    }
}
