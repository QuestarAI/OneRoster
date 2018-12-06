namespace Questar.OneRoster.Data.Test
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Mappings;
    using Xunit;
    using User = Data.User;

    public class UserProfileTest : ProfileTest<User, Models.User>
    {
        public UserProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<MetadataProfile>();
            config.AddProfile<UserIdProfile>();
            config.AddProfile<UserProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromAgents()
            => CanMapFrom(entity => entity.Agents, model => model.Agents);

        [Fact]
        public void CanMapFromDateLastModified()
            => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        [Fact]
        public void CanMapFromEmail()
            => CanMapFrom(entity => entity.Email, model => model.Email);

        [Fact]
        public void CanMapFromEnabledUser()
            => CanMapFrom(entity => entity.Enabled, model => model.EnabledUser);

        [Fact]
        public void CanMapFromFamilyName()
            => CanMapFrom(entity => entity.FamilyName, model => model.FamilyName);

        [Fact]
        public void CanMapFromGivenName()
            => CanMapFrom(entity => entity.GivenName, model => model.GivenName);

        [Fact]
        public void CanMapFromGrades()
            => CanMapFrom(entity => entity.Grades.Select(relationship => relationship.Grade.Code), model => model.Grades);

        [Fact]
        public void CanMapFromIdentifier()
            => CanMapFrom(entity => entity.Identifier, model => model.Identifier);

        [Fact]
        public void CanMapFromMetadata()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata, model => model.Metadata);

        [Fact]
        public void CanMapFromMetadataWithProjection()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata.Any(metadata => metadata.Key == "foo"), model => model.Metadata.Any(metadata => metadata.Key == "foo"));

        [Fact]
        public void CanMapFromMiddleName()
            => CanMapFrom(entity => entity.MiddleName, model => model.MiddleName);

        [Fact]
        public void CanMapFromOrgs()
            => CanMapFrom(entity => entity.Orgs, model => model.Orgs);

        [Fact]
        public void CanMapFromPassword()
            => CanMapFrom(entity => entity.PasswordHash, model => model.Password);

        [Fact]
        public void CanMapFromPhone()
            => CanMapFrom(entity => entity.Phone, model => model.Phone);

        [Fact]
        public void CanMapFromRole()
            => CanMapFrom(entity => (UserType) entity.Type, model => model.Role);

        [Fact]
        public void CanMapFromSms()
            => CanMapFrom(entity => entity.Sms, model => model.Sms);

        [Fact]
        public void CanMapFromSourcedId()
            => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStatusType()
            => CanMapFrom(entity => entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapFromUserIds()
            => CanMapFrom(entity => entity.Ids, model => model.UserIds);

        [Fact]
        public void CanMapFromUsername()
            => CanMapFrom(entity => entity.UserName, model => model.Username);
    }
}