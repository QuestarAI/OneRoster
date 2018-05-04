

namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/categories")]
    public class CategoriesController : Controller
    {
        /// <summary>
        /// Returns the collection of grading categories.
        /// </summary>
        [HttpGet]
        public object GetAllCategories() => throw new NotImplementedException();

        /// <summary>
        /// Marks a specific grading category as deleted by identifier.
        /// An immediate GET will result in HTTP 404 code.
        /// </summary>
        [HttpDelete("{categoryId}")]
        public object DeleteCategory(Guid categoryId) => throw new NotImplementedException();

        /// <summary>
        /// Returns a specific grading category by identifier.
        /// Returns an HTTP 404 if the grading category is marked as deleted.
        /// </summary>
        [HttpGet("{categoryId}")]
        public object GetCategory(Guid categoryId) => throw new NotImplementedException();

        /// <summary>
        /// Creates or replaces a grading category by identifier.
        /// </summary>
        [HttpPut("{categoryId}")]
        public object PutCategory(Guid categoryId) => throw new NotImplementedException();
    }
}