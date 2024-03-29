﻿// Copyright (c) Brock Allen & Dominick Baier. AllPermissions rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;

namespace NUCA.Identity.Controllers
{
    public class ConsentInputModel
    {
        public string Button { get; init; }
        public IEnumerable<string> ScopesConsented { get; init; }
        public bool RememberConsent { get; init; }
        public string ReturnUrl { get; init; }
        public string Description { get; init; }
    }
}