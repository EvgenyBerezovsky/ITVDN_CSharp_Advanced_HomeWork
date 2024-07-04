namespace Task001
{
    //      Создайте программу-рефлектор, которая позволит получить информацию о сборке
    //  и входящих в ее состав типах.Для основы можно использовать  программу-рефлектор
    //  из урока.

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}