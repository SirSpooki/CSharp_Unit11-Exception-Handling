using System;

class FDebugEleven03 {
  static void Main()
  {
    Employee emp = new Employee();
    try {
      emp.IdNum = 234;
      emp.Salary = -12;
    } catch (NegativeSalaryException e) {
      Console.WriteLine(e.Message);
      Console.WriteLine(e.StackTrace);
    }
  }
}
public class NegativeSalaryException : Exception {
  private static string msg = "Employee salary is negative.";
  public NegativeSalaryException()
      : base(msg)
  {
  }
}
public class Employee {
  private int idNum;
  private double salary;
  public int IdNum
  {
    get { return idNum; }

    set { idNum = value; }
  }
  public double Salary
  {
    get { return salary; }
    set
    {
      if (value < 0) {
        NegativeSalaryException salExcep = new NegativeSalaryException();
        throw(salExcep);
      }
      salary = value;
    }
  }
}
