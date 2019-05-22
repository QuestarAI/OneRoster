namespace Questar.OneRoster.Common
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Reflection;

    public class YearConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
            typeof(int).GetTypeInfo().IsAssignableFrom(sourceType) || base.CanConvertFrom(context, sourceType);

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) =>
            typeof(int).GetTypeInfo().IsAssignableFrom(destinationType) || base.CanConvertTo(context, destinationType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            switch (value)
            {
                case int year:
                    return (Year) year;
                default:
                    return base.ConvertFrom(context, culture, value);
            }
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var year = (Year) value;
            if (destinationType == typeof(int))
                return (int) year;
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}