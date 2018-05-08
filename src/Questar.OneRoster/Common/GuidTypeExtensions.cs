namespace Questar.OneRoster.Common
{
    using Questar.OneRoster.Dto;
    using System;

    public static class TypeExtensions
    {
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