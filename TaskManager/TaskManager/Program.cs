using System.Data;
using System.Diagnostics;

namespace TaskManager
{

    public class ConsoleContoller
    {
        public void Command()
        {
            bool isOpen = true;
            while (isOpen)
            {
                Console.Clear();

                Console.Write("command> ");
                string command = Console.ReadLine().ToLower();

                if (command == "help")
                {
                    PrintHelpInformation();
                }
                else if (command == "taskkist")
                {
                    PrintTaskList();
                    Console.WriteLine();
                }
                else if (command == "exit")
                {
                    isOpen = false;
                }
                else if (command.IndexOf("killbyid") != -1)
                {
                    KillBySomthing(command);
                }
                else if (command.IndexOf("killbyname") != -1)
                {
                    KillBySomthing(command);
                }
                else if (command.IndexOf("processid") != -1)
                {
                    FindIdByName(command);
                }
                Console.ReadKey();
            }
        }

        public void PrintTaskList()
        {
            var tasks = Process.GetProcesses();
            for (int i = 0; i < tasks.Length; ++i)
            {
                Console.WriteLine($"{tasks[i].ProcessName, -40} | {tasks[i].Id}");
            }

        }

        public void PrintHelpInformation()
        {
            Console.WriteLine("exit - выход из приложения" +
                        "\nKillById <id процесса> - завершение по Id" +
                        "\nKillByName <имя процесса> - завершение процесса по имени" +
                        "\nTaskList - вывод списка процессов" +
                        "\nProcessId <имя процесса> - определение id процесса по его имени (без учёта регистра)");
        }

        public void KillBySomthing(string get_value)
        {
            var tasks = Process.GetProcesses();
            string[] s = get_value.Split(' ');
            dynamic value = s[1];
            for (int i = 0; i < tasks.Length; ++i)
            {
                if (s[0] == "KillByName" && tasks[i].ProcessName == value)
                {
                    tasks[i].Kill();
                }
                else if (s[0] == "KillById" && tasks[i].Id == Convert.ToInt32(value))
                {
                    tasks[i].Kill();
                }
            }
        }

        public void FindIdByName(string get_id)
        {
            var tasks = Process.GetProcesses();
            string[] s = get_id.Split(' ');
            string name = s[1];
            for (int i = 0; i < tasks.Length; ++i)
            {
                if (tasks[i].ProcessName == name)
                {
                    Console.WriteLine($"Id {tasks[i].ProcessName} - {tasks[i].Id} ");
                }
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleContoller obj = new ConsoleContoller();
            obj.Command();
        }
    }
}