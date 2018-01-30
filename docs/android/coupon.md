# Coupon (Android)

If you want your app to display a **coupon** in a beautiful pop-up dialog, use this simple code:

```
NearUIDroid.UICoupon(<YOUR COUPON>);
```

Further information on coupons and other in-app content can be found [here](http://nearit-xamarin-sdk.readthedocs.io/en/latest/android/in-app-content/).

## Advanced

NearIT-UI is shipped with our brand as icon placeholder. If you need to replace it just add one line of code:

```
NearUIDroid.UICoupon(<YOUR COUPON>, Resource.Drawable.your_drawable);
```

Please, keep in mind that the icon should be a square: a different aspect-ratio can potentially break the layout.
