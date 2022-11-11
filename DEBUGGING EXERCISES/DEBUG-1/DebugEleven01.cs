using System;
using static System.Console;

public class DebugEleven01 {
  public static void Main(
      string[] arr) // Main function should be declared in this format
  {
    double salary = 0; // needed to be initialized
    string salVal;
    bool isValidSalary = false; // needed to be initialized
    while (!isValidSalary) {
      try { // brackets of try were missing
        Console.Write(
            "Enter an employee's salary "); //"console to be written before
                                            //Write and ReadLine"
        salVal = Console.ReadLine();
        salary = Convert.ToDouble(salVal);
        isValidSalary = true;
      } catch (FormatException) // ending brackets of try were missing
      {
        Console.WriteLine("You must enter a number for the salary.");
      }
    }
    Console.WriteLine("The salary {0} is valid", salary.ToString("C2"));
  }
}
