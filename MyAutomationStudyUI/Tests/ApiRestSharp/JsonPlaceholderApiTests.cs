using NUnit.Framework;
using System.Threading.Tasks;
using MyAutomationStudyUI.ApiRestSharp.JsonPlaceholder.Clients;
using MyAutomationStudyUI.ApiRestSharp.JsonPlaceholder.Builders;
using System.Net;
using MyAutomationStudyUI.TestData.Api;

namespace MyAutomationStudyUI.Tests.ApiRestSharp
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class JsonPlaceholderApiTests
    {
        [Test]
        [Category("API")]
        public async Task GetUsers_WhenRequestIsSent_ReturnsOkStatusCodeAndUsersList()
        {
            var client = new JsonPlaceholderClient();

            var response = await client.GetAllUsersAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data, Is.Not.Empty);
        }

        [Test]
        [Category("API")]
        public async Task CreateUser_WhenValidNameAndUsernameAreSent_ReturnsCreatedUserWithId()
        {
            var builder = new CreateUserRequestBuilder()
                .WithName(JsonPlaceholderTestData.ValidUserName)
                .WithUsername(JsonPlaceholderTestData.ValidUsername);

            var request = builder.Build();

            var client = new JsonPlaceholderClient();
            var response = await client.CreateUserAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Id, Is.GreaterThan(0));
            Assert.That(response.Data.Name, Is.EqualTo(request.Name));
            Assert.That(response.Data.Username, Is.EqualTo(request.Username));
            
        }

        [Test]
        [Category("API")]
        public async Task GetUserById_WhenValidIdIsProvided_ReturnsUser()
        {
            // Arrange
            var client = new JsonPlaceholderClient();
            var userId = JsonPlaceholderTestData.ExistingUserId;

            // Act
            var response = await client.GetUserByIdAsync(userId);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);

            Assert.That(response.Data!.Id, Is.EqualTo(userId));
            Assert.That(response.Data.Name, Is.EqualTo(JsonPlaceholderTestData.ExistingUserName));
            Assert.That(response.Data.Username, Is.EqualTo(JsonPlaceholderTestData.ExistingUsername));
            Assert.That(response.Data.Email, Is.EqualTo(JsonPlaceholderTestData.ExistingUserEmail));
        }

        [Test]
        [Category("API")]
        public async Task DeleteUser_WhenValidUserIdIsSent_ReturnsSuccessfulStatusCode()
        {
            // Arrange
            var client = new JsonPlaceholderClient();
            var userId = JsonPlaceholderTestData.ExistingUserId;

            // Act
            var response = await client.DeleteUserAsync(userId);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}

