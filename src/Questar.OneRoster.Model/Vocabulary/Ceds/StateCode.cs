// ReSharper disable InconsistentNaming
namespace Questar.OneRoster.Model.Vocabulary.Ceds
{
    using Serialization;

    /// <summary>
    /// State code vocabulary provided by the Common Education Data Standards (CEDS),
    /// represented by unique two digit abbreviations for the name of the state (within the United States)
    /// or extra-state jurisdiction.
    /// See https://ceds.ed.gov/CEDSElementDetails.aspx?TermxTopicId=20837 for more details.
    /// </summary>
    public enum StateCode
    {

        [SerializationToken("AK")]
        Alaska,

        [SerializationToken("AL")]
        Alabama,

        [SerializationToken("AR")]
        Arkansas,

        [SerializationToken("AS")]
        AmericanSamoa,

        [SerializationToken("AZ")]
        Arizona,

        [SerializationToken("CA")]
        California,

        [SerializationToken("CO")]
        Colorado,

        [SerializationToken("CT")]
        Connecticut,

        [SerializationToken("DC")]
        DistrictOfColumbia,

        [SerializationToken("DE")]
        Delaware,

        [SerializationToken("FL")]
        Florida,

        [SerializationToken("FM")]
        FederatedStatesOfMicronesia,

        [SerializationToken("GA")]
        Georgia,

        [SerializationToken("GU")]
        Guam,

        [SerializationToken("HI")]
        Hawaii,

        [SerializationToken("IA")]
        Iowa,

        [SerializationToken("ID")]
        Idaho,

        [SerializationToken("IL")]
        Illinois,

        [SerializationToken("IN")]
        Indiana,

        [SerializationToken("KS")]
        Kansas,

        [SerializationToken("KY")]
        Kentucky,

        [SerializationToken("LA")]
        Louisiana,

        [SerializationToken("MA")]
        Massachusetts,

        [SerializationToken("MD")]
        Maryland,

        [SerializationToken("ME")]
        Maine,

        [SerializationToken("MH")]
        MarshallIslands,

        [SerializationToken("MI")]
        Michigan,

        [SerializationToken("MN")]
        Minnesota,

        [SerializationToken("MO")]
        Missouri,

        [SerializationToken("MP")]
        NorthernMarianas,

        [SerializationToken("MS")]
        Mississippi,

        [SerializationToken("MT")]
        Montana,

        [SerializationToken("NC")]
        NorthCarolina,

        [SerializationToken("ND")]
        NorthDakota,

        [SerializationToken("NE")]
        Nebraska,

        [SerializationToken("NH")]
        NewHampshire,

        [SerializationToken("NJ")]
        NewJersey,

        [SerializationToken("NM")]
        NewMexico,

        [SerializationToken("NV")]
        Nevada,

        [SerializationToken("NY")]
        NewYork,

        [SerializationToken("OH")]
        Ohio,

        [SerializationToken("OK")]
        Oklahoma,

        [SerializationToken("OR")]
        Oregon,

        [SerializationToken("PA")]
        Pennsylvania,

        [SerializationToken("PR")]
        PuertoRico,

        [SerializationToken("PW")]
        Palau,

        [SerializationToken("RI")]
        RhodeIsland,

        [SerializationToken("SC")]
        SouthCarolina,

        [SerializationToken("SD")]
        SouthDakota,

        [SerializationToken("TN")]
        Tennessee,

        [SerializationToken("TX")]
        Texas,

        [SerializationToken("UT")]
        Utah,

        [SerializationToken("VA")]
        Virginia,

        [SerializationToken("VI")]
        VirginIslands,

        [SerializationToken("VT")]
        Vermont,

        [SerializationToken("WA")]
        Washington,

        [SerializationToken("WI")]
        Wisconsin,

        [SerializationToken("WV")]
        WestVirginia,

        [SerializationToken("WY")]
        Wyoming,
    }
}
