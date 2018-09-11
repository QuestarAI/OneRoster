namespace Questar.OneRoster.Data
{
    using System;
    using System.Linq;
    using Entities;

    public class NexteonDbContextInitializer
    {
        public NexteonDbContextInitializer(NexteonDbContext context)
        {
            Context = context;
        }

        public static string[] FirstNames { get; } =
        {
            "Cole",
            "Deirdre",
            "Antione",
            "Analisa",
            "Mac",
            "Araceli",
            "Markus",
            "Aurelia",
            "Brett",
            "Jay",
            "Felicita",
            "Mitsuko",
            "Carson",
            "Damion",
            "Dorthy",
            "Libby",
            "Temeka",
            "Malorie",
            "Leia",
            "Nelia",
            "Shawnee",
            "Miki",
            "Patria",
            "Susannah",
            "Dallas",
            "Hector",
            "Fermin",
            "Jerrod",
            "Jamie",
            "Russ",
            "Sonja",
            "Johnetta",
            "Reynalda",
            "Xiomara",
            "Iliana",
            "Karisa",
            "Kamala",
            "Florene",
            "Un",
            "Devorah",
            "Erlene",
            "Gladys",
            "Rusty",
            "Collette",
            "Hoa",
            "Alvera",
            "Shantelle",
            "Sharilyn",
            "Kimbery",
            "Evelyn"
        };

        public static string[] LastNames { get; } =
        {
            "Cardenas",
            "Reese",
            "Buchanan",
            "Hodges",
            "Bernard",
            "Beck",
            "Landry",
            "Ferguson",
            "Rocha",
            "Stephenson",
            "Mcmillan",
            "Saunders",
            "Maldonado",
            "Blair",
            "Benton",
            "Small",
            "Lawrence",
            "Oliver",
            "Webster",
            "Brock",
            "Oconnor",
            "Perry",
            "Vaughn",
            "Huynh",
            "Parrish",
            "Mcclain",
            "Vance",
            "Roy",
            "Mccormick",
            "Walters",
            "Andrade",
            "Cunningham",
            "Parker",
            "Delgado",
            "Zimmerman",
            "Bush",
            "Best",
            "Carey",
            "Valencia",
            "Simpson",
            "Byrd",
            "Singleton",
            "Harrison",
            "Alvarez",
            "Goodman",
            "Schmidt",
            "Acosta",
            "Dunn",
            "Gentry",
            "Swanson"
        };

        public NexteonDbContext Context { get; }

        public void Populate()
        {
            if (Context.Organizations.Any())
                return;

            var random = new Random();
            var grades = Enumerable.Range(1, 12).ToArray();

            var regionsPerState = 5; // 10
            var regions =
                Enumerable.Range(0, regionsPerState).Select(regionIndex =>
                        new Organization
                        {
                            Title = $"Region {Guid.NewGuid()}"
                        })
                    .ToArray();
            Context.Organizations.AddRange(regions);

            var districtsPerRegion = 10; // 50
            //var districtsMax = regionsPerState * districtsPerRegion;
            var districts =
                Enumerable.Range(0, regionsPerState).SelectMany(regionIndex =>
                        Enumerable.Range(regionIndex * districtsPerRegion, districtsPerRegion).Select(districtIndex =>
                            new Organization
                            {
                                Title = $"District {Guid.NewGuid()}",
                                Parent = regions[regionIndex]
                            }))
                    .ToArray();
            Context.Organizations.AddRange(districts);

            var schoolsPerDistrict = 5; // 10
            //var schoolsMax = regionsPerState * districtsPerRegion * schoolsPerDistrict;
            var schools =
                Enumerable.Range(0, regionsPerState).SelectMany(regionIndex =>
                        Enumerable.Range(regionIndex * districtsPerRegion, districtsPerRegion).SelectMany(districtIndex =>
                            Enumerable.Range(districtIndex * schoolsPerDistrict, schoolsPerDistrict).Select(schoolIndex =>
                                new Organization
                                {
                                    Title = $"School {Guid.NewGuid()}",
                                    Parent = districts[districtIndex]
                                })))
                    .ToArray();
            Context.Organizations.AddRange(schools);

            var sessionsMax = 5; // 10
            var sessions =
                Enumerable.Range(0, sessionsMax).Select(sessionIndex =>
                        new AcademicSession
                        {
                            Title = $"Session {Guid.NewGuid()}"
                        })
                    .ToArray();
            Context.AcademicSessions.AddRange(sessions);

            var coursesPerSchool = 15; // 100
            var coursesMax = regionsPerState * districtsPerRegion * schoolsPerDistrict * coursesPerSchool;
            var courses =
                Enumerable.Range(0, regionsPerState).SelectMany(regionIndex =>
                        Enumerable.Range(regionIndex * districtsPerRegion, districtsPerRegion).SelectMany(districtIndex =>
                            Enumerable.Range(districtIndex * schoolsPerDistrict, schoolsPerDistrict).SelectMany(schoolIndex =>
                                Enumerable.Range(schoolIndex * coursesPerSchool, coursesPerSchool).Select(courseIndex =>
                                    new Course
                                    {
                                        Title = $"Course {Guid.NewGuid()}",
                                        Organization = schools[schoolIndex]
                                    }))))
                    .ToArray();
            Context.Set<Course>().AddRange(courses);

            var classesPerSchool = 40; // 100
            var classes =
                Enumerable.Range(0, regionsPerState).SelectMany(regionId =>
                        Enumerable.Range(regionId * districtsPerRegion, districtsPerRegion).SelectMany(districtId =>
                            Enumerable.Range(districtId * schoolsPerDistrict, schoolsPerDistrict).SelectMany(schoolId =>
                                Enumerable.Range(schoolId * classesPerSchool, classesPerSchool).Select(classId =>
                                    new Class
                                    {
                                        Title = $"Class {Guid.NewGuid()}",
                                        Course = courses[random.Next() % coursesMax + 1], // TODO use class id range for school
                                        AcademicSession = sessions[random.Next() % sessionsMax + 1] // TODO use class id range for school
                                    }))))
                    .ToArray();
            Context.Classes.AddRange(classes);

            var teachersPerSchool = 10; // 50
            var teachers =
                Enumerable.Range(0, regionsPerState).SelectMany(regionId =>
                        Enumerable.Range(regionId * districtsPerRegion, districtsPerRegion).SelectMany(districtId =>
                            Enumerable.Range(districtId * schoolsPerDistrict, schoolsPerDistrict).SelectMany(schoolId =>
                                Enumerable.Range(schoolId * teachersPerSchool, teachersPerSchool).Select(teacherId =>
                                    new User
                                    {
                                        GivenName = FirstNames[random.Next() % FirstNames.Length],
                                        MiddleName = FirstNames[random.Next() % FirstNames.Length],
                                        FamilyName = LastNames[random.Next() % LastNames.Length]
                                    }))))
                    .ToArray();
            Context.Users.AddRange(teachers);

            // TODO randomly enroll teachers

            var studentsPerSchool = 100; // 500
            var students =
                Enumerable.Range(0, regionsPerState).SelectMany(regionId =>
                        Enumerable.Range(regionId * districtsPerRegion, districtsPerRegion).SelectMany(districtId =>
                            Enumerable.Range(districtId * schoolsPerDistrict, schoolsPerDistrict).SelectMany(schoolId =>
                                Enumerable.Range(schoolId * studentsPerSchool, studentsPerSchool).Select(studentId =>
                                    new User
                                    {
                                        GivenName = FirstNames[random.Next() % FirstNames.Length],
                                        MiddleName = FirstNames[random.Next() % FirstNames.Length],
                                        FamilyName = LastNames[random.Next() % LastNames.Length],
                                        Grades = { new UserGrade(new Grade { Value = grades[random.Next() % grades.Length].ToString() }) }
                                    }))))
                    .ToArray();
            Context.Users.AddRange(students);

            // TODO randomly enroll students
        }
    }
}