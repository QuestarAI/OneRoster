namespace Questar.OneRoster.DataServices
{
    using Models;

    public interface IClassRepository : IRepository<Class>
    {
        IQuery<LineItem> GetLineItemsForClass(string classId);

        IQuery<Result> GetResultsForLineItemForClass(string classId, string lineItemId);

        IQuery<Resource> GetResourcesForClass(string classId);

        IQuery<Result> GetResultsForClass(string classId);

        IQuery<User> GetStudentsForClass(string classId);

        IQuery<Result> GetResultsForStudentForClass(string classId, string studentId);

        IQuery<User> GetTeachersForClass(string classId);
    }
}