# Feedback (PCL)

If you want your app to display a **feedback request** in a beautiful pop-up dialog, use this simple code:

```
NearUIPCL.UIFeedback(<YOUR XCFEEDBACK>);
```

If you need to **simplify** the feedback request you are able to ask the user for the 1 to 5 rating only, **without any textual comment** (please notice that the text response is optional in every scenerio), you can hide the text box adding one method call:

```
NearUIPCL.UIFeedback(<YOUR XCFEEDBACK>, false);
```

Further information on coupons and other in-app content can be found [here](http://nearit-xamarin-sdk.readthedocs.io/en/latest/bridge/handle-content/).

The Feedback UI also takes care of delivering the user response to the SDK library and showing the proper success or failure status of the user action.
