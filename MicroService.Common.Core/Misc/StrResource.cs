namespace MicroService.Common.Core.Misc
{
    public static class StrResource
    {
        public const string PasswordDoesNotMatch      = "Passwords does not match";
        public const string UsernameOfPasswordInvalid = "The username or password was wrong";
        public const string UsernameTaken             = "The username '{0}' is already taken.";

        public const string EmailTaken =
            "The email '{0}' is already in out system. Please, click 'Forgot password' if you forgot you password.";

        public const string EmailToLong       = "Email lenght can not be grater than {0}";
        public const string EmailLooksStrange = "The email looks strange to us, please enter a valid email.";

        public const string EmailActivationSent         = "An email has been sent, check Email for email activattion link";
        public const string EmailActivationSuccess      = "Email verifyed, please login as normal.";
        public const string TokenInvalidOrToOld         = "Token is invalid or has expired";
        public const string EmailNotVerified            = "Please verify email before loggin";
        public const string PasswordResetSuccess        = "Password changed, please login as normal";
        public const string EmailWhitelistIpAddress     = "New device detected, A email has been sent to you email to whitelist this divice";
        public const string AddressWhitelistedSuccess   = "The new device has been added, please login as normal";
        public const string TwoFactorCodeInvalid        = "The two fcator code is invalid.";
        public const string TwoFactorCodeRequiered      = "A two factor code is requiered to login.";
        public const string RevokeRefreshTokenSuccess   = "Refreshtoken has been revoked";
        public const string WhitelistedIpRemoved        = "The IP Address is no longer whitelisted";
        public const string IpNotFound                  = "IP Address not found";
        public const string InvalidIpFormat             = "The IP Address has a invalid format";
        public const string NoTwoWayAuthIsConfigurated  = "No two factor is configurated";
        public const string DomainVerified              = "The domain is now connected to your account";
        public const string DomainUnkownError           = "Unnkown error, please try again later";
        public const string DomainNoPendingVerification = "No pending verfication request was found. Have you requested to be validated";
        public const string DomainInvalidWebsite        = "The website url does not look like a real website.";
        public const string DomainNoCodeFound           = "No code was found, have you added the '<meta>' tag?";
        public const string DomainWrongCode             = "The code provieded in the '<meta>' is invalid";
        public const string DomainRequestDeleted        = "The domain request has been deleted";
        public const string DomainAlreadyPending        = "A request has already been made, use that one or delete it if you want to crate a new one";
        public const string DomainUserAlreadyVerified   = "You are already have a domain verified";
        public const string DomainNotHttps              = "The website is not HTTPS";
    }
}