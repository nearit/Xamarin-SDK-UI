# Content (iOS)

If you want your app to display a NearIT **content** in a pop-up dialog, use this simple code:
```
NearUIiOS.UIContent(<YOUR CONTENT>);
```

Further information on content and other in-app content can be found [here](http://nearit-xamarin-sdk.readthedocs.io/en/latest/ios/handle-content/).

When the user taps on the button, the link will be opened: some types of link will be managed by a specific app, if that app is installed (e.g. a Facebook link).

## Advanced

You can display the content in your `UINavigationController`:

```
NearUIiOS.UIContent(<YOUR CONTENT>, <YOUR NAVIGATIONCONTROLLER>);
```

## UI Customizations

Please to main source code for the complete list of public variables.

```
var vc = new NITContentViewController(<YOUR CONTENT>);
vc.CallToActionButton = <YOUR UIIMAGE>;
vc.ContentMainFont = UIFont.SystemFontOfSize(20);
vc.ImagePlaceholder = <YOUR UIIMAGE>;
vc.Show();
```
