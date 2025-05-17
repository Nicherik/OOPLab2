using System;
using System.Threading.Tasks;
using ConsoleApp1.Classes;

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
                // Выполнение запросов последовательно с задержками
                await ExecuteRequestAsync("https://jsonplaceholder.typicode.com/posts/1", 2000);
                await ExecuteRequestAsync("https://jsonplaceholder.typicode.com/posts/2", 3000);
                await ExecuteRequestAsync("https://jsonplaceholder.typicode.com/posts/3", 1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            // Выводим общее время работы программы
            Console.WriteLine($"Общее время работы: {TimerUtility.GetElapsedMilliseconds(stopwatch)} мс");
        }

        // Метод для выполнения одного запроса с задержкой
        private static async Task ExecuteRequestAsync(string url, int delay)
        {
            Console.WriteLine($"Задержка перед запросом {url}: {delay} мс");
            await Task.Delay(delay);

            // Выполняем HTTP-запрос и выводим результат
            var response = await RequestService.MakeRequestAsync(url);
            Console.WriteLine($"Ответ от {url}:\n{response}");
        }
    }
}