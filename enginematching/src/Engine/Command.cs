using System;
using System.Collections.Generic;

namespace Engine
{
    public class Command
    {

         // Return a List of string from command line
        public static List<string> OrderInput()
        {

            //Reading the standard input arguments and spilt them based on spaces
            Console.WriteLine(" Enter an Order");
            Console.WriteLine("OperationType OrderTrade Price Quantity Devise Ticker Country MM-DD-yyyy h:mm:tt orderId");

            //All the spilt argemtns are saved to an array named stdInputArgumentsArray

            //Console.Read();
            List<string> orderInput = new List<string>();

            string currentLine = " ";

            while ((currentLine = Console.ReadLine()) != null && currentLine != "")
            {
                orderInput.Add(currentLine);
            }
            return orderInput;
        }

    public Command()
        {
        }
    }
}
