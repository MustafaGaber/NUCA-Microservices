// Copyright (c) Brock Allen & Dominick Baier. AllRoles rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace NUCA.Identity.Controllers
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; init; }
    }
}