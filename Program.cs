using System;

namespace EnvironmentVariablesTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine($"OS : {Environment.OSVersion}");
            System.Console.WriteLine("Setting Environment Variables on all 3 targets");
            
            
            Environment.SetEnvironmentVariable("EnvTarget-Machine","EnvironmentVariableTarget.Machine", EnvironmentVariableTarget.Machine);
            Environment.SetEnvironmentVariable("EnvTarget-Process","EnvironmentVariableTarget.Process", EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("EnvTarget-User","EnvironmentVariableTarget.User", EnvironmentVariableTarget.User);
            
            System.Console.WriteLine(Environment.NewLine + "EnvironmentVariableTarget.Machine : ");
            foreach(System.Collections.DictionaryEntry variable in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine))
            {
                System.Console.WriteLine($"{variable.Key} = {variable.Value}");
            }
             System.Console.WriteLine(Environment.NewLine + "EnvironmentVariableTarget.User : ");
            foreach(System.Collections.DictionaryEntry variable in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User))
            {
                System.Console.WriteLine($"{variable.Key} = {variable.Value}");
            }
            System.Console.WriteLine(Environment.NewLine + "EnvironmentVariableTarget.Process : ");
            foreach(System.Collections.DictionaryEntry variable in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process))
            {
                System.Console.WriteLine($"{variable.Key} = {variable.Value}");
            }
        }
    }
}
