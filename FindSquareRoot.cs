using System.IO;
using System;

class Program
{
static void Main()
{
double n;
double result = 0;
Console.WriteLine("Enter a value: ");

if (!double.TryParse(Console.ReadLine(), out n)) {
Console.WriteLine("Invalid Input");
}
else{
if(n < 0){
throw new ApplicationException("Number can’t be negative.");
}
result = Math.Sqrt(n);
}

Console.WriteLine("the square root is "+result);
}
}
