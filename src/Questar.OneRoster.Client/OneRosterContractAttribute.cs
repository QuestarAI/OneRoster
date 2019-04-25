namespace Questar.OneRoster.Client
{
    using System;

    public class OneRosterContractAttribute : Attribute
    {
        public bool Pluralize { get; set; }
    }
}