namespace Questar.OneRoster.ApiFramework.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class OneRosterResultAttribute : Attribute
    {
        public OneRosterResultAttribute(string name) => Name = name;
        public string Name { get; }
    }
}