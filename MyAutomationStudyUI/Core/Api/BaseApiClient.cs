



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

        protected Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            return client.ExecuteAsync(request);
        }

        protected Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request)
        {
            return client.ExecuteAsync<T>(request);
        }
    }
}
