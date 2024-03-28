namespace Lab4Web.Services.Delegate
{
    public interface IDelegateService
    {
        string Introduction(string value, Func<string, string, string> callback);

        string Hello(string firstname, string lastname);

        string NameExists(string firstname, string lastname);
        string NameDoesntExist(string firstname, string lastname);
        string WorkMethod(string name, Func<string, string, string> callback);

        string FirstMethod(string message);
        string SecondMethod(string message);
        string ConsecutiveMessages(string message, List<Func<string, string>> callback);
        string BasicMessage(string message, Func<string, string> callback);
    }
}
