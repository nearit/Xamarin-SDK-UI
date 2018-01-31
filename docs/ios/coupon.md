# Coupon (iOS)

If you want your app to display a **coupon** in a beautiful pop-up dialog, use this simple code:

```
NearUIiOS.UICoupon(<YOUR COUPON>);
```

Further information on coupons and other in-app content can be found [here](http://nearit-xamarin-sdk.readthedocs.io/en/latest/ios/handle-content/).

## Advanced

NearIT-UI is shipped with our brand as icon placeholder. If you need to replace it just add one line of code:

```
NearUIiOS.UICoupon(<YOUR COUPON>, <YOUR PLACEHOLDER AS UIIMAGE>);
```

Please, keep in mind that the icon should be a square: a different aspect-ratio can potentially break the layout.

Optionally, you can display the coupon in your `UINavigationController`:

```
NearUIiOS.UICoupon(<YOUR COUPON>, <YOUR NAVIGATIONCONTROLLER>);
```

## UI Customizations

Please refer to the main source code for the complete list of public variables.

```
var vc = new NITCouponViewController(<YOUR COUPON>);
vc.SeparatorImage = <YOUR UIIMAGE>;
vc.SeparatorBackgroundColor = UIColor.Black;
vc.CouponValidColor = UIColor.Yellow;
vc.ValidFont = UIFont.SystemFontOfSize(18);
vc.FromToFont = UIFont.SystemFontOfSize(22);
vc.DescriptionFont = UIFont.BoldSystemFontOfSize(25);
vc.ValueFont = UIFont.ItalicSystemFontOfSize(25);
vc.ValueColor = UIColor.Purple;
vc.IconPlaceholder = <YOUR UIIMAGE>;
vc.Show();
```
