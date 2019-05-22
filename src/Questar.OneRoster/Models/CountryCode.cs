// ReSharper disable InconsistentNaming

namespace Questar.OneRoster.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Country code vocabulary provided by the Common Education Data Standards (CEDS),
    /// represented by unique two digit International Organization for Standardization (ISO) codes.
    /// See https://ceds.ed.gov/CEDSElementDetails.aspx?TermxTopicId=20002 for more details.
    /// </summary>
    public enum CountryCode
    {
        [EnumMember(Value = "AF")]
        Afghanistan,

        [EnumMember(Value = "AX")]
        AlandIslands,

        [EnumMember(Value = "AL")]
        Albania,

        [EnumMember(Value = "DZ")]
        Algeria,

        [EnumMember(Value = "AS")]
        AmericanSamoa,

        [EnumMember(Value = "AD")]
        Andorra,

        [EnumMember(Value = "AO")]
        Angola,

        [EnumMember(Value = "AI")]
        Anguilla,

        [EnumMember(Value = "AQ")]
        Antarctica,

        [EnumMember(Value = "AG")]
        AntiguaAndBarbuda,

        [EnumMember(Value = "AR")]
        Argentina,

        [EnumMember(Value = "AM")]
        Armenia,

        [EnumMember(Value = "AW")]
        Aruba,

        [EnumMember(Value = "AU")]
        Australia,

        [EnumMember(Value = "AT")]
        Austria,

        [EnumMember(Value = "AZ")]
        Azerbaijan,

        [EnumMember(Value = "BS")]
        Bahamas,

        [EnumMember(Value = "BH")]
        Bahrain,

        [EnumMember(Value = "BD")]
        Bangladesh,

        [EnumMember(Value = "BB")]
        Barbados,

        [EnumMember(Value = "BY")]
        Belarus,

        [EnumMember(Value = "BE")]
        Belgium,

        [EnumMember(Value = "BZ")]
        Belize,

        [EnumMember(Value = "BJ")]
        Benin,

        [EnumMember(Value = "BM")]
        Bermuda,

        [EnumMember(Value = "BT")]
        Bhutan,

        [EnumMember(Value = "BO")]
        BoliviaPlurinationalStateOf,

        [EnumMember(Value = "BQ")]
        BonaireSintEustatiusAndSaba,

        [EnumMember(Value = "BA")]
        BosniaAndHerzegovina,

        [EnumMember(Value = "BW")]
        Botswana,

        [EnumMember(Value = "BV")]
        BouvetIsland,

        [EnumMember(Value = "BR")]
        Brazil,

        [EnumMember(Value = "IO")]
        BritishIndianOceanTerritory,

        [EnumMember(Value = "BN")]
        BruneiDarussalam,

        [EnumMember(Value = "BG")]
        Bulgaria,

        [EnumMember(Value = "BF")]
        BurkinaFaso,

        [EnumMember(Value = "BI")]
        Burundi,

        [EnumMember(Value = "KH")]
        Cambodia,

        [EnumMember(Value = "CM")]
        Cameroon,

        [EnumMember(Value = "CA")]
        Canada,

        [EnumMember(Value = "CV")]
        CaboVerde,

        [EnumMember(Value = "KY")]
        CaymanIslands,

        [EnumMember(Value = "CF")]
        CentralAfricanRepublic,

        [EnumMember(Value = "TD")]
        Chad,

        [EnumMember(Value = "CL")]
        Chile,

        [EnumMember(Value = "CN")]
        China,

        [EnumMember(Value = "CX")]
        ChristmasIsland,

        [EnumMember(Value = "CC")]
        CocosKeelingIslands,

        [EnumMember(Value = "CO")]
        Colombia,

        [EnumMember(Value = "KM")]
        Comoros,

        [EnumMember(Value = "CG")]
        Congo,

        [EnumMember(Value = "CD")]
        CongoDemocraticRepublicOfThe,

        [EnumMember(Value = "CK")]
        CookIslands,

        [EnumMember(Value = "CR")]
        CostaRica,

        [EnumMember(Value = "CI")]
        CoteDivoire,

        [EnumMember(Value = "HR")]
        Croatia,

        [EnumMember(Value = "CU")]
        Cuba,

        [EnumMember(Value = "CW")]
        Curacao,

        [EnumMember(Value = "CY")]
        Cyprus,

        [EnumMember(Value = "CZ")]
        CzechRepublic,

        [EnumMember(Value = "DK")]
        Denmark,

        [EnumMember(Value = "DJ")]
        Djibouti,

        [EnumMember(Value = "DM")]
        Dominica,

        [EnumMember(Value = "DO")]
        DominicanRepublic,

        [EnumMember(Value = "EC")]
        Ecuador,

        [EnumMember(Value = "EG")]
        Egypt,

        [EnumMember(Value = "SV")]
        ElSalvador,

        [EnumMember(Value = "GQ")]
        EquatorialGuinea,

        [EnumMember(Value = "ER")]
        Eritrea,

        [EnumMember(Value = "EE")]
        Estonia,

        [EnumMember(Value = "ET")]
        Ethiopia,

        [EnumMember(Value = "FK")]
        FalklandIslandsMalvinas,

        [EnumMember(Value = "FO")]
        FaroeIslands,

        [EnumMember(Value = "FJ")]
        Fiji,

        [EnumMember(Value = "FI")]
        Finland,

        [EnumMember(Value = "FR")]
        France,

        [EnumMember(Value = "GF")]
        FrenchGuiana,

        [EnumMember(Value = "PF")]
        FrenchPolynesia,

        [EnumMember(Value = "TF")]
        FrenchSouthernTerritories,

        [EnumMember(Value = "GA")]
        Gabon,

        [EnumMember(Value = "GM")]
        Gambia,

        [EnumMember(Value = "GE")]
        Georgia,

        [EnumMember(Value = "DE")]
        Germany,

        [EnumMember(Value = "GH")]
        Ghana,

        [EnumMember(Value = "GI")]
        Gibraltar,

        [EnumMember(Value = "GR")]
        Greece,

        [EnumMember(Value = "GL")]
        Greenland,

        [EnumMember(Value = "GD")]
        Grenada,

        [EnumMember(Value = "GP")]
        Guadeloupe,

        [EnumMember(Value = "GU")]
        Guam,

        [EnumMember(Value = "GT")]
        Guatemala,

        [EnumMember(Value = "GG")]
        Guernsey,

        [EnumMember(Value = "GN")]
        Guinea,

        [EnumMember(Value = "GW")]
        GuineaBissau,

        [EnumMember(Value = "GY")]
        Guyana,

        [EnumMember(Value = "HT")]
        Haiti,

        [EnumMember(Value = "HM")]
        HeardIslandAndMcdonaldIslands,

        [EnumMember(Value = "VA")]
        HolySee,

        [EnumMember(Value = "HN")]
        Honduras,

        [EnumMember(Value = "HK")]
        HongKong,

        [EnumMember(Value = "HU")]
        Hungary,

        [EnumMember(Value = "IS")]
        Iceland,

        [EnumMember(Value = "IN")]
        India,

        [EnumMember(Value = "ID")]
        Indonesia,

        [EnumMember(Value = "IR")]
        IranIslamicRepublicOf,

        [EnumMember(Value = "IQ")]
        Iraq,

        [EnumMember(Value = "IE")]
        Ireland,

        [EnumMember(Value = "IM")]
        IsleOfMan,

        [EnumMember(Value = "IL")]
        Israel,

        [EnumMember(Value = "IT")]
        Italy,

        [EnumMember(Value = "JM")]
        Jamaica,

        [EnumMember(Value = "JP")]
        Japan,

        [EnumMember(Value = "JE")]
        Jersey,

        [EnumMember(Value = "JO")]
        Jordan,

        [EnumMember(Value = "KZ")]
        Kazakhstan,

        [EnumMember(Value = "KE")]
        Kenya,

        [EnumMember(Value = "KI")]
        Kiribati,

        [EnumMember(Value = "KP")]
        KoreaDemocraticPeoplesRepublicOf,

        [EnumMember(Value = "KR")]
        KoreaRepublicOf,

        [EnumMember(Value = "KW")]
        Kuwait,

        [EnumMember(Value = "KG")]
        Kyrgyzstan,

        [EnumMember(Value = "LA")]
        LaoPeoplesDemocraticRepublic,

        [EnumMember(Value = "LV")]
        Latvia,

        [EnumMember(Value = "LB")]
        Lebanon,

        [EnumMember(Value = "LS")]
        Lesotho,

        [EnumMember(Value = "LR")]
        Liberia,

        [EnumMember(Value = "LY")]
        Libya,

        [EnumMember(Value = "LI")]
        Liechtenstein,

        [EnumMember(Value = "LT")]
        Lithuania,

        [EnumMember(Value = "LU")]
        Luxembourg,

        [EnumMember(Value = "MO")]
        Macao,

        [EnumMember(Value = "MK")]
        MacedoniaTheFormerYugoslavRepublicOf,

        [EnumMember(Value = "MG")]
        Madagascar,

        [EnumMember(Value = "MW")]
        Malawi,

        [EnumMember(Value = "MY")]
        Malaysia,

        [EnumMember(Value = "MV")]
        Maldives,

        [EnumMember(Value = "ML")]
        Mali,

        [EnumMember(Value = "MT")]
        Malta,

        [EnumMember(Value = "MH")]
        MarshallIslands,

        [EnumMember(Value = "MQ")]
        Martinique,

        [EnumMember(Value = "MR")]
        Mauritania,

        [EnumMember(Value = "MU")]
        Mauritius,

        [EnumMember(Value = "YT")]
        Mayotte,

        [EnumMember(Value = "MX")]
        Mexico,

        [EnumMember(Value = "FM")]
        MicronesiaFederatedStatesOf,

        [EnumMember(Value = "MD")]
        MoldovaRepublicOf,

        [EnumMember(Value = "MC")]
        Monaco,

        [EnumMember(Value = "MN")]
        Mongolia,

        [EnumMember(Value = "ME")]
        Montenegro,

        [EnumMember(Value = "MS")]
        Montserrat,

        [EnumMember(Value = "MA")]
        Morocco,

        [EnumMember(Value = "MZ")]
        Mozambique,

        [EnumMember(Value = "MM")]
        Myanmar,

        [EnumMember(Value = "NA")]
        Namibia,

        [EnumMember(Value = "NR")]
        Nauru,

        [EnumMember(Value = "NP")]
        Nepal,

        [EnumMember(Value = "NL")]
        Netherlands,

        [EnumMember(Value = "NC")]
        NewCaledonia,

        [EnumMember(Value = "NZ")]
        NewZealand,

        [EnumMember(Value = "NI")]
        Nicaragua,

        [EnumMember(Value = "NE")]
        Niger,

        [EnumMember(Value = "NG")]
        Nigeria,

        [EnumMember(Value = "NU")]
        Niue,

        [EnumMember(Value = "NF")]
        NorfolkIsland,

        [EnumMember(Value = "MP")]
        NorthernMarianaIslands,

        [EnumMember(Value = "NO")]
        Norway,

        [EnumMember(Value = "OM")]
        Oman,

        [EnumMember(Value = "PK")]
        Pakistan,

        [EnumMember(Value = "PW")]
        Palau,

        [EnumMember(Value = "PS")]
        PalestineStateOf,

        [EnumMember(Value = "PA")]
        Panama,

        [EnumMember(Value = "PG")]
        PapuaNewGuinea,

        [EnumMember(Value = "PY")]
        Paraguay,

        [EnumMember(Value = "PE")]
        Peru,

        [EnumMember(Value = "PH")]
        Philippines,

        [EnumMember(Value = "PN")]
        Pitcairn,

        [EnumMember(Value = "PL")]
        Poland,

        [EnumMember(Value = "PT")]
        Portugal,

        [EnumMember(Value = "PR")]
        PuertoRico,

        [EnumMember(Value = "QA")]
        Qatar,

        [EnumMember(Value = "RE")]
        Reunion,

        [EnumMember(Value = "RO")]
        Romania,

        [EnumMember(Value = "RU")]
        RussianFederation,

        [EnumMember(Value = "RW")]
        Rwanda,

        [EnumMember(Value = "BL")]
        SaintBarthelemy,

        [EnumMember(Value = "SH")]
        SaintHelenaAscensionAndTristanDaCunha,

        [EnumMember(Value = "KN")]
        SaintKittsAndNevis,

        [EnumMember(Value = "LC")]
        SaintLucia,

        [EnumMember(Value = "MF")]
        SaintMartinFrenchPart,

        [EnumMember(Value = "PM")]
        SaintPierreAndMiquelon,

        [EnumMember(Value = "VC")]
        SaintVincentAndTheGrenadines,

        [EnumMember(Value = "WS")]
        Samoa,

        [EnumMember(Value = "SM")]
        SanMarino,

        [EnumMember(Value = "ST")]
        SaoTomeAndPrincipe,

        [EnumMember(Value = "SA")]
        SaudiArabia,

        [EnumMember(Value = "SN")]
        Senegal,

        [EnumMember(Value = "RS")]
        Serbia,

        [EnumMember(Value = "SC")]
        Seychelles,

        [EnumMember(Value = "SL")]
        SierraLeone,

        [EnumMember(Value = "SG")]
        Singapore,

        [EnumMember(Value = "SX")]
        SintMaartenDutchPart,

        [EnumMember(Value = "SK")]
        Slovakia,

        [EnumMember(Value = "SI")]
        Slovenia,

        [EnumMember(Value = "SB")]
        SolomonIslands,

        [EnumMember(Value = "SO")]
        Somalia,

        [EnumMember(Value = "ZA")]
        SouthAfrica,

        [EnumMember(Value = "GS")]
        SouthGeorgiaAndTheSouthSandwichIslands,

        [EnumMember(Value = "SS")]
        SouthSudan,

        [EnumMember(Value = "ES")]
        Spain,

        [EnumMember(Value = "LK")]
        SriLanka,

        [EnumMember(Value = "SD")]
        Sudan,

        [EnumMember(Value = "SR")]
        Suriname,

        [EnumMember(Value = "SJ")]
        SvalbardAndJanMayen,

        [EnumMember(Value = "SZ")]
        Swaziland,

        [EnumMember(Value = "SE")]
        Sweden,

        [EnumMember(Value = "CH")]
        Switzerland,

        [EnumMember(Value = "SY")]
        SyrianArabRepublic,

        [EnumMember(Value = "TW")]
        Taiwan,

        [EnumMember(Value = "TJ")]
        Tajikistan,

        [EnumMember(Value = "TZ")]
        TanzaniaUnitedRepublicOf,

        [EnumMember(Value = "TH")]
        Thailand,

        [EnumMember(Value = "TL")]
        TimorLeste,

        [EnumMember(Value = "TG")]
        Togo,

        [EnumMember(Value = "TK")]
        Tokelau,

        [EnumMember(Value = "TO")]
        Tonga,

        [EnumMember(Value = "TT")]
        TrinidadAndTobago,

        [EnumMember(Value = "TN")]
        Tunisia,

        [EnumMember(Value = "TR")]
        Turkey,

        [EnumMember(Value = "TM")]
        Turkmenistan,

        [EnumMember(Value = "TC")]
        TurksAndCaicosIslands,

        [EnumMember(Value = "TV")]
        Tuvalu,

        [EnumMember(Value = "UG")]
        Uganda,

        [EnumMember(Value = "UA")]
        Ukraine,

        [EnumMember(Value = "AE")]
        UnitedArabEmirates,

        [EnumMember(Value = "GB")]
        UnitedKingdomOfGreatBritainAndNorthernIreland,

        [EnumMember(Value = "US")]
        UnitedStatesOfAmerica,

        [EnumMember(Value = "UM")]
        UnitedStatesMinorOutlyingIslands,

        [EnumMember(Value = "UY")]
        Uruguay,

        [EnumMember(Value = "UZ")]
        Uzbekistan,

        [EnumMember(Value = "VU")]
        Vanuatu,

        [EnumMember(Value = "VE")]
        VenezuelaBolivarianRepublicOf,

        [EnumMember(Value = "VN")]
        Vietnam,

        [EnumMember(Value = "VG")]
        VirginIslandsBritish,

        [EnumMember(Value = "VI")]
        VirginIslandsUS,

        [EnumMember(Value = "WF")]
        WallisAndFutuna,

        [EnumMember(Value = "EH")]
        WesternSahara,

        [EnumMember(Value = "YE")]
        Yemen,

        [EnumMember(Value = "ZM")]
        Zambia,

        [EnumMember(Value = "ZW")]
        Zimbabwe
    }
}