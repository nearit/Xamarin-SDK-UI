# Permissions Request (Android)

If your app integrates NearIT services, you surely want your user to grant your app location permissions. NearIT supports the use of Beacon technology, so bluetooth could also be a requirement for your app.

**Note** this UI takes care of a variety of scenarios, such as flight mode on, or "never ask again" for a permission.

If you want your app to ask user for both location and bluetooth permissions (and turning both on), use the following code:

```
NearUIDroid.UIPermission((int obj) =>
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
NearUIDroid.UIOnlyLocation((int obj) =>
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

## Advanced

The whole permisison request flow, can be started **without UI** doing this:
```
NearUIDroid.UIPermission((int obj) =>
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
Obviously this works also with the ```UIOnlyLocation``` method.
