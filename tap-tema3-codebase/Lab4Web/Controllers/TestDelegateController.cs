using Lab4Web.Services.Delegate;
using Microsoft.AspNetCore.Mvc;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDelegateController : ControllerBase
    {
        private readonly IDelegateService _delegateService;

        public TestDelegateController(IDelegateService delegateService)
        {
            _delegateService = delegateService;
        }

        [HttpGet("test-1")]
        public string Test1(string name)
        {
            var callback = _delegateService.Hello;

            return _delegateService.Introduction(name, callback);
        }

        [HttpGet("test-2")]
        public string Test2(string name, bool welcome)
        {
            var callback1 = _delegateService.Hello;
            var callback2 = (string firstname, string lastname) => $"Bye, {firstname} {lastname}";

            var callback = welcome ? callback1 : callback2;

            return _delegateService.Introduction(name, callback);
        }

        [HttpGet("test-3")]
        public string Test3(string name, bool exists, bool what)
        {
            var callbackTrue = _delegateService.NameExists;
            var callbackFalse = _delegateService.NameDoesntExist;
            var callbackWhat = (string firstname, string lastname) => $"What about the name: \"{firstname} {lastname}\"?";

            var callback = exists ? callbackTrue : callbackFalse;

            callback = what ? callbackWhat : callback;

            return _delegateService.Introduction(name, callback);
        }

        [HttpGet("test-4")]
        public string Test4(string message)
        {
            var callbacks = new List<Func<string, string>>()
            {
                _delegateService.FirstMethod,
                _delegateService.SecondMethod
            };
            return _delegateService.ConsecutiveMessages(message, callbacks);
        }

        [HttpGet("test-5")]
        public string Test5(string message, bool truth)
        {
            Func<string, string> callback;
            if (truth)
            {
                callback = (msg) =>
                {
                    return $"Lambda true: {msg}!";
                };
            }
            else callback = (msg) =>
            {
                return $"Lambda false: {msg}!";
            };
            return _delegateService.BasicMessage(message, callback);
        }
    }
}
