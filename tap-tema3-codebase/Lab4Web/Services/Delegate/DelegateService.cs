using System;

namespace Lab4Web.Services.Delegate
{
    public class DelegateService : IDelegateService
    {
        public string Introduction(string value, Func<string, string, string> callback)
        {
            var name = value.ToUpper();
            return callback(name, "(Student)");
        }

        public string Hello(string firstname, string lastname)
        {
            return $"Hello, {firstname} {lastname}";
        }

        public delegate void basicDelegate(string message);

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintNamedDelegate()
        {
            basicDelegate log = new basicDelegate(Log);
            log("Acesta este un Named(method) Delegate");
        }

        public string NameExists(string firstname, string lastname)
        {
            return $"The name: \"{firstname} {lastname}\" exists!";
        }

        public string NameDoesntExist(string firstname, string lastname)
        {
            return $"The name: \"{firstname} {lastname}\" doesn't exist!";
        }

        public string WorkMethod(string value, Func<string, string, string> callback)
        {
            return callback(value.ToLower(), "LastName");
        }

        public string FirstMethod(string message)
        {
            return $"First method: {message}\n";
        }

        public string SecondMethod(string message)
        {
            return $"Second method: {message}\n";
        }

        public string ConsecutiveMessages(string message, List<Func<string, string>> callbacks)
        {
            var result = "";
            foreach (var callback in callbacks)
            {
                result += callback(message.ToLower()) + "\n";
            }
            return result;
        }
        
        public string BasicMessage(string message, Func<string, string> callback)
        {
            var msg = message.ToUpper() + "BASIC";
            return callback(msg);
        }
    }
}
