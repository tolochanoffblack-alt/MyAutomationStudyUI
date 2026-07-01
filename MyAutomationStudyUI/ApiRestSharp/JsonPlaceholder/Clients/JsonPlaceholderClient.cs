

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

        public Task<RestResponse<User>> GetUserByIdAsync(int userId)
        {
            var request = CreateRequest($"{ApiEndpoints.Users}/{userId}");
            return ExecuteAsync<User>(request);
        }
        public Task<RestResponse<CreateUserResponse>> CreateUserAsync(CreateUserRequest userRequest)
        {
            var request = CreateRequest(ApiEndpoints.Users, Method.Post);
            request.AddJsonBody(userRequest);

            return ExecuteAsync<CreateUserResponse>(request);
        }

        public Task<RestResponse> DeleteUserAsync(int userId)
        {
            var request = CreateRequest($"{ApiEndpoints.Users}/{userId}", Method.Delete);
            return ExecuteAsync(request);
        }

        public Task<RestResponse<User>> UpdateUserAsync(int userId, CreateUserRequest userRequest)
        {
            var request = CreateRequest($"{ApiEndpoints.Users}/{userId}", Method.Put);
            request.AddJsonBody(userRequest);

            return ExecuteAsync<User>(request);
        }
    }
}
