# NearIT-UI
NearIT-UI is an open-source library that provides customizable UI bindings on top of the core **NearIT SDK**.<br>
This library aims to minimize the effort of creating UI for NearIT contents and dialogs.

#### Features
Permissions related:

- Permissions request [iOS](ios/permissions.md) - [Android](android/permissions.md) - [PCL](bridge/permissions.md)

Content related:

- Coupon detail [iOS](ios/coupon.md) - [Android](android/coupon.md) - [PCL](bridge/coupon.md)
- Feedback request [iOS](ios/feedback.md) - [Android](android/feedback.md) - [PCL](bridge/feedback.md)
- Content detail [iOS](ios/content.md) - [Android](android/content.md) - [PCL](bridge/content.md)
- Coupon list [iOS](ios/couponList.md) -  [Android](android/couponList.md) - [PCL](bridge/couponList.md)

## Configuration
Add the NearIT-UI library dependency, click on “**Project>Add NuGet Packages**”, make sure you have "**Show pre-release packages**" option checked, find and add the following NuGet packages:

```
- Xamarin.NearIT.PCL        (in your common fragment)
- Xamarin.NearIT.iOS        (in your native iOS fragment)
- Xamarin.NearIT.Android    (in your native Android fragment)
```
**NOTE** Make sure that your Android **target framework** is set to 8.0

**Important**: NearIT-UI will only work with NearIT SDK version 2.5.3 or higher.
