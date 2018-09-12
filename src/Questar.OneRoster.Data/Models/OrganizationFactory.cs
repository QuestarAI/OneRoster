namespace Questar.OneRoster.Data.Models
{
    public class OrganizationFactory
    {
        public Organization BuildDepartment() => new Organization { Type = OrganizationType.Department };
        public Organization BuildDistrict() => new Organization { Type = OrganizationType.District };
        public Organization BuildLocal() => new Organization { Type = OrganizationType.Local };
        public Organization BuildNational() => new Organization { Type = OrganizationType.National };
        public Organization BuildSchool() => new Organization { Type = OrganizationType.School };
        public Organization BuildState() => new Organization { Type = OrganizationType.State };
    }
}