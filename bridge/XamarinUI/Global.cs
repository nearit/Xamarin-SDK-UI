using System;

namespace XamarinUI
{
    public static class Global
    {
        // Permissions
        public static string DEFAULT_PERMISSIONS_MODE = "default_permissions_mode"; //ios -> location, notification     android -> location, bluetooth
        public static string LOCATION_MODE = "permissions_location_mode"; //ios -> location     android -> location

        // Coupon
        public static string VALID_MODE = "valid_mode";
        public static string INACTIVE_MODE = "inactive_mode";
        public static string EXPIRED_MODE = "expired_mode";
        public static string COUPON_LIST_MODE = "coupon_list_mode";

        // Feedback
        public static string DEFAULT_FEEDBACK_MODE = "default_feedback_mode";

        // Content
        public static string DEFAULT_CONTENT_MODE = "default_content_mode";
    }
}