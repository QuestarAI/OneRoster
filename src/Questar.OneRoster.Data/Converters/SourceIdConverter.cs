namespace Questar.OneRoster.Data.Converters
{
    using System;
    using AutoMapper;

    public class SourceIdConverter : ITypeConverter<Guid, string>
    {
        public string Convert(Guid source, string destination, ResolutionContext context) => source.ToString("N");
    }
}