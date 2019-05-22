namespace Questar.OneRoster.Serialization
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class OneRosterPluralizationAttribute : Attribute
    {
        public OneRosterPluralizationAttribute(string name) =>
            Name = name;

        public string Name { get; }
    }
}