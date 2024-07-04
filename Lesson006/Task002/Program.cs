using System.Reflection;

//    Создайте программу, в которой предоставьте пользователю доступ к сборке из Задания 2.
//    Реализуйте использование метода конвертации значения температуры из шкалы Цельсия в
//    шкалу Фаренгейта.Выполняя задание используйте только рефлексию.
decimal temperature = 200;
Assembly? assembly = null;

try
{
    assembly = Assembly.LoadFrom("D:\\ITVDN\\ITVDN_C#_Advanced_HomeWork\\Lesson006\\TemperatureConverter\\bin\\Debug\\net6.0\\TemperatureConverter.dll");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}

if (assembly != null)
{
    Type? type = assembly.GetType("TemperatureConverter.Temperature");

    if (type != null )
    {
        object? instance = Activator.CreateInstance(type, new object[] { temperature });
        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            Console.WriteLine("{0}C = {1} {2}", temperature, property.GetValue(instance), property.Name);
        }
    }
}



