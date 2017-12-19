using System;
namespace XamarinUI.Droid.Types
{
    public static class Global
    {
        public static int PERMISSIONS_MODE = 0;
            public static int DEFAULT_PERMISSIONS_MODE = 1; //ios -> location, notification     android -> location, bluetooth
            public static int LOCATION_MODE = 2; //ios -> location     android -> location

        public static int COUPON_MODE = 10;
            public static int VALID_MODE = 11;
            public static int INACTIVE_MODE = 12;
            public static int EXPIRED_MODE = 13;
            public static int COUPON_LIST_MODE = 14;

        public static int FEEDBACK_MODE = 20;
            public static int DEFAULT_FEEDBACK_MODE = 21;

        public static int CONTENT_MODE = 30;
            public static int DEFAULT_CONTENT_MODE = 31;
    }
}
