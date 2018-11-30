namespace Questar.OneRoster.Test.Mock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static Util;

    internal class Entity
    {
        public string FooString { get; set; }

        public int BarInt { get; set; }

        public DateTime BazDateTime { get; set; }

        public Guid QuxGuid { get; set; }

        public Count CorgeEnum { get; set; }

        public string[] Subjects { get; set; }

        public Foo Foo { get; set; }

        public Entity Parent { get; set; }

        public Entity[] Children { get; set; }

        internal static string[] GetSubjects()
            => Enumerable
                .Range(0, 6)
                .Select(n => $"subject{n + 1}")
                .ToArray();

        internal static List<Entity> BuildEntities() => new List<Entity>
        {
            new Entity
            {
                BarInt = 1,
                BazDateTime = UtcDate(2017, 5, 21),
                QuxGuid = new Guid("0D256148-18ED-452E-976A-80FDD3129DCD"),
                FooString = "Nope",
                CorgeEnum = Count.None,
                Subjects = GetSubjects()
            },
            new Entity
            {
                BarInt = 2,
                BazDateTime = UtcDate(2018, 5, 21),
                QuxGuid = new Guid("E773E550-6E27-48B5-84A2-9458A1CE7567"),
                FooString = "42",
                CorgeEnum = Count.One,
                Subjects = GetSubjects()
            },
            new Entity
            {
                BarInt = 3,
                BazDateTime = UtcDate(2019, 5, 21),
                QuxGuid = new Guid("D1EACDDD-64C9-4415-8584-61CA46FDCCC5"),
                FooString = "9001",
                CorgeEnum = Count.Two,
                Subjects = GetSubjects()
            },
            new Entity
            {
                BarInt = 4,
                BazDateTime = UtcDate(2018, 4, 21),
                QuxGuid = new Guid("0AB0AFA3-CAF4-4C3E-BFC2-99F7E5A6DE76"),
                FooString = "421",
                CorgeEnum = Count.None,
                Subjects = GetSubjects()
            },
            new Entity
            {
                BarInt = 5,
                BazDateTime = UtcDate(2018, 5, 21),
                QuxGuid = new Guid("0792B838-2980-4633-B44B-2CA1D0EF9E21"),
                FooString = "42",
                CorgeEnum = Count.One,
                Subjects = GetSubjects()
            },
            new Entity
            {
                BarInt = 6,
                BazDateTime = UtcDate(2018, 6, 21),
                QuxGuid = new Guid("13F17493-8C5F-43C8-9A1E-54D814E9AE9E"),
                FooString = "42 ",
                CorgeEnum = Count.Two,
                Subjects = GetSubjects()
            },
            new Entity
            {
                BarInt = 6,
                BazDateTime = UtcDate(2018, 5, 20),
                QuxGuid = new Guid("9987E157-7796-49D7-B475-45AA87F79748"),
                FooString = "9001",
                CorgeEnum = Count.None,
                Subjects = GetSubjects()
            },
            new Entity
            {
                BarInt = 7,
                BazDateTime = UtcDate(2018, 5, 21),
                QuxGuid = new Guid("4D868BC4-34DE-4411-9F9F-9C5F1FAE1DDB"),
                FooString = "9002",
                CorgeEnum = Count.One,
                Subjects = GetSubjects()
            },
            new Entity
            {
                BarInt = 8,
                BazDateTime = UtcDate(2018, 5, 22),
                QuxGuid = new Guid("4FC1F6AC-69FC-47CF-99EF-12FC9ED1D896"),
                FooString = "9003",
                CorgeEnum = Count.Two,
                Subjects = GetSubjects()
            }
        };
    }
}