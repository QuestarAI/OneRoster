namespace Questar.OneRoster.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Grade code vocabulary provided by the Common Education Data Standards (CEDS),
    /// representing the grade level or primary instructional level at which a student enters
    /// and receives services in a school or an educational institution during a given academic session.
    /// See https://ceds.ed.gov/CEDSElementDetails.aspx?TermId=7100 for more details.
    /// </summary>
    public enum Grade
    {
        [EnumMember(Value = "IT")]
        InfantSlashToddler = -4,

        [EnumMember(Value = "PR")]
        Preschool = -3,

        [EnumMember(Value = "PK")]
        Prekindergarten = -2,

        [EnumMember(Value = "TK")]
        TransitionalKindergarten = -1,

        [EnumMember(Value = "KG")]
        Kindergarten = 0,

        [EnumMember(Value = "01")]
        FirstGrade = 1,

        [EnumMember(Value = "02")]
        SecondGrade = 2,

        [EnumMember(Value = "03")]
        ThirdGrade = 3,

        [EnumMember(Value = "04")]
        FourthGrade = 4,

        [EnumMember(Value = "05")]
        FifthGrade = 5,

        [EnumMember(Value = "06")]
        SixthGrade = 6,

        [EnumMember(Value = "07")]
        SeventhGrade = 7,

        [EnumMember(Value = "08")]
        EighthGrade = 8,

        [EnumMember(Value = "09")]
        NinthGrade = 9,

        [EnumMember(Value = "10")]
        TenthGrade = 10,

        [EnumMember(Value = "11")]
        EleventhGrade = 11,

        [EnumMember(Value = "12")]
        TwelfthGrade = 12,

        [EnumMember(Value = "13")]
        ThirteenthGrade = 13,

        [EnumMember(Value = "PS")]
        PostSecondary = 20,

        [EnumMember(Value = "UG")]
        Ungraded = 98,

        [EnumMember(Value = "Other")]
        Other = 99
    }
}