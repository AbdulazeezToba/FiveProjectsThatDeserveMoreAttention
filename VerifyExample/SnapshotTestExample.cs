using System;
using System.Threading.Tasks;
using VerifyTests;
using VerifyXunit;
using Xunit;

namespace VerifyExample
{
    [UsesVerify]
    public class SnapshotTestExample
    {
        private readonly VerifySettings _verifySettings = new();

        public SnapshotTestExample()
        {
            _verifySettings
                .ModifySerialization(settings =>
                    settings.IgnoreMember<Person>(target => target.Age));
        }

        [Fact]
        public async Task GetById()
        {
            var id = new Guid("ebced679-45d3-4653-8791-3d969c4a986c");
            var person = new PeopleRepository().GetById(id);
            await Verifier.Verify(person, _verifySettings);
        }
    }
}
