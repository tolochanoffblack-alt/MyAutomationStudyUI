


using System;
using System.Threading.Tasks;
using RestSharp;

namespace MyAutomationStudyUI.Core.Api
{
   

    public abstract class BaseApiClient
    {
        protected readonly RestClient client;

        public BaseApiClient(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        protected RestRequest CreateRequest(string resource, Method method = Method.Get)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Accept", "application/json");
            return request;
        }

        protected async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            var response = await client.ExecuteAsync(request);

            if (response.ResponseStatus == ResponseStatus.Error)
            {
                throw new InvalidOperationException(
                    $"API request failed. Method: {request.Method}, Resource: {request.Resource}. Error: {response.ErrorMessage}",
                    response.ErrorException);
            }

            return response;
        }

        protected async Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request)
        {
            var response = await client.ExecuteAsync<T>(request);

            if (response.ResponseStatus == ResponseStatus.Error)
            {
                throw new InvalidOperationException(
                    $"API request failed. Method: {request.Method}, Resource: {request.Resource}. Error: {response.ErrorMessage}",
                    response.ErrorException);
            }

            return response;
        }
    }
}
