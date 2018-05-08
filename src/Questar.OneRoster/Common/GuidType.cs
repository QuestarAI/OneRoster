namespace Questar.OneRoster.Common
{
    /// <summary>
    /// The type of object a Guid represents.
    /// </summary>
    /// <remarks>
    /// The only reference to this in this spec is an image
    /// which is missing School; we added it since the spec has
    /// Student, Teacher, and User.
    /// </remarks>
    public enum GuidType
    {
        AcademicSession,
        Category,
        Class,
        Course,
        Demographics,
        Enrollment,
        GradingPeriod,
        LineItem,
        Org,
        Resource,
        Result,
        School,
        Student,
        Teacher,
        Term,
        User,
    }
}