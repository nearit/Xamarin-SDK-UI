# Coupon List (Android)

Providing a **list of coupons** earned by the user is a common feature of apps that integrate NearIT. With NearIT-UI you can launch an activity or get a fragment that automatically fetches and displays coupons with our proposed sorting.

## Introduction

To understand the examples in this section it is important to know how NearIT coupons work. A coupon can have a date from which an user can redeem it and an expiration date. At a certain date a coupon could be in one of these states:

- valid: redeemable, not expired and not already used.
- not yet active: not yet redeemable
- expired: current date is beyond the expiration one
- redeemed: coupon code has been used With NearIT-UI, depending on its state, a coupon will appear in a different way.
<br>

With these few lines of code

```
NearUIDroid.UICouponList();
```
you are able to show the list of coupons with this sorting rationale:

- valid coupons
- not yet active coupons
- expired coupons

each set is ordered by the date the user earned the coupons.

**If you want** to show already redeemed coupons too, just use this:

```
NearUIDroid.UICouponList(true);
```

## Advanced

In your application you may want to show only coupons that are in certain states. With our builder you can request a list of only valid coupons:

```
NearUIDroid.UICouponList(CouponListFilterOption.Valid);
```
The same for the other states:

-  ``` CouponListFilterOption.Disabled ```
- ``` CouponListFilterOption.Expired ```
- ``` CouponListFilterOption.Redeemed ```
