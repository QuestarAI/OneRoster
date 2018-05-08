namespace Questar.OneRoster.Vocabulary.Ceds
{
    using Serialization;

    public enum PublicSchoolResidenceStatus
    {
        [SerializationToken("01652")]
        ResidentOfAdministrativeUnitAndUsualSchoolAttendanceArea = 1652,

        [SerializationToken("01653")]
        ResidentOfAdministrativeUnitButOfOtherSchoolAttendanceArea = 1653,

        [SerializationToken("01654")]
        ResidentOfThisStateButNotOfThisAdministrativeUnit = 1654,

        [SerializationToken("01655")]
        ResidentOfAnAdministrativeUnitThatCrossesStateBoundaries = 1655,

        [SerializationToken("01656")]
        ResidentOfAnotherState = 1656,
    }
}
