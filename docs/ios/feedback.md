# Feedback (iOS)

If you want your app to display a **feedback request** in a beautiful pop-up dialog, use this simple code:

```
NearUIiOS.UIFeedback(<YOUR FEEDBACK>);
```

Further information on coupons and other in-app content can be found [here](http://nearit-xamarin-sdk.readthedocs.io/en/latest/ios/handle-content/).

The Feedback UI also takes care of delivering the user response to the SDK library and showing the proper success or failure status of the user action.

## Advanced

If you need to **simplify** the feedback request you are able to ask the user for the 1 to 5 rating only, **without any textual comment** (please notice that the text response is optional in every scenerio), you can hide the text box adding one method call:

```
NearUIiOS.UIFeedback(<YOUR FEEDBACK>, false);
```

## UI Customizations

Please to main source code for the complete list of public variables.

```
var vc = new NITFeedbackViewController(<YOUR FEEDBACK>);
vc.SendButton = <YOUR UIIMAGE>;
vc.RateEmptyButton = <YOUR UIIMAGE>;
vc.RateFullButton = <YOUR UIIMAGE>;
vc.CommentDescriptionText = "Anything to say?";
vc.CloseText = "Not interested";
vc.SendText = "Rate";
vc.TextColor = UIColor.Blue;
vc.OkText = "Thank you for taking the time to provide us with your feedback.\n\nYour feedback is important to us and we will endeavour to respond to your feedback within 100 working days.\n\nIf your feedback is of an urgent nature, you can contact the Developer on +800HackerMenn";
vc.TextFont = UIFont.BoldSystemFontOfSize(15);
vc.ErrorFont = UIFont.BoldSystemFontOfSize(20);
vc.DisappearTime = 2.0;
vc.Show();
```
