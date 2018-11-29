namespace Questar.OneRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Models.Errors;

    public abstract class QueryParamsValidator<T>
    {
        protected static readonly HashSet<string> Properties = new HashSet<string>(typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(info => info.Name), StringComparer.OrdinalIgnoreCase);

        public List<StatusInfo> StatusInfo { get; } = new List<StatusInfo>();

        public virtual void ValidateFields(ICollection<string> fields)
        {
            if (fields == null)
                return;
            if (fields.Any())
                foreach (var property in fields.Where(field => !Properties.Contains(field)))
                    StatusInfo.Add(new StatusInfo
                    {
                        CodeMajor = CodeMajor.Success,
                        CodeMinor = CodeMinor.InvalidSelectionField,
                        Severity = Severity.Warning,
                        Description = property
                    });
            else
                StatusInfo.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Failure,
                    CodeMinor = CodeMinor.InvalidBlankSelectionField,
                    Severity = Severity.Error
                });
        }
    }
}