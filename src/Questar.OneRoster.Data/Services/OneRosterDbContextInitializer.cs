namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Linq;

    public class OneRosterDbContextInitializer
    {
        public OneRosterDbContextInitializer(OneRosterDbContext context) =>
            Context = context;

        public OneRosterDbContext Context { get; }

        public void Initialize()
        {
            if (Context.Orgs.Any())
                return;

            var nation = new Org(OrgType.National) { Name = "My Nation" };
            var state = new Org(OrgType.State) { Name = "My State", Parent = nation };
            var local = new Org(OrgType.Local) { Name = "My Local", Parent = state };
            var district = new Org(OrgType.District) { Name = "My District", Parent = local };
            var school = new Org(OrgType.School) { Name = "My School", Parent = district };
            var schoolYear = new AcademicSession(AcademicSessionType.SchoolYear)
            {
                Title = "My School Year",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                SchoolYear = DateTime.UtcNow.Year,
                MetadataCollection = { Metadata = { new Metadata { Key = "Foo", Value = "Bar" }, new Metadata { Key = "Baz", Value = "Qux" } } }
            };
            var term = new AcademicSession(AcademicSessionType.Term)
            {
                Title = "My Term",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                SchoolYear = DateTime.UtcNow.Year,
                Parent = schoolYear
            };
            var semester = new AcademicSession(AcademicSessionType.Semester)
            {
                Title = "My Semester",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                SchoolYear = DateTime.UtcNow.Year,
                Parent = schoolYear
            };
            var gradingPeriod = new AcademicSession(AcademicSessionType.GradingPeriod)
            {
                Title = "My Grading Period",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                SchoolYear = DateTime.UtcNow.Year,
                Parent = semester
            };
            var resource = new Resource { Title = "My Resource", Importance = Importance.Primary, VendorResourceId = "my-vendor-id-98a47dd5-4829-4556-a57b-bb89fff89506", Roles = { new ResourceRole(UserType.Administrator), new ResourceRole(UserType.Teacher), new ResourceRole(UserType.Student) } };
            var subject = new Subject { Name = "English", Code = "ENG" };
            var grade = new Grade { Code = "08" };
            var course = new Course
            {
                Title = "My Course",
                Org = school,
                SchoolYear = schoolYear,
                Grades = { new CourseGrade(grade) },
                Resources = { new CourseResource(resource) },
                Subjects = { new CourseSubject(subject) }
            };
            var category = new Category { Title = "My Category" };
            var item = new LineItem
            {
                Title = "My Line Item",
                Category = category,
                GradingPeriod = gradingPeriod,
                AssignDate = DateTime.UtcNow,
                DueDate = DateTime.Now.AddDays(7),
                ResultValueMin = 65,
                ResultValueMax = 100
            };
            var @class = new Class(ClassType.Scheduled)
            {
                Title = "My Class",
                Course = course,
                School = school,
                Terms = { new ClassAcademicSession(term) },
                LineItems = { item }
            };
            var administrator = new User(UserType.Administrator)
            {
                Email = "bwhite@gmail.com",
                UserName = "bwhite@gmail.com",
                GivenName = "Betty",
                MiddleName = "Marion",
                FamilyName = "White",
                Ids = { new UserIdentifier("Foo", "7dd5300e-30a1-4f0e-a849-23a9ddc9ff3b") },
                Orgs = { new UserOrg(district) }
            };
            var student = new User(UserType.Student)
            {
                Email = "wmurray@gmail.com",
                UserName = "wmurray@gmail.com",
                GivenName = "William",
                MiddleName = "James",
                FamilyName = "Murray",
                Demographics = { BirthDate = DateTime.UtcNow.AddYears(-12), Sex = Gender.Male },
                Agents = { new UserAgent(administrator) },
                Grades = { new UserGrade(grade) },
                Enrollments = { new Enrollment(@class) },
                Results = { new Result(item) { Score = 100, ScoreDate = DateTime.UtcNow, ScoreStatus = ResultScoreStatus.FullyGraded } },
                Orgs = { new UserOrg(school) }
            };

            Context.Users.Add(student);

            Context.SaveChanges();
        }
    }
}