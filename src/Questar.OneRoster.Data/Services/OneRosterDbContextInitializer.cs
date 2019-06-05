using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questar.OneRoster.Data.Services
{
    public class OneRosterDbContextInitializer
    {
        public async Task InitializeAsync()
        {
            var random = new Random();

            var data = new Dictionary<Type, IList>();
            var identifiers = new Dictionary<Type, int>();

            int GetId<T>()
            {
                return identifiers.TryGetValue(typeof(T), out var id) ? identifiers[typeof(T)] = ++id : identifiers[typeof(T)] = 1;
            }

            void Add<T>(T item)
            {
                if (data.TryGetValue(typeof(T), out var collection))
                    collection.Add(item);
                else data[typeof(T)] = new List<T> {item};
            }

            void AddRange<T>(IEnumerable<T> items)
            {
                if (data.TryGetValue(typeof(T), out var collection))
                    ((List<T>) collection).AddRange(items);
                else data[typeof(T)] = items.ToList();
            }

            IEnumerable<T> Get<T>()
            {
                return data.TryGetValue(typeof(T), out var value) ? (List<T>) value : Enumerable.Empty<T>();
            }

            var year = new AcademicSession(AcademicSessionType.SchoolYear)
            {
                Id = GetId<AcademicSession>(),
                Title = "My School Year",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                SchoolYear = DateTime.UtcNow.Year
            };

            var terms = new[]
            {
                new AcademicSession(AcademicSessionType.Term)
                {
                    Id = GetId<AcademicSession>(),
                    Title = "My Term 1",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(6),
                    SchoolYear = DateTime.UtcNow.Year,
                    ParentId = year.Id
                },
                new AcademicSession(AcademicSessionType.Term)
                {
                    Id = GetId<AcademicSession>(),
                    Title = "My Term 2",
                    StartDate = DateTime.UtcNow.AddMonths(6),
                    EndDate = DateTime.UtcNow.AddMonths(12),
                    SchoolYear = DateTime.UtcNow.Year,
                    ParentId = year.Id
                }
            };

            Add(year);
            AddRange(terms);

            var subjects = new[]
            {
                new Subject
                {
                    Id = GetId<Subject>(),
                    Name = "Math",
                    Code = "MATH"
                },
                new Subject
                {
                    Id = GetId<Subject>(),
                    Name = "Secondary Math",
                    Code = "SECMATH"
                },
                new Subject
                {
                    Id = GetId<Subject>(),
                    Name = "ELA",
                    Code = "ELA"
                },
                new Subject
                {
                    Id = GetId<Subject>(),
                    Name = "Writing",
                    Code = "WRIT"
                },
                new Subject
                {
                    Id = GetId<Subject>(),
                    Name = "Science",
                    Code = "SCI"
                }
            };

            AddRange(subjects);

            var grades = new[] {"KG", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"}.Select(code => new Grade {Id = GetId<Grade>(), Code = code}).ToList();

            AddRange(grades);

            // districts
            for (var i = 0; i < 120; i++)
            {
                var district = new Org(OrgType.District)
                {
                    Id = GetId<Org>(),
                    Name = $"District {Guid.NewGuid()}"
                };

                Add(district);

                // schools
                for (var j = 0; j < 5; j++)
                {
                    var school = new Org(OrgType.School)
                    {
                        Id = GetId<Org>(),
                        Name = $"School {Guid.NewGuid()}",
                        ParentId = district.Id
                    };

                    Add(school);

                    // grades (3-8)
                    for (var k = 3; k <= 8; k++)
                    {
                        var teachers = new List<User>();

                        // teachers
                        for (var l = 0; l < 5; l++)
                        {
                            var name = $"Teacher {Guid.NewGuid()}";
                            var email = $"{name.Replace(' ', '-').ToLower()}@mail.com";

                            var teacher = new User(UserType.Teacher)
                            {
                                Id = GetId<User>(),
                                Email = email,
                                UserName = email,
                                GivenName = name,
                                FamilyName = "Everybody"
                            };

                            var ethnicity = random.Next(6);

                            Add(teacher);
                            Add(new UserGrade {UserId = teacher.Id, GradeId = grades[k].Id});
                            Add(new UserOrg {UserId = teacher.Id, OrgId = school.Id});
                            Add(new Demographics
                            {
                                Id = teacher.Id,
                                BirthDate = DateTime.UtcNow.AddYears(-random.Next(65)),
                                Sex = (Gender) random.Next(1),
                                AmericanIndianOrAlaskaNative = ethnicity == 0,
                                Asian = ethnicity == 1,
                                BlackOrAfricanAmerican = ethnicity == 2,
                                DemographicRaceTwoOrMoreRaces = ethnicity == 3,
                                HispanicOrLatinoEthnicity = ethnicity == 4,
                                NativeHawaiianOrOtherPacificIslander = ethnicity == 5,
                                White = ethnicity == 6
                            });

                            teachers.Add(teacher);
                        }

                        var students = new List<User>();

                        // students
                        for (var l = 0; l < 75; l++)
                        {
                            var name = $"Student {Guid.NewGuid()}";
                            var email = $"{name.Replace(' ', '-').ToLower()}@mail.com";

                            var student = new User(UserType.Student)
                            {
                                Id = GetId<User>(),
                                Email = email,
                                UserName = email,
                                GivenName = name,
                                FamilyName = "Everybody"
                            };

                            var ethnicity = random.Next(6);

                            Add(student);
                            Add(new UserGrade {UserId = student.Id, GradeId = grades[k].Id});
                            Add(new UserOrg {UserId = student.Id, OrgId = school.Id});
                            Add(new Demographics
                            {
                                Id = student.Id,
                                BirthDate = DateTime.UtcNow.AddYears(-random.Next(18)),
                                Sex = (Gender) random.Next(1),
                                AmericanIndianOrAlaskaNative = ethnicity == 0,
                                Asian = ethnicity == 1,
                                BlackOrAfricanAmerican = ethnicity == 2,
                                DemographicRaceTwoOrMoreRaces = ethnicity == 3,
                                HispanicOrLatinoEthnicity = ethnicity == 4,
                                NativeHawaiianOrOtherPacificIslander = ethnicity == 5,
                                White = ethnicity == 6
                            });

                            students.Add(student);
                        }

                        // subjects

                        foreach (var subject in subjects)
                        {
                            // courses

                            var course = new Course
                            {
                                Id = GetId<Course>(),
                                Title = $"Course {Guid.NewGuid()}",
                                Code = Guid.NewGuid().ToString().Replace("-", string.Empty),
                                SchoolYearId = year.Id,
                                OrgId = school.Id
                            };

                            Add(course);
                            Add(new CourseGrade {CourseId = course.Id, GradeId = grades[k].Id});
                            Add(new CourseSubject {CourseId = course.Id, SubjectId = subject.Id});

                            // terms

                            foreach (var term in terms)
                                // classes

                                for (var y = 0; y < 10; y++)
                                {
                                    var @class = new Class(ClassType.Scheduled)
                                    {
                                        Id = GetId<Class>(),
                                        Title = $"Class {Guid.NewGuid()}",
                                        Code = Guid.NewGuid().ToString().Replace("-", string.Empty),
                                        CourseId = course.Id,
                                        SchoolId = school.Id
                                    };

                                    Add(@class);
                                    Add(new ClassGrade {ClassId = @class.Id, GradeId = grades[k].Id});
                                    Add(new ClassSubject {ClassId = @class.Id, SubjectId = subject.Id});
                                    Add(new ClassAcademicSession {ClassId = @class.Id, AcademicSessionId = term.Id});

                                    // enrollments

                                    for (var z = 0; z < 1; z++)
                                    {
                                        User teacher;

                                        do
                                        {
                                            teacher = teachers[random.Next(teachers.Count - 1)];
                                        } while (@class.Enrollments.Any(item => item.UserId == teacher.Id));

                                        Add(new Enrollment
                                        {
                                            Id = GetId<Enrollment>(),
                                            ClassId = @class.Id,
                                            UserId = teacher.Id
                                        });
                                    }

                                    for (var z = 0; z < 25; z++)
                                    {
                                        User student;

                                        do
                                        {
                                            student = students[random.Next(students.Count - 1)];
                                        } while (@class.Enrollments.Any(item => item.UserId == student.Id));

                                        Add(new Enrollment
                                        {
                                            Id = GetId<Enrollment>(),
                                            ClassId = @class.Id,
                                            UserId = student.Id
                                        });
                                    }
                                }
                        }
                    }
                }
            }

            using (var context = new OneRosterDbContext())
            {
                Console.WriteLine("Inserting subjects...");
                await context.BulkInsertAsync(Get<Subject>());

                Console.WriteLine("Inserting grades...");
                await context.BulkInsertAsync(Get<Grade>());

                Console.WriteLine("Inserting academic sessions...");
                await context.BulkInsertAsync(Get<AcademicSession>());

                Console.WriteLine("Inserting organizations...");
                await context.BulkInsertAsync(Get<Org>());

                Console.WriteLine("Inserting users...");
                await context.BulkInsertAsync(Get<User>());

                Console.WriteLine("Inserting user grades...");
                await context.BulkInsertAsync(Get<UserGrade>());

                Console.WriteLine("Inserting user organizations...");
                await context.BulkInsertAsync(Get<UserOrg>());

                Console.WriteLine("Inserting demographics...");
                await context.BulkInsertAsync(Get<Demographics>());

                Console.WriteLine("Inserting courses...");
                await context.BulkInsertAsync(Get<Course>());

                Console.WriteLine("Inserting course grades...");
                await context.BulkInsertAsync(Get<CourseGrade>());

                Console.WriteLine("Inserting course subjects...");
                await context.BulkInsertAsync(Get<CourseSubject>());

                Console.WriteLine("Inserting classes...");
                await context.BulkInsertAsync(Get<Class>());

                Console.WriteLine("Inserting class academic sessions...");
                await context.BulkInsertAsync(Get<ClassAcademicSession>());

                Console.WriteLine("Inserting class grades...");
                await context.BulkInsertAsync(Get<ClassGrade>());

                Console.WriteLine("Inserting class subjects...");
                await context.BulkInsertAsync(Get<ClassSubject>());

                Console.WriteLine("Inserting enrollments...");
                await context.BulkInsertAsync(Get<Enrollment>());
            }
        }
    }
}