using System;
namespace FlightReservation
{
    public class Boeing : IPlane
    {
        public int Capacity => 200;
        public float FuelConsumption => 20;
        public void PrintSeats()
        {
            DrawPlaneFront(8);
            DrawSeatRows(50);
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
        private void DrawSeatRows(int rows)
        {
            for (int i = 1; i <= rows; i++)
            {
                Console.WriteLine("        | [A][B]  [C][D] | {0}", i);
            }
        }
    }
}