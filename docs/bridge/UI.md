# UI (PCL)

**NearUI** is an open-source library that provides customizable UI bindings on top of the core **NearIT SDK**. This library aims to minimize the effort of creating UI for NearIT contents and dialogs.

## Permissions Request

If your app integrates NearIT services, you surely want your user to grant your app the main permissions.

#### iOS

If you want your app to ask user for both **location and notification** permissions (and turning both on), use the following code:

```
NearUIPCL.UIPermission((result) => {
    if (result == 0)
    {
        //Granted
    }
    else
    {
        //Denied
    }
});
```

**Instead** if you want to ask user only for **location** permission:

```
NearUIPCL.UIOnlyLocation((result) => {
    if (result == 0)
    {
        //Granted
    }
    else
    {
        //Denied
    }
});
```

#### Android

If you want your app to ask user for both **location and bluetooth** permissions (and turning both on), use the following code:

```
NearUIPCL.UIPermission((result) => {
    if (result == 0)
    {
        //Granted
    }
    else
    {
        //Denied
    }
});
```

**Instead** if you want to ask user only for **location** permission:

```
NearUIPCL.UIOnlyLocation((result) => {
    if (result == 0)
    {
        //Granted
    }
    else
    {
        //Denied
    }
});
```



## Feedback

If you want your app to display a **feedback request** in a beautiful pop-up dialog, use this simple code:

```
NearUIPCL.UIFeedback(<YOUR XCFEEDBACK>);
```

Further information on coupons and other in-app content can be found [here](http://nearit-xamarin-sdk.readthedocs.io/en/latest/bridge/handle-content/).
The Feedback UI also takes care of delivering the user response to the SDK library and showing the proper success or failure status of the user action.

## Coupon

If you want your app to display a **coupon** in a beautiful pop-up dialog, use this simple code:

```
NearUIPCL.UICoupon(<YOUR XCCOUPON>);
```

Further information on coupons and other in-app content can be found [here](http://nearit-xamarin-sdk.readthedocs.io/en/latest/bridge/handle-content/).

## Content

If you want your app to display a NearIT **content** in a pop-up dialog, use this simple code:
```
NearUIPCL.UIContent(<YOUR XCCONTENT>);
```

Further information on coupons and other in-app content can be found [here](http://nearit-xamarin-sdk.readthedocs.io/en/latest/bridge/handle-content/).

## Coupon List

Providing a **list of coupons** earned by the user is a common feature of apps that integrate NearIT. With NearUI you can launch an activity or get a fragment that automatically fetches and displays coupons with our proposed sorting.

With these few lines of code

```
NearUIPCL.UICouponList();
```
you are able to show the list of coupons with this sorting rationale:

- valid coupons
- not yet active coupons
- expired coupons

each set is ordered by the date the user earned the coupons.

