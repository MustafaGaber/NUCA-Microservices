// Copyright (c) Brock Allen & Dominick Baier. AllPermissions rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;

namespace NUCA.Identity.Controllers
{
    public class AccountOptions
    {
        public static bool AllowRememberLogin = false;
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromSeconds(1);

        public static bool ShowLogoutPrompt = false;
        public static bool AutomaticRedirectAfterSignOut = true;

        public static string InvalidCredentialsErrorMessage = "بيانات الدخول غير صحيحة";
    }
}
