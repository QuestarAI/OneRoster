// ReSharper disable InconsistentNaming

using System.Runtime.Serialization;

namespace Questar.OneRoster.Models
{
    /// <summary>
    ///     State code vocabulary provided by the Common Education Data Standards (CEDS),
    ///     represented by unique two digit abbreviations for the name of the state (within the United States)
    ///     or extra-state jurisdiction.
    ///     See https://ceds.ed.gov/CEDSElementDetails.aspx?TermxTopicId=20837 for more details.
    /// </summary>
    public enum StateCode
    {
        [EnumMember(Value = "AK")] Alaska,

        [EnumMember(Value = "AL")] Alabama,

        [EnumMember(Value = "AR")] Arkansas,

        [EnumMember(Value = "AS")] AmericanSamoa,

        [EnumMember(Value = "AZ")] Arizona,

        [EnumMember(Value = "CA")] California,

        [EnumMember(Value = "CO")] Colorado,

        [EnumMember(Value = "CT")] Connecticut,

        [EnumMember(Value = "DC")] DistrictOfColumbia,

        [EnumMember(Value = "DE")] Delaware,

        [EnumMember(Value = "FL")] Florida,

        [EnumMember(Value = "FM")] FederatedStatesOfMicronesia,

        [EnumMember(Value = "GA")] Georgia,

        [EnumMember(Value = "GU")] Guam,

        [EnumMember(Value = "HI")] Hawaii,

        [EnumMember(Value = "IA")] Iowa,

        [EnumMember(Value = "ID")] Idaho,

        [EnumMember(Value = "IL")] Illinois,

        [EnumMember(Value = "IN")] Indiana,

        [EnumMember(Value = "KS")] Kansas,

        [EnumMember(Value = "KY")] Kentucky,

        [EnumMember(Value = "LA")] Louisiana,

        [EnumMember(Value = "MA")] Massachusetts,

        [EnumMember(Value = "MD")] Maryland,

        [EnumMember(Value = "ME")] Maine,

        [EnumMember(Value = "MH")] MarshallIslands,

        [EnumMember(Value = "MI")] Michigan,

        [EnumMember(Value = "MN")] Minnesota,

        [EnumMember(Value = "MO")] Missouri,

        [EnumMember(Value = "MP")] NorthernMarianas,

        [EnumMember(Value = "MS")] Mississippi,

        [EnumMember(Value = "MT")] Montana,

        [EnumMember(Value = "NC")] NorthCarolina,

        [EnumMember(Value = "ND")] NorthDakota,

        [EnumMember(Value = "NE")] Nebraska,

        [EnumMember(Value = "NH")] NewHampshire,

        [EnumMember(Value = "NJ")] NewJersey,

        [EnumMember(Value = "NM")] NewMexico,

        [EnumMember(Value = "NV")] Nevada,

        [EnumMember(Value = "NY")] NewYork,

        [EnumMember(Value = "OH")] Ohio,

        [EnumMember(Value = "OK")] Oklahoma,

        [EnumMember(Value = "OR")] Oregon,

        [EnumMember(Value = "PA")] Pennsylvania,

        [EnumMember(Value = "PR")] PuertoRico,

        [EnumMember(Value = "PW")] Palau,

        [EnumMember(Value = "RI")] RhodeIsland,

        [EnumMember(Value = "SC")] SouthCarolina,

        [EnumMember(Value = "SD")] SouthDakota,

        [EnumMember(Value = "TN")] Tennessee,

        [EnumMember(Value = "TX")] Texas,

        [EnumMember(Value = "UT")] Utah,

        [EnumMember(Value = "VA")] Virginia,

        [EnumMember(Value = "VI")] VirginIslands,

        [EnumMember(Value = "VT")] Vermont,

        [EnumMember(Value = "WA")] Washington,

        [EnumMember(Value = "WI")] Wisconsin,

        [EnumMember(Value = "WV")] WestVirginia,

        [EnumMember(Value = "WY")] Wyoming
    }
}