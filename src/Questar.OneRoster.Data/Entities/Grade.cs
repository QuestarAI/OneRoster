namespace Questar.OneRoster.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Grade
    {
        public virtual Guid Id { get; private set; }

        public virtual string Title { get; set; }

        public virtual string Value { get; set; }

        public virtual ISet<UserGrade> Users { get; } = new HashSet<UserGrade>();
    }
}