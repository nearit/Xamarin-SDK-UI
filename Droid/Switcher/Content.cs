using System;
using Com.Nearit.Ui_bindings;
using Android.Content;
using IT.Near.Sdk.Reactions.Contentplugin.Model;
using Android.Widget;

namespace XamarinUI.Droid.Switcher
{
    public class ContentClass
    {
        public static Intent SwitchMode(string mode, Context context, Content content)
        {
            mode = mode.ToLower();

            if(mode.Equals(Global.Global.DEFAULT_CONTENT_MODE))
            {
                return NearITUIBindings.GetInstance(context)
                                   .CreateContentDetailIntentBuilder(content)
                                   .Build();
            }
            else
            {
                Intent inte = new Intent();
                inte.SetType("invalid");

                return inte;
            }

        }
    }
}
