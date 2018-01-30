# Permissions Request (PCL)

If your app integrates NearIT services, you surely want your user to grant your app the main permissions.
Thanks to this few lines of code you can ask user:

- **location and notification** permissions (and turning both on) if the device use **iOS**
- **location and bluetooth** permissions (and turning both on) if the device use **Android**

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
