using System;

namespace Questar.OneRoster.Serialization
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OneRosterPluralizationAttribute : Attribute
    {
        public OneRosterPluralizationAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}