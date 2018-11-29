namespace Questar.OneRoster.Data
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class UserToken : IdentityUserToken<Guid>
    {
        public new Guid UserId => base.UserId;
    }
}