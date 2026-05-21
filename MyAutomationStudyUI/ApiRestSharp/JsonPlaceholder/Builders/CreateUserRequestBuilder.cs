using MyAutomationStudyUI.ApiRestSharp.JsonPlaceholder.Models;

namespace MyAutomationStudyUI.ApiRestSharp.JsonPlaceholder.Builders
{
    public class CreateUserRequestBuilder
    {
        private readonly CreateUserRequest _request = new CreateUserRequest();

        public CreateUserRequestBuilder WithName(string name)
        {
            _request.Name = name;
            return this;
        }

        public CreateUserRequestBuilder WithUsername(string username)
        {
            _request.Username = username;
            return this;
        }

        public CreateUserRequest Build()
        {
            return _request;
        }
    }
}
