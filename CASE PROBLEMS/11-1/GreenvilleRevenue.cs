using System;
using static System.Console;
using System.Globalization;

class GreenvilleRevenue {
    
  static void Main() {
      
    const int MIN_CONTESTANTS = 0;
    const int MAX_CONTESTANTS = 30;
    
    int num;
    int revenue = 0;
    
    Contestant[] contestants = new Contestant[MAX_CONTESTANTS];
    num = getContestantNumber(MIN_CONTESTANTS, MAX_CONTESTANTS);
    
    revenue = getContestantData(num, contestants, revenue);
    
    WriteLine("\n\nRevenue expected this year is {0}", revenue.ToString("C",CultureInfo.GetCultureInfo("en-US")));
      
    getLists(num, contestants);
    
  }
  
  private static int getContestantNumber(int min, int max) {
      
    string entryString;
    int num = max + 1;
    
    // implement the exception handling to validate the number of contestants
    while(num < min || num > max){
        
        try{
            
            Write("Enter number of contestants >> ");
            entryString = ReadLine();
            
            // if the invalid number is entered
            if (!int.TryParse(entryString, out num)){
                throw new Exception("Format invalid");
            }
            else if(num < min || num > max){
                
                // if the number is not within the range
                throw new Exception("Number must be between "+min+" and "+max+"");
            }
        }
        catch(Exception e){
            
            // catch the exception and show the message
            Console.WriteLine(e.Message);
            num = max+1;
        }
    }
    
    return num;
  }
  
  private static int getContestantData(int num, Contestant[] contestants, int revenue) {
      
    const int ADULTAGE = 17;
    const int TEENAGE = 12;
    int x = 0;
    
    string name;
    char talent = 'x';
    int age;
    
    while (x < num) {
        
      Write("Enter contestant name >> ");
      name = ReadLine();
      
      WriteLine("Talent codes are:");
      for (int y = 0; y < Contestant.talentCodes.Length; ++y)
        WriteLine(" {0} {1}", Contestant.talentCodes[y],Contestant.talentStrings[y]);
        
      bool valid = false;
      string entryString;
      
      // implement the exception handling to validate the talent code
      while(!valid){
          
          try{
              
              Write(" Enter talent code >> ");
              entryString = ReadLine();
              
              // if the invalid character entered
              if(!char.TryParse(entryString, out talent)){
                  throw new Exception(talent+" is not a valid talent code. Assigned as Invalid.");
              }
              
              // iterate over the talentCodes and check if the entered code is within the talentCodes
              for (int y = 0; y < Contestant.talentCodes.Length; ++y){
                  if(Contestant.talentCodes[y] == talent){
                      valid = true;
                      break;
                  }
              }
              
              // if the valid flag is false then throw an exception
              if(!valid){
                  throw new Exception(talent+" is not a valid talent code. Assigned as Invalid.");
              }
              
              
          }
          catch(Exception e){
              
              // catch the exception and show the message
              Console.WriteLine(e.Message);
              valid = false;
          }
          
      }
      
      
      
      Write(" Enter contestant's age >> ");
      int.TryParse(ReadLine(), out age);
      if (age > ADULTAGE)
        contestants[x] = new AdultContestant();
      else
      if (age > TEENAGE)
        contestants[x] = new TeenContestant();
      else
        contestants[x] = new ChildContestant();
        
      contestants[x].Name = name;
      contestants[x].TalentCode = talent;
      revenue += contestants[x].Fee;
      ++x;
    }
    
    return revenue;
  }
  
  private static void getLists(int num, Contestant[] contestants) {
      
    int x;
    char QUIT = 'Z';
    char option;
    bool isValid;
    int pos = 0;
    bool found;
    WriteLine("\nThe types of talent are:");
    
    for (x = 0; x < Contestant.talentStrings.Length; ++x)
      WriteLine("{0, -6}{1, -20}", Contestant.talentCodes[x],Contestant.talentStrings[x]);
    
    isValid = false;
    
    // implement the exception handling to validate the input talent code
    while (!isValid) {
        
      try{
          Write("\nEnter a talent type or {0} to quit >> ", QUIT);
          
          // if the invalid character entered
          if (!char.TryParse(ReadLine(), out option)) {
            isValid = false;
            throw new Exception("Invalid format - entry must be a single character");
          } 
          
          // if the entered input is 'Z'
          if(option == QUIT){
              isValid = true;
          }
          
          else{
             
             // iterate over the talentCodes and check if the entered code is within the talentCodes
             for (int z = 0; z < Contestant.talentCodes.Length; ++z) {
                if (option == Contestant.talentCodes[z]) {
                  isValid = true;
                  pos = z;
                }
              }
              
              // if the valid flag is false then throw an exception
              if (!isValid) {
                WriteLine("{0} is not a valid code", option);
              } 
              else {
                  
                WriteLine("\nContestants with talent {0} are:",
                  Contestant.talentStrings[pos]);
                found = false;
                
                for (x = 0; x < num; ++x) {
                  if (contestants[x].TalentCode == option) {
                    WriteLine(contestants[x].ToString());
                    found = true;
                  }
                }
                
                if (!found)
                  WriteLine("No contestants had talent {0}",Contestant.talentStrings[pos]);
                  
                isValid = false;
              }
              
          }

      }
      catch(Exception e){
          
          // catch the exception and show the message
          Console.WriteLine(e.Message);
          isValid = false;
      }

    }
  }
}

class Contestant {
    
  public static char[] talentCodes = {
    'S',
    'D',
    'M',
    'O'
  };
  
  public static string[] talentStrings = {
    "Singing",
    "Dancing",
    "Musical instrument",
    "Other"
  };
  
  public string Name {
    get;
    set;
  }
  
  private char talentCode;
  private string talent;
  
  public char TalentCode {
    get {
      return talentCode;
    }
    set {
      int pos = talentCodes.Length;
      for (int x = 0; x < talentCodes.Length; ++x)
        if (value == talentCodes[x])
          pos = x;
      if (pos == talentCodes.Length) {
        talentCode = 'I';
        talent = "Invalid";
      } else {
        talentCode = value;
        talent = talentStrings[pos];
      }
    }
  }
  
  public string Talent {
    get {
      return talent;
    }
  }
  
  public int Fee {
    get;
    set;
  }
  
}
class AdultContestant: Contestant {
    
  public int ADULT_FEE = 30;
  public AdultContestant() {
    Fee = ADULT_FEE;
  }
  
  public override string ToString() {
    return ("Adult Contestant " + Name + " " + TalentCode + " Fee " +
      Fee.ToString("C", CultureInfo.GetCultureInfo("en-US")));
  }
}

class TeenContestant: Contestant {
  public int TEEN_FEE = 20;
  
  public TeenContestant() {
    Fee = TEEN_FEE;
  }
  
  public override string ToString() {
    return ("Teen Contestant " + Name + " " + TalentCode + " Fee " +
      Fee.ToString("C", CultureInfo.GetCultureInfo("en-US")));
  }
}

class ChildContestant: Contestant {
  public int CHILD_FEE = 15;
  
  public ChildContestant() {
    Fee = CHILD_FEE;
  }
  
  public override string ToString() {
    return ("Child Contestant " + Name + " " + TalentCode + " Fee " +
      Fee.ToString("C", CultureInfo.GetCultureInfo("en-US")));
  }
}
