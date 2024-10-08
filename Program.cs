namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flight> flights = ImportFromFile("data.txt");

            Console.WriteLine("Список рейсов/билетов:\n");
            Console.WriteLine(string.Join("\n", flights));

            Console.ReadKey();

            bool closeApplication = false;
            while (!closeApplication)
            {
                Console.Clear();
                Console.WriteLine(
                    "1. Подобрать билет\n" +
                    "2. Выход"
                    );

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.NumPad1:
                        ChooseFlight(flights);
                        break;
                    case ConsoleKey.NumPad2:
                        closeApplication = true;
                        break;
                }
            }
        }

        private static void ChooseFlight(List<Flight> flights)
        {
            Console.Clear();
            Console.WriteLine("Введите параметры, по которым бы Вы хотели выбрать билет. Если параметр не важен, то оставьте его пустым.");

            Console.Write("Место назначения: ");
            string destination = Console.ReadLine()!;

            Console.Write("Минимальная дата вылета: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime minDepartureTime);

            Console.Write("Максимальная дата вылета: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime maxDepartureTime);

            Console.Write("Минимальная дата прилёта: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime minArrivalTime);

            Console.Write("Максимальная дата прилёта: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime maxArrivalTime);

            Console.Write("Введите минимальную стоимость поездки: ");
            int.TryParse(Console.ReadLine()!, out int minCost);

            Console.Write("Введите максимальную стоимость поездки: ");
            int.TryParse(Console.ReadLine()!, out int maxCost);

            // находим подходящие рейсы
            List<Flight> suitableFlights = 
                flights.FindFlightByParameters(destination, minDepartureTime, maxDepartureTime, minArrivalTime, maxArrivalTime, minCost, maxCost);

            // вывод тех параметров, которые ввел пользователь
            Console.Clear();
            Console.WriteLine("Вы ввели следующие параметры:\n");
            Console.Write(destination == string.Empty ? string.Empty : $"Место назначения: {destination}\n");
            Console.Write(minDepartureTime == DateTime.MinValue ? string.Empty : $"Минимальная дата вылета: {minDepartureTime}\n");
            Console.Write(maxDepartureTime == DateTime.MinValue ? string.Empty : $"Максимальная дата вылета: {maxDepartureTime}\n");
            Console.Write(minArrivalTime == DateTime.MinValue ? string.Empty : $"Минимальная дата прилёта: {minArrivalTime}\n");
            Console.Write(maxArrivalTime == DateTime.MinValue ? string.Empty : $"Максимальная дата прилёта: {maxArrivalTime}\n");
            Console.Write(minCost == 0 ? string.Empty : $"Минимальная стоимость поездки: {minCost}\n");
            Console.Write(maxCost == 0 ? string.Empty : $"Максимальная стоимость поездки: {maxCost}\n");

            // вывод рейсов
            Console.WriteLine("\n\n\nСписок подходящих рейсов:\n");
            Console.WriteLine(string.Join("\n", suitableFlights));

            Console.ReadKey();
        }

        private static List<Flight> ImportFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            List<Flight> flights = [];

            foreach (var line in lines)
            {
                var data = line.Split(',');

                // добавляем новый объект Flight в список
                flights.Add(new Flight
                (
                    number: int.Parse(data[0]),
                    destination: data[1],
                    departureTime: DateTime.Parse(data[2]),
                    arrivalTime: DateTime.Parse(data[3]),
                    cost: int.Parse(data[4]),
                    discount: int.Parse(data[5])
                ));
            }

            return flights;
        }
    }
}
