namespace Questar.OneRoster.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;
    using Sorting;

    public class SelectParams : Params
    {
        [FromQuery]
        public int Offset { get; set; } = 0;

        [FromQuery]
        public int Limit { get; set; } = 100;

        [FromQuery]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Sort { get; set; }

        [FromQuery]
        public SortDirection? OrderBy { get; set; }

        [FromQuery]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
}