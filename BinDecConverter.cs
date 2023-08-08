using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-------------------- Binary & Decimal --------------------//


            //-----Request for convertion method and value to convert, if input is invalid stop further operations-----//

            Console.WriteLine("Please choose which to convert; Binary or Decimal");

            string Method = Console.ReadLine().ToLower();
            int MethodInt = 0;

            //Add one or two to MethodInt based on conversion type, else cancel
            if (Method == "binary")
            {
                MethodInt = 1;
            }
            else if (Method == "decimal")
            {
                MethodInt = 2;
            }
            else
            {
                Console.WriteLine("Invalid, please try again");
                return;
            }

            Console.WriteLine("Please input your desired convertable value");

            string ConValue = Console.ReadLine();
            int ConValueInt;

            //Parse the inputted number to check for anything other than digits, if there is; cancel
            if (int.TryParse(ConValue, out ConValueInt) == false)
            {
                Console.WriteLine("Invalid, please try again");
                return;
            }

            //-----Call the correct function based on received inputs-----//

            if (MethodInt == 1)
            {
                BinToDec(ConValueInt);
            }

            if (MethodInt == 2)
            {
                DecToBin(ConValueInt);
            }
        }

        //----------Binary to Decimal conversion----------//
        static void BinToDec(int Input)
        {
            //-----Morph the Input into a more suitable form-----//

            string StringInput = Input.ToString();
            List<string> FInput = new List<string>();

            //Flip the Input, i.e. 1234 to 4321
            for (int i = 0; i < StringInput.Length; i++)
            {
                int TempValString = Input.ToString().Length - 1 - i;
                string TempVal = StringInput[TempValString].ToString();
                FInput.Add(TempVal);
            }

            //-----Convert the binary into decimal-----//

            int Multiplier = 1;
            int Output = 0;

            //For every loop increase the multiplier by the power of 2, add any numbers to the sum as dictated by the binary
            for (int i = 0; i < StringInput.Length; i++)
            {
                int TempVal = Multiplier * Int32.Parse(FInput[i]);
                Output += TempVal;
                Multiplier *= 2;
            }

            Console.WriteLine("The converted binary results to: " + Output);
        }

        //----------Decimal to Binary conversion----------//
        static void DecToBin(int Input)
        {
            //-----Create a list of power of 2 values for the input length-----//

            List<int> Powers = new List<int>();
            Powers.Add(1);
            int Multiplier = 1;

            while (true)
            {
                int TempVal = Multiplier * 2;
                Powers.Add(TempVal);
                if (TempVal > Input)
                {
                    break;
                }
                Multiplier *= 2;
            }

            //-----Run through the list of powers, if the value is larger than total, add 0, otherwise add 1-----//

            List<string> BinaryList = new List<string>();

            for (int i = 0; i < Powers.Count; i++)
            {
                if (Powers[Powers.Count - 1 - i] > Input)
                {
                    BinaryList.Add("0");
                }
                else
                {
                    BinaryList.Add("1");
                    Input -= Powers[Powers.Count - 1 - i];
                }
            }

            //-----Remove first zero of output list, as this is unnecessary, then join and print-----//

            BinaryList.RemoveAt(0);

            string Output = string.Join("", BinaryList);
            Console.WriteLine("The converted decimal results to: " + Output);
        }
    }
}
