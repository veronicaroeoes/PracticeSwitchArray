using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6._1BankomatMeny
{
    class Program
    {
        static int saldo = 0;
        static bool loop = true;
        static int bankEventsSize = 10;

        static public string[] bankEvents = new string[bankEventsSize];


        static void Main(string[] args)
        {
            // Inmatningsmeny för bankomat 
            // Switchsats för inmatning
            // Vid saldo - visa 10 senaste händelserna

            while (loop)
            {
                Menu();
            }
        }

        private static void Menu()
        {
            Console.WriteLine("Välj vad du vill göra:");
            Console.WriteLine("[I]nsättning");
            Console.WriteLine("[U]ttag");
            Console.WriteLine("[S]aldo");
            Console.WriteLine("[A]vsluta");
            Console.WriteLine("========================");

            try
            {
                char input = Convert.ToChar(Console.ReadLine().ToUpper()); 
                
                switch (input)
                {

                    case 'I':
                        Deposit();
                        break;

                    case 'U':
                        Withdrawal();
                        break;

                    case 'S':
                        PrintBalance();
                        break;

                    case 'A':
                        loop = false;
                        break;

                    default:
                        PrintException();
                        break;
                }
            }
            catch
            {
                PrintException();
            }
        }

        private static void PrintException()
        {
            Console.Clear();
            Console.WriteLine("Ange bokstaven inom [] för att välja vad du vill göra.");
        }

        private static void PrintBalance()
        {
            Console.Clear();
            Console.WriteLine($"Ditt saldo är: {saldo}");

            // Visa 10 senaste händelserna
            Console.WriteLine("Dina senaste händelser:");

            for (int i = bankEventsSize - 1; i >= 0; i--)
            {
                string currentHistory = bankEvents[i];

                if (currentHistory != null && currentHistory != "")
                {
                    Console.WriteLine(currentHistory);
                }
            }

            Console.WriteLine("========================");
        }

        private static void Withdrawal()
        {
            Console.Clear();
            Console.Write("Ange hur mycket du vill ta ut: ");
            bool loop3 = true;

            while (loop3)
            {
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());

                    if (input > 0)
                    {
                        if (input <= saldo)
                        {
                            saldo -= input;

                            for (int i = 0; i < bankEventsSize - 1; i++)
                            {
                                bankEvents[i] = bankEvents[i + 1];
                            }

                            bankEvents[bankEvents.Length - 1] = $"{DateTime.Now}, Uttag: {input:c}";
                            loop3 = false; 
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ditt saldo är för lågt.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Den där går vi inte på!");
                    }
                }
                catch
                {
                    Console.WriteLine("Ange ett heltal över 0");
                }
            }
        }
        
        private static void Deposit()
        {
            Console.Clear();
            Console.Write("Ange hur mycket du vill sätta in: ");
            bool loop2 = true;

            while (loop2)
            {
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());

                    if (input > 0)
                    {
                        saldo = saldo + input;

                        for (int i = 0; i < bankEventsSize - 1; i++)
                        {
                            bankEvents[i] = bankEvents[i + 1];
                        }
                        bankEvents[bankEvents.Length - 1] = $"{DateTime.Now}, Insättning: {input:c}";
                        loop2 = false;
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Du kan bara sätta in positiva heltal.");
                    }
                }
                catch
                {
                    Console.WriteLine("Du måste ange ett heltal.");
                }
            }
        }
    }
}
