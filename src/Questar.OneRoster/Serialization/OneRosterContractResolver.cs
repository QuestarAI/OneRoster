namespace Questar.OneRoster.Serialization
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class OneRosterContractResolver : DefaultContractResolver
    {
        public OneRosterContractResolver(Type type)
        {
            Type = type;
            NamingStrategy = new OneRosterNamingStrategy { ProcessDictionaryKeys = true, OverrideSpecifiedNames = true };
        }

        public Type Type { get; }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var attribute = member.GetCustomAttribute<OneRosterContractAttribute>();
            if (attribute == null)
                return property;
            var propertyName =
                attribute.Pluralize
                    ? Type.GetTypeInfo().GetCustomAttribute<OneRosterPluralizationAttribute>()?.Name ?? Pluralize(Type.Name)
                    : Type.Name;
            property.PropertyName = ResolvePropertyName(propertyName);
            return property;
        }

        protected string Pluralize(string name)
        {
            if (name.EndsWith("y") && !new[] { "a", "e", "i", "o", "u" }.Any(vowel => name.EndsWith(vowel + "y")))
                return name.Substring(0, name.Length - 1) + "ies";
            if (name.EndsWith("s"))
                return name + "es";
            return name + "s";
        }
    }
}