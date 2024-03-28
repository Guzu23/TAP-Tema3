using Lab4Web.Services.Lambda;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLambdaController : ControllerBase
    {
        private readonly ILambdaService _lambdaService;

        public TestLambdaController(ILambdaService lambdaService)
        {
            _lambdaService = lambdaService;
        }

        [HttpGet("test-1")]
        public string Get(int value)
        {
            var tupleValue = _lambdaService.Test1(value);
            return $"{tupleValue.Item1} / {tupleValue.Item2} / {tupleValue.Item3}";
        }

        [HttpGet("test-2")]
        public string Test2(string value)
        {
            return _lambdaService.Test2(value) ? "Number" : "Not number";
        }

        [HttpGet("test-3")]
        public string Test3(string value)
        {
            var result = _lambdaService.Test3Async(value).Result;
            return result;
        }

        [HttpGet("test-4")]
        public string Test4(string value)
        {
            var result = _lambdaService.Test3Async(value).Result;
            return result;
        }

        [HttpGet("test-5")]
        public string Test5()
        {
            _lambdaService.noParamLambda();

            return "Metoda noParamLambda() a fost executata. verificati consola!";
            
        }

        [HttpGet("test-6")]
        public string Test6(string name)
        {
            _lambdaService.oneParamLambda(name);
            return $"Metoda oneParamLambda({name}) a fost executata. verificati consola!";

        }

        [HttpGet("test-7")]
        public int Test7(int a, int b)
        {
            return _lambdaService.twoParamLambda(a, b);
        }

        [HttpGet("test-8")]
        public string Test8(int a, int b)
        {
            _lambdaService.ignoreParamLambda(a, b);
            return $"Metoda ignoreParamLambda({a}, {b}) a fost executata. verificati consola!";
        }

        [HttpGet("test-9")]
        public string Test9(int a, int b)
        {
            return _lambdaService.defaultParamLambda();
        }

        [HttpGet("test-10")]
        public int Test10((int, int) tuple)
        {
            return _lambdaService.tupleParamLambda(tuple);
        }

        [HttpGet("test-11")]
        public string Test11(int seconds)
        {
            var awaitTimeMessage = _lambdaService.Test2Async(seconds).Result;
            return awaitTimeMessage;
        }
    }
}
