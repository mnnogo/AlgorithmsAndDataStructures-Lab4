namespace Lab4
{
    internal readonly struct Flight(int number, string destination, DateTime departureTime, DateTime arrivalTime, int cost, int discount)
    {
        public int Number { get; } = number;
        public string Destination { get; } = destination;
        public DateTime DepartureTime { get; } = departureTime;
        public DateTime ArrivalTime { get; } = arrivalTime;
        public int Cost { get; } = cost;
        public int Discount { get; } = discount;

        public override string ToString()
        {
            return $"Номер рейса: {Number}\n" +
                $"Место назначения: {Destination}\n" +
                $"Время отправления: {DepartureTime}\n" +
                $"Время прилета: {ArrivalTime}\n" +
                $"Стоимость: {Cost}\n" +
                $"Размер скидки рейса: {Discount}\n";

        }
    }
}
