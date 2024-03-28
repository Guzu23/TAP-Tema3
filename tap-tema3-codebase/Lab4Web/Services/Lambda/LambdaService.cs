namespace Lab4Web.Services.Lambda
{
    public class LambdaService : ILambdaService
    {
        public Tuple<int, int,int> Test1(int value)
        {
            var lambdaExp = (int num) => new Tuple<int, int, int>(num % 10, (num /= 10) % 10, (num /= 10) % 10);
            return lambdaExp(value);
        }

        public bool Test2(string value)
        {
            return int.TryParse(value, out _);
        }

        public async Task<string> Test3Async(string value)
        {
            var lambaExp = async (string v) =>
            {
                await Delay();
                return value.ToLower();
            };

            return await lambaExp(value);
        }


        public Task Delay()
        {
            return Task.Delay(10000);
        }
        
        
        

        public void noParamLambda()
        {
            Action sayHello = () => Console.WriteLine("Hello, World!");
            sayHello();
        }

        public void oneParamLambda(string name)
        {
            Action<string> greetByName = (name) => Console.WriteLine($"Hello, {name}");
            greetByName(name);
        }

        public int twoParamLambda(int a, int b)
        {
            Func<int, int, int> add = (a, b) => a + b;
            return add(a,b);
        }

        public void ignoreParamLambda(int _, int __)
        {
            Action<int, int> ignoreParams = (_, __) => Console.WriteLine("Params are ignored.");
            ignoreParams(13, 13);
        }

        public string defaultParamLambda(int start = 0, int end = 10)
        {
            return $"Start: {start}; Stop: {end}";
        }

        public int tupleParamLambda((int, int) tuple){
            Func<(int, int), int> sumTuple = (tuple) =>
            {
                Console.WriteLine($"Se aduna cele doua elemente din tuple: {tuple.Item1} + {tuple.Item2}");
                return tuple.Item1 + tuple.Item2;
            };
            return sumTuple(tuple);
        }

        public Task Delay(int seconds)
        {
            return Task.Delay(1000*seconds);
        }

        public async Task<string> Test2Async(int seconds)
        {
            var lambdaExp = (async () => await Delay(seconds));
            await lambdaExp();
            return $"Async operation completed. It took {seconds} seconds.";
        }

    }
}
