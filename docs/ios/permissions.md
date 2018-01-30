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
