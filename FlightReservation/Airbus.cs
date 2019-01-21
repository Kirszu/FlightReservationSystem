using System;

namespace FlightReservation
{
    public class Airbus: IPlane
    {

        public Airbus()
        {
        }

        public int Capacity => 255;

        public float FuelConsumption => 32;

        public void PrintSeats()
        {
            DrawPlaneFront(6);
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
                Console.WriteLine("      | [A]    [B] | {0}", i);
            }
        }
    }
}