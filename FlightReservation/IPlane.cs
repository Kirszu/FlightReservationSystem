using System;
using System.Collections.Generic;
using System.Text;

namespace FlightReservation
{
    public interface IPlane
    {
        int Capacity { get; }
        float FuelConsumption { get; }
        List<string> SeatNames { get; }
        void PrintSeats();
        Dictionary<int, List<string>> TakenSeats();
        void AddTakenSeat(string seat);
    }
}
