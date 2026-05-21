

namespace MyAutomationStudyUI.ApiRestSharp.JsonPlaceholder.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using RestSharp;
    using MyAutomationStudyUI.Core.Api;
    using MyAutomationStudyUI.ApiRestSharp.JsonPlaceholder.Configuration;
    using MyAutomationStudyUI.ApiRestSharp.JsonPlaceholder.Models;

    public class JsonPlaceholderClient : BaseApiClient
    {
        public JsonPlaceholderClient() : base(ApiEndpoints.BaseUrl)
        {
        }

        public Task<RestResponse<List<User>>> GetAllUsersAsync()
        {
            var request = CreateRequest(ApiEndpoints.Users);
            return ExecuteAsync<List<User>>(request);
        }

        public Task<RestResponse<CreateUserResponse>> CreateUserAsync(CreateUserRequest userRequest)
        {
            var request = CreateRequest(ApiEndpoints.Users, Method.Post);
            request.AddJsonBody(userRequest);

            return ExecuteAsync<CreateUserResponse>(request);
        }
    }
}
