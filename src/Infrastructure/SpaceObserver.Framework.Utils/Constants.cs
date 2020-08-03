namespace SpaceObserver.Framework.Utils
{
    public static class Constants
    {
        public static class MimeTypes
        {
            public const string ApplicationJson = "application/json";
        }

        public static class Configuration
        {
            public const string ApiSettingsSection = "ApiSettings";
        }

        public class CommonErrorMessage
        {
            public const string SystemInternalError = "SystemInternalError";
            public const string InvalidRequest = "InvalidRequest";
            public const string ForbiddenOperation = "ForbiddenOperation";
            public const string GeneralErrorMessage = "GeneralErrorMessage";
        }
    }
}