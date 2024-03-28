namespace Lab4Web.Services.Lambda
{
    public interface ILambdaService
    {
        Tuple<int, int, int> Test1(int value);

        bool Test2(string value);

        Task<string> Test3Async(string value);
        void noParamLambda();
        void oneParamLambda(string name);
        int twoParamLambda(int a, int b);
        void ignoreParamLambda(int _, int __);
        string defaultParamLambda(int start = 0, int end = 10);
        int tupleParamLambda((int, int) tuple);
        Task<string> Test2Async(int seconds);
    }
}
