namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class Role : IdentityRole<string>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 10);
    }
}