namespace Questar.OneRoster.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<Guid>, IBaseObject
    {
        [Required]
        public virtual Position? Position { get; protected internal set; }

        public virtual bool Enabled { get; set; }

        [Required]
        [MaxLength(64)]
        [PersonalData]
        public virtual string GivenName { get; set; }

        [MaxLength(64)]
        [PersonalData]
        public virtual string MiddleName { get; set; }

        [Required]
        [PersonalData]
        [MaxLength(64)]
        public virtual string FamilyName { get; set; }

        public virtual Demographics Demographics { get; internal set; } // = new Demographics();

        public virtual ISet<UserAgent> Agents { get; } = new HashSet<UserAgent>();

        public virtual ISet<UserGrade> Grades { get; } = new HashSet<UserGrade>();

        public virtual ISet<Result> Results { get; } = new HashSet<Result>();

        public virtual ISet<UserOrganization> Organizations { get; } = new HashSet<UserOrganization>();

        public virtual Status Status { get; set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }
    }
}