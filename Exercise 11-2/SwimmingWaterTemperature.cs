using System;
class SwimmingWaterTemperature {
  // variable to store temperature entered by user
  static double degreesF;
  // function to check and return whether temperature is suitable for swimming or not
  static bool checkTemperature() {
    // when temperature is between 32 - 212 i.e. valid temperature
    if(degreesF>=32 && degreesF<=212) {
      // when temperature is between 70 - 85 i.e. suitable for swimming
      if(degreesF>=70 && degreesF<=85)
        return true;
      // when temperature is not between 70 - 85 i.e. not suitable for swimming
      else
        return false;
    }
    // when temperature is not between 32 - 212 i.e. invalid temperature
    else
      throw new ArgumentException("Value does not fall within the expected range.");
  }
  static public void Main(string[] args) {
  bool result;
  // loop will run until user enter 999
  while(true) {
    // For any invalid value of temperature, checkTemperature() will throw an exception. try-catch will handle that exception
    try{
      Console.Write("Enter another temperature or 999 to quit");
      degreesF=Convert.ToDouble(Console.ReadLine());
      // when user entered value is not 999
      if(degreesF!=999) {
        result=checkTemperature();
        if(result==true)
          Console.WriteLine("{0} degrees is comfortable for swimming.",degreesF);
        else
          Console.WriteLine("{0} degrees is not comfortable for swimming.",degreesF);
      }
      // when user entered value is 999
      else
        break;
      }
      catch(ArgumentException e){
        Console.WriteLine(e.Message);
      }
    }
  }
}
