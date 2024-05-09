using System.Text.RegularExpressions;

namespace Task001
{
    //  Напишите консольное приложение, позволяющие пользователю зарегистрироваться под
    //  «Логином», состоящем только из символов латинского алфавита, и пароля, состоящего из
    //  цифр и символов.
    internal class Program
    {
        static void Main(string[] args)
        {
            string loginPattern = "^[A-Za-z]+$";
            string passwordPattern = "^[A-Za-z0-9]+$";

            Console.Write("Enter your login: ");
            string? login = Console.ReadLine();
           
            if (!Regex.IsMatch(login, loginPattern))
            {
                Console.WriteLine("You entered wrong login.");
                return;
            }

            Console.Write("Enter your password: ");
            string? password = Console.ReadLine();

            if (!Regex.IsMatch(password, passwordPattern))
            {
                Console.WriteLine("You entered wrong password.");
                return;
            }

            Console.WriteLine("The registration was successful.");
        }
    }
}