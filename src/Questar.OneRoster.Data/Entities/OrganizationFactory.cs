namespace Questar.OneRoster.Data.Entities
{
    public class OrganizationFactory
    {
        public Organization CreateDepartment()
        {
            return new Organization { Type = OrganizationType.Department };
        }

        public Organization CreateDistrict()
        {
            return new Organization { Type = OrganizationType.District };
        }

        public Organization CreateLocal()
        {
            return new Organization { Type = OrganizationType.Local };
        }

        public Organization CreateNational()
        {
            return new Organization { Type = OrganizationType.National };
        }

        public Organization CreateSchool()
        {
            return new Organization { Type = OrganizationType.School };
        }

        public Organization CreateState()
        {
            return new Organization { Type = OrganizationType.State };
        }
    }
}