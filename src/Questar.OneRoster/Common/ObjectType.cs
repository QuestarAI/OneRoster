namespace Questar.OneRoster.Common
{
    /// <summary>
    /// The underlying object types. This deals with the fact some objects have
    /// the same underlying structure. Use <see cref="TypeExtensions.ToObjectType"/>
    /// to map from a <see cref="GuidType"/> to an <see cref="ObjectType"/>.
    /// Examples of objects sharing structures:
    /// AcademicSession = AcademicSession | GradingPeriod | Term
    /// User = User | Teacher | Student
    /// Org = Org | School
    /// </summary>
    public enum ObjectType
    {
        AcademicSession,
        Category,
        Class,
        Course,
        Demographics,
        Enrollment,
        LineItem,
        Org,
        Resource,
        Result,
        User,
    }
}