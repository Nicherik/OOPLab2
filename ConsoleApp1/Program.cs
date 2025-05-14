using System;
using System.Threading;
using ConsoleApp1.Classes;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Синхронное приложение: Начало работы");
            var stopwatch = TimerUtility.StartTimer();

            try
            {
                // Задержка перед первым запросом
                Console.WriteLine("Задержка перед запросом 1: 2000 мс");
                Thread.Sleep(2000);
                var response1 = RequestService.MakeRequest("https://jsonplaceholder.typicode.com/posts/1");

                // Задержка перед вторым запросом
                Console.WriteLine("Задержка перед запросом 2: 3000 мс");
                Thread.Sleep(3000);
                var response2 = RequestService.MakeRequest("https://jsonplaceholder.typicode.com/posts/2");

                // Задержка перед третьим запросом
                Console.WriteLine("Задержка перед запросом 3: 1000 мс");
                Thread.Sleep(1000);
                var response3 = RequestService.MakeRequest("https://jsonplaceholder.typicode.com/posts/3");

                Console.WriteLine("Ответ от сервера 1:\n" + response1);
                Console.WriteLine("Ответ от сервера 2:\n" + response2);
                Console.WriteLine("Ответ от сервера 3:\n" + response3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }

            Console.WriteLine($"Общее время работы: {TimerUtility.GetElapsedMilliseconds(stopwatch)} мс");
        }
    }
}