namespace Questar.OneRoster.Api.Conventions
{
    using System.Linq;
    using Attributes;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;

    public class ControllerNameAttributeConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var attr = controller.Attributes.OfType<ControllerNameAttribute>().SingleOrDefault();
            if (attr != null)
            {
                controller.ControllerName = attr.Name;
            }
        }
    }
}