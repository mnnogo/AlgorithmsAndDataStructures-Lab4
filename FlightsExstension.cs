namespace Lab4
{
    internal static class FlightsExstension
    {
        public static List<Flight> FindFlightByParameters(this List<Flight> flights,
                                                          string destination,
                                                          DateTime minDepartureTime,
                                                          DateTime maxDepartureTime,
                                                          DateTime minArrivalTime,
                                                          DateTime maxArrivalTime,
                                                          int minCost,
                                                          int maxCost)
        {
            List<Flight> result = [];

            // DateTime.MinValue означает, что пользователь не ввел дату
            foreach (Flight flight in flights)
            {
                if (flight.Destination != destination && destination != string.Empty)
                    continue;

                if (flight.DepartureTime < minDepartureTime && minDepartureTime != DateTime.MinValue)
                    continue;

                if (flight.DepartureTime > maxDepartureTime && maxDepartureTime != DateTime.MinValue)
                    continue;

                if (flight.ArrivalTime < minArrivalTime && minArrivalTime != DateTime.MinValue)
                    continue;

                if (flight.ArrivalTime > maxArrivalTime && maxArrivalTime != DateTime.MinValue)
                    continue;

                if (flight.Cost < minCost && minCost != 0)
                    continue;

                if (flight.Cost > maxCost && maxCost != 0)
                    continue;

                // добавляем, если прошел все проверки
                result.Add(flight);
            }

            return result;
        }
    }
}
