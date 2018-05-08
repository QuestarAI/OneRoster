namespace Questar.OneRoster.Common
{
    using System;

    /// <summary>
    /// A helper class for adding extensions to <see cref="GuidType"/> and <see cref="ObjectType"/>.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Given the type of an object, returns the underlying type.
        /// For example, a <see cref="GuidType.Student"/> is actually an <see cref="ObjectType.User"/>.
        /// </summary>
        /// <param name="guidType">The type of an object.</param>
        public static ObjectType ToObjectType(this GuidType guidType)
        {
            switch (guidType)
            {
                case GuidType.AcademicSession: return ObjectType.AcademicSession;
                case GuidType.Category: return ObjectType.Category;
                case GuidType.Class: return ObjectType.Class;
                case GuidType.Course: return ObjectType.Course;
                case GuidType.Demographics: return ObjectType.Demographics;
                case GuidType.Enrollment: return ObjectType.Enrollment;
                case GuidType.GradingPeriod: return ObjectType.AcademicSession;
                case GuidType.LineItem: return ObjectType.LineItem;
                case GuidType.Org: return ObjectType.Org;
                case GuidType.Resource: return ObjectType.Resource;
                case GuidType.Result: return ObjectType.Result;
                case GuidType.School: return ObjectType.Org;
                case GuidType.Student: return ObjectType.User;
                case GuidType.Teacher: return ObjectType.User;
                case GuidType.Term: return ObjectType.AcademicSession;
                case GuidType.User: return ObjectType.User;
                default: throw new ArgumentOutOfRangeException(nameof(guidType), guidType, null);
            }
        }
    }
}