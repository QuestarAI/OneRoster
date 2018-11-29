namespace Questar.OneRoster
{
    using System.Linq;
    using Filtering;
    using Models.Errors;
    using Sorting;

    public class SelectQueryParamsValidator<T> : QueryParamsValidator<T>
    {
        public virtual void ValidateFilter(Filter filter)
        {
            foreach (var property in filter.GetProperties().Select(property => property.Name).Where(field => !Properties.Contains(field)))
                StatusInfo.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Success,
                    CodeMinor = CodeMinor.InvalidFilterField,
                    Severity = Severity.Warning,
                    Description = property
                });
        }

        public virtual void ValidateSortField(string field)
        {
            if (field != null && !Properties.Contains(field))
                StatusInfo.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Success,
                    CodeMinor = CodeMinor.InvalidSortField,
                    Severity = Severity.Warning,
                    Description = field
                });
        }

        public virtual void ValidateSortDirection(SortDirection? direction)
        {
            // noop
        }

        public virtual void ValidatePageLimit(int limit)
        {
            if (limit < 0)
                StatusInfo.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Failure,
                    CodeMinor = CodeMinor.InvalidLimitField,
                    Severity = Severity.Error,
                    Description = "Limit query parameter must be greater than 0."
                });
        }

        public virtual void ValidatePageOffset(int offset)
        {
            if (offset < 0)
                StatusInfo.Add(new StatusInfo
                {
                    CodeMajor = CodeMajor.Failure,
                    CodeMinor = CodeMinor.InvalidOffsetField,
                    Severity = Severity.Error,
                    Description = "Offset query parameter must be greater than or equal to 0."
                });
        }
    }
}