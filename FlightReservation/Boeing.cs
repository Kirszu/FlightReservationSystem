using System;
using System.Collections.Generic;
namespace FlightReservation
{
    public class Boeing : IPlane
    {
        public int Capacity => 200;
        public float FuelConsumption => 20;
        public List<string> SeatNames => new List<string>(new string[] { "A", "B", "C", "D" });
        public Dictionary<int, List<string>> TakenSeats = new Dictionary<int, List<string>>();
        
        public void PrintSeats()
        {
            DrawPlaneFront(8);
            DrawSeatRows(50, this.TakenSeats);
        }

        Dictionary<int, List<string>> IPlane.TakenSeats()
        {
            return this.TakenSeats;
        }

        public void AddTakenSeat(string seat)
        {
            int seatRow = int.Parse(seat.Substring(1, seat.Length - 1));
            string seatLetter = seat.Substring(0, 1).ToUpper();
            this.TakenSeats.Add(seatRow, new List<string>());
            this.TakenSeats[seatRow].Add(seatLetter);
        }


        private void DrawPlaneFront(int frontLength)
        {
            string spaces = "";
            int paddingNumber = frontLength * 2;
            string padding = AddPadding(paddingNumber);

            for (int i = 0; i < frontLength; i++)
            {
                Console.WriteLine(padding + "/" + spaces + @"\");
                spaces += "  ";
                paddingNumber -= 1;
                padding = AddPadding(paddingNumber);
            }
        }
        private string AddPadding(int numberOfSpaces)
        {
            string temp = "";
            for (int i = 0; i < numberOfSpaces; i++)
            {
                temp += " ";
            }
            return temp;
        }
        private void DrawSeatRows(int rows, Dictionary<int, List<string>> takenSeats)
        {
            string a;
            string b;
            string c;
            string d;
            for (int i = 1; i <= rows; i++)
            {
                a = "A";
                b = "B";
                c = "C";
                d = "D";
                if (takenSeats.ContainsKey(i))
                {
                    foreach (var seat in takenSeats[i])
                    {
                        switch (seat)
                        {
                            case "A":
                                a = "X";
                                break;
                            case "B":
                                b = "X";
                                break;
                            case "C":
                                c = "X";
                                break;
                            case "D":
                                d = "X";
                                break;
                        }
                    }
                }
                Console.WriteLine($"        | [{a}][{b}]  [{c}][{d}] | {i}");
            }
        }
    }
}