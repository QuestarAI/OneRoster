namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<Guid>, IBaseObject
    {
        public User(UserType type) => Type = type;

        private User()
        {
        }

        public new Guid Id => base.Id;

        [Required]
        public virtual UserType? Type { get; private set; }

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

        public virtual string Identifier { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual string Sms { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual string Phone { get; set; }

        public virtual Demographics Demographics { get; internal set; } = new Demographics();

        public virtual ICollection<UserAgent> Agents { get; } = new HashSet<UserAgent>();

        public virtual ICollection<UserGrade> Grades { get; } = new HashSet<UserGrade>();

        public virtual ICollection<UserIdentifier> Ids { get; } = new HashSet<UserIdentifier>();

        public virtual ICollection<UserOrganization> Organizations { get; } = new HashSet<UserOrganization>();

        public virtual ICollection<Enrollment> Enrollments { get; } = new HashSet<Enrollment>();

        // students only
        public virtual ICollection<Result> Results { get; } = new HashSet<Result>();

        #region Base Object

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual Status Status { get; private set; }

        public virtual DateTime Modified { get; private set; }

        #endregion
    }
}