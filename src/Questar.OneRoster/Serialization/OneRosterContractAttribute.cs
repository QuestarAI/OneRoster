namespace Questar.OneRoster.Serialization
{
    using System;

    public class OneRosterContractAttribute : Attribute
    {
        public bool Pluralize { get; set; }
    }
}