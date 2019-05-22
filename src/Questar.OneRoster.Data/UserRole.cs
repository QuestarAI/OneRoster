namespace Questar.OneRoster.Data
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class UserRole : IdentityUserRole<Guid>
    {
        public new Guid UserId => base.UserId;

        public new Guid RoleId => base.RoleId;
    }
}