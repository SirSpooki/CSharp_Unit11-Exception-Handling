using System;
using static System.Console;

class SubscriptExceptionTest
{
    static void Main()
    {
        double[] array = {20.3, 44.6, 32.5, 46.7, 89.6, 67.5, 12.3, 14.6, 22.1, 13.6};
        int index;
        double value;
        while (true)
        {
            try
            {
                Write("Enter an index: ");
                index = Convert.ToInt32(ReadLine());
                if (index == 99)
                {
                    break;
                }
                value = array[index];
                WriteLine("value at index " + index + " is " + value);
            }
            catch (IndexOutOfRangeException e)
            {
                WriteLine("Index was outside the bounds of the array.");
            }
        }
    }
}
