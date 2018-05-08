namespace Questar.OneRoster.Vocabulary.Ceds
{
    using Serialization;

    /// <summary>
    /// Grade code vocabulary provided by the Common Education Data Standards (CEDS),
    /// representing the grade level or primary instructional level at which a student enters
    /// and receives services in a school or an educational institution during a given academic session.
    /// See https://ceds.ed.gov/CEDSElementDetails.aspx?TermId=7100 for more details.
    /// </summary>
    public enum Grade
    {
        [SerializationToken("IT")]
        InfantSlashToddler = -4,

        [SerializationToken("PR")]
        Preschool = -3,

        [SerializationToken("PK")]
        Prekindergarten = -2,

        [SerializationToken("TK")]
        TransitionalKindergarten = -1,

        [SerializationToken("KG")]
        Kindergarten = 0,

        [SerializationToken("01")]
        FirstGrade = 1,

        [SerializationToken("02")]
        SecondGrade = 2,

        [SerializationToken("03")]
        ThirdGrade = 3,

        [SerializationToken("04")]
        FourthGrade = 4,

        [SerializationToken("05")]
        FifthGrade = 5,

        [SerializationToken("06")]
        SixthGrade = 6,

        [SerializationToken("07")]
        SeventhGrade = 7,

        [SerializationToken("08")]
        EighthGrade = 8,

        [SerializationToken("09")]
        NinthGrade = 9,

        [SerializationToken("10")]
        TenthGrade = 10,

        [SerializationToken("11")]
        EleventhGrade = 11,

        [SerializationToken("12")]
        TwelfthGrade = 12,

        [SerializationToken("13")]
        ThirteenthGrade = 13,

        [SerializationToken("01")]
        Grade1 = 1,

        [SerializationToken("02")]
        Grade2 = 2,

        [SerializationToken("03")]
        Grade3 = 3,

        [SerializationToken("04")]
        Grade4 = 4,

        [SerializationToken("05")]
        Grade5 = 5,

        [SerializationToken("06")]
        Grade6 = 6,

        [SerializationToken("07")]
        Grade7 = 7,

        [SerializationToken("08")]
        Grade8 = 8,

        [SerializationToken("09")]
        Grade9 = 9,

        [SerializationToken("10")]
        Grade10 = 10,

        [SerializationToken("11")]
        Grade11 = 11,

        [SerializationToken("12")]
        Grade12 = 12,

        [SerializationToken("13")]
        Grade13 = 13,

        [SerializationToken("PS")]
        Postsecondary = 20,

        [SerializationToken("UG")]
        Ungraded = 98,

        [SerializationToken("Other")]
        Other = 99,
    }
}
