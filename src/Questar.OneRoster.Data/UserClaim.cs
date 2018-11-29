namespace Questar.OneRoster.Data
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class UserClaim : IdentityUserClaim<Guid>
    {
        public new int Id => base.Id;
    }
}