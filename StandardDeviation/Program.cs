
/*******************************************************************************
*  APPLICATION :    StandardDeviation
*  PURPOSE     :    Calculate the Standard Deviation
 * AUTHOR      :    Kedar Kanel
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardDeviation
{
    class Program
    {
        public  class StringClass
        {
            public StringClass() { }
            public String stringName;
            StringClass(String s)
            {
                stringName = s;
            }
            public void setString(String name)
            {
                stringName = name;
            }
            public String getString()
            {
                return stringName;
            }
        };
        public static double averageOfValue( StringClass s ) 
    { 
        double average = 0.0 ; // program will return this value 
          
        int[] commaArray ;  
        int sum = 0 ; 
        int totalNumbers ; 
        String name = s.getString() ; 
       // To know how many commas are there in the string 
          
        for ( int i = 0 ; i < ( name.Length ) ; i++ ) 
        { 
            if( name.ElementAt(i) == ',' ) 
            { 
                sum++ ; 
            } 
        }
              
        totalNumbers = sum + 1 ; // if there are n commas, there are n+1 numbers 
        commaArray = new int[sum] ; 
        int count = 0 ; 
          
        // To allocate index of comma to array called commaArray 
        for ( int j = 0 ; j < name.Length ; j++ ) 
        {
            if (name.ElementAt(j) == ',') 
            { 
                commaArray[count] = j ; 
                count++ ; 
            } 
  
        }
        // finding numbers between commas and adding them excluding number after final comma. 
        int c = 0;
        for (int z = 0; z <= sum; z++)
        {
            double x = Convert.ToDouble(name.Substring(c, commaArray[z]));
            Console.Write(x); 
            average = average + x;
            c = commaArray[z] + 1;
        }
        // converting string value into double after final comma and take a mean of that  

        double lastNumber;
        lastNumber = Convert.ToDouble(name.Substring(commaArray[sum - 1] + 1));
        average = average + lastNumber;
        average = average / totalNumbers;

        return average;

    }

        public static double standardDeviation(StringClass s)
        {
            double deviationValue;
            double mean = averageOfValue(s);

            String name = s.getString();
            name = name.Replace("\\s", ""); // replaces all blanks with nothing 

            String[] nameArray = name.Split(','); // creates array of string which are separated by comma 

            double numerator = 0.0;
            double denomerator = 1.0 * (nameArray.Length - 1);

            for (int i = 0; i < nameArray.Length; i++)
            {
                numerator += Math.Pow(Convert.ToDouble(nameArray[i]) - mean, 2);
            }

            deviationValue = numerator / denomerator;
            deviationValue = Math.Sqrt(deviationValue);

            return deviationValue;
        } 
    
        static void Main(string[] args)
        {
            StringClass aStringObject = new StringClass() ; 
            aStringObject.setString("3,44,4,33,43,5,6,3,4,5"); 
            Console.Write("Average is :" + averageOfValue(aStringObject));
            Console.Write("Standard deviation is : " + standardDeviation (aStringObject));
       
        }
    }
}
