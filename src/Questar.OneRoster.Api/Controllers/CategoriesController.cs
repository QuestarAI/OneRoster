

namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/categories")]
    public class CategoriesController : Controller
    {
        /// <summary>
        /// Return collection of grading categories.
        /// </summary>
        public object GetAllCategories() => throw new NotImplementedException();

        /// <summary>
        /// Enable the associated SourcedId to be marked as deleted. An immediate read will result in 404 code.
        /// </summary>
        public object DeleteCategory(Guid categoryId) => throw new NotImplementedException();

        /// <summary>
        /// Return specific grading category.
        /// </summary>
        public object GetCategory(Guid categoryId) => throw new NotImplementedException();

        /// <summary>
        /// To create a new Category record or to replace one that already exists.
        /// </summary>
        public object PutCategory(Guid categoryId) => throw new NotImplementedException();
    }
}