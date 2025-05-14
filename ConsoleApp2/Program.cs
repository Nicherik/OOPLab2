using System;
using System.Threading.Tasks;
using ConsoleApp2.Classes;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Асинхронное приложение: Начало работы");
            var stopwatch = TimerUtility.StartTimer();

            try
            {
                // Создаем три асинхронных задачи с задержками
                var task1 = MakeDelayedRequest("https://jsonplaceholder.typicode.com/posts/1", 2000);
                var task2 = MakeDelayedRequest("https://jsonplaceholder.typicode.com/posts/2", 3000);
                var task3 = MakeDelayedRequest("https://jsonplaceholder.typicode.com/posts/3", 1000);

                // Выполняем все задачи параллельно
                var responses = await Task.WhenAll(task1, task2, task3);

                Console.WriteLine("Ответ от сервера 1:\n" + responses[0]);
                Console.WriteLine("Ответ от сервера 2:\n" + responses[1]);
                Console.WriteLine("Ответ от сервера 3:\n" + responses[2]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }

            Console.WriteLine($"Общее время работы: {TimerUtility.GetElapsedMilliseconds(stopwatch)} мс");
        }

        // Метод для выполнения запроса с задержкой
        private static async Task<string> MakeDelayedRequest(string url, int delay)
        {
            Console.WriteLine($"Задержка перед запросом: {delay} мс");
            await Task.Delay(delay);
            return await RequestService.MakeRequestAsync(url);
        }
    }
}
