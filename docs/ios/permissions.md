# Permissions Request (iOS)

If your app integrates NearIT services, you surely want your user to grant your app location and notification permissions.

If you want your app to ask user for both location and notification permissions (and turning both on), use the following code:

```
NearUIiOS.UIPermission((int obj) =>
{
    if (obj == 0)
    {
        Console.WriteLine("granted!");
    }
    else
    {
        Console.WriteLine("denied");
    }
});
```

**Instead** if you want to ask user only for **location** permission:

```
NearUIiOS.UIOnlyLocation((int obj) =>
{
    if (obj == 0)
    {
        Console.WriteLine("granted!");
    }
    else
    {
        Console.WriteLine("denied");
    }
});
```

## UI Customizations

Please to main source code for the complete list of public variables.

```
var vc = new NITPermissionsViewController();
vc.HeaderImage = <YOUR UIIMAGE>;
vc.TextColor = UIColor.Black;
vc.IsEnableTapToClose = true;
vc.UnknownButton = <YOUR UIIMAGE>;
vc.GrantedButton = <YOUR UIIMAGE>;
vc.GrantedIcon = <YOUR UIIMAGE>;
vc.LocationText = "Turn on location";
vc.NotificationsText = "Turn on notications";
vc.ExplainText = "We'll notify you of content that's interesting";
vc.AutoCloseDialog = NITPermissionsAutoCloseDialog.ff | NITPermissionsAutoCloseDialog.n;
vc.Show();
```
