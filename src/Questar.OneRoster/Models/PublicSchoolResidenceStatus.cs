namespace Questar.OneRoster.Models
{
    using System.Runtime.Serialization;

    public enum PublicSchoolResidenceStatus
    {
        [EnumMember(Value = "01652")]
        ResidentOfAdministrativeUnitAndUsualSchoolAttendanceArea = 1652,

        [EnumMember(Value = "01653")]
        ResidentOfAdministrativeUnitButOfOtherSchoolAttendanceArea = 1653,

        [EnumMember(Value = "01654")]
        ResidentOfThisStateButNotOfThisAdministrativeUnit = 1654,

        [EnumMember(Value = "01655")]
        ResidentOfAnAdministrativeUnitThatCrossesStateBoundaries = 1655,

        [EnumMember(Value = "01656")]
        ResidentOfAnotherState = 1656
    }
}