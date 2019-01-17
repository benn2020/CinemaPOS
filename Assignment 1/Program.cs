using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {

        static void Main(string[] args)
        {
            //Setting variables
            int screenOneSeats = 15, screenTwoSeats = 33;                           //Setting the ammount of available seats for each screen
            int adultTicketsSold = 0, childTicketsSold = 0, studentTicketsSold = 0; //Setting the ammount of tickets sold, used to calculate price at the end
            double adultPrice = 2.35, childPrice = 1.5, studentPrice = 1.99;        //Set the  prices  for the different tickets
            int movieChoice;                                                        //Declare the variable that will hold the users movie choice
            string ticketType;                                                      //Holds the users choice of ticket type
                       
            Console.Clear();
            Console.WriteLine("*************************************");
            Console.WriteLine("      Sarre International Cinema     ");
            Console.WriteLine("*************************************");
            Console.WriteLine("When you visit Sarre, you’ve seen it!");
            Console.WriteLine();

            do
            {
                Welcome(screenOneSeats, screenTwoSeats); //Shows welcome message

                //Input stuff

                //Asks for their film choice
                Console.Write("What film would you like to see: (1) Jaws, or (2) The Exorcist: ");
                movieChoice = int.Parse(Console.ReadLine().ToLower()); //Used to hold user input

                //Goes to end of day even if all seats haven't sold
                if (movieChoice == 0000)
                {
                    Console.WriteLine();
                    Console.WriteLine("Going to end of day");
                    break;
                }
                else if(movieChoice == 9999)
                {
                    EndOfDay(adultTicketsSold, childTicketsSold, studentTicketsSold, adultPrice, childPrice, studentPrice, screenOneSeats, screenTwoSeats);
                    continue;
                }

                //Keeps asking for a valid input
                while (movieChoice != 1 && movieChoice != 2 && movieChoice != 0000 && movieChoice != 9999)
                {
                    Console.WriteLine("Please enter a valid choice");
                    Console.Write("What film would you like to see: (1) Jaws, or (2) The Exorcist: ");
                    movieChoice = int.Parse(Console.ReadLine().ToLower());
                }

                //Code to check that there are still seats left in the respective screen
                if (movieChoice == 1 && screenOneSeats <= 0)
                {
                    NoSeatsLeft();
                    continue;
                }
                else if (movieChoice == 2 && screenTwoSeats <= 0)
                {
                    NoSeatsLeft();
                    continue;
                }

                Console.Write("What kind of ticket do you need? (A)dult, (C)hild, (S)tudent: ");
                ticketType = Console.ReadLine().Substring(0, 1).ToLower(); //Used to hold user input

                //Keeps asking for valid ticket choice
                while (ticketType != "a" && ticketType != "c" && ticketType != "s")
                {
                    Console.WriteLine("Please enter a valid choice");
                    Console.Write("What kind of ticket do you need? (A)dult, (C)hild, (S)tudent: ");
                    ticketType = Console.ReadLine();
                }

                //Switch for movie choice
                switch (movieChoice)
                {
                    case 1:   //Tickets for Jaws
                        if (screenOneSeats > 0) //Checks that their are seats left
                        {
                            if (ticketType == "c") //Runs if it's a child ticket
                            {
                                Console.Write("You need an adult to see this film, or be over 12, What is your age?: ");    //If the child is over 12 they don't need an adult
                                int age = int.Parse(Console.ReadLine());                                                    //Takes in the buyers age
                                if (age <= 12)
                                {
                                    Console.Write("Do you have an adult with you? ");
                                    string withAdult = Console.ReadLine().Substring(0, 1).ToLower();    //Takes in whether or not the child has an adult
                                    if (withAdult != "y")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You can not have this ticket");
                                        Console.ResetColor();
                                        continue; // Skips loop if without an adult
                                    }
                                }
                            }
                            screenOneSeats--;
                        }
                        else //Shows no seats left 
                        {
                            NoSeatsLeft();
                            continue;
                        }
                        break;
                    case 2: //Tickets fror the exorcist
                        if (screenTwoSeats > 0)
                        {
                            if (ticketType == "c") //Runs if it is a child ticket
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You need to be an adult to watch this film"); //Tells users they need to be an adult
                                Console.ResetColor();
                                continue;                                                        //Skips this loop as children can't buy this ticket
                            }
                            screenTwoSeats--;
                        }
                        else //Shows no seats left
                        {
                            NoSeatsLeft();
                            continue;
                        }
                        break;
                }

                //Adds ticket quantities so it can be calculated
                switch (ticketType)
                {
                    case "a":
                        adultTicketsSold++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have bought this ticket!");
                        Console.ResetColor();
                        Console.WriteLine("Seats left in Screen " + movieChoice + ": " + SeatsLeft(movieChoice, screenOneSeats, screenTwoSeats));
                        break;
                    case "c":
                        childTicketsSold++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have bought this ticket!");
                        Console.ResetColor(); Console.WriteLine("Seats left in Screen " + movieChoice + ": " + SeatsLeft(movieChoice, screenOneSeats, screenTwoSeats));
                        break;
                    case "s":
                        studentTicketsSold++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have bought this ticket!");
                        Console.ResetColor(); Console.WriteLine("Seats left in Screen " + movieChoice + ": " + SeatsLeft(movieChoice, screenOneSeats, screenTwoSeats));
                        break;
                }

            } while (screenOneSeats != 0 || screenTwoSeats != 0);

            EndOfDay(adultTicketsSold, childTicketsSold, studentTicketsSold, adultPrice, childPrice, studentPrice, screenOneSeats, screenTwoSeats);

            Console.WriteLine("Press enter to Exit");
            Console.ReadLine();
        }

        //Tells how many seats left by taking in movie choice
        public static int SeatsLeft(int screenSelection, int screenOneSeats, int screenTwoSeats)
        {
            if(screenSelection == 1)
            {
                return screenOneSeats;
            }else if(screenSelection == 2)
            {
                return screenTwoSeats;
            }
            else
            {
                return 0;
            }
        }

        //Shows welcome message,a dn pricing fr different tickets
        public static void Welcome(int screenOneSeats, int screenTwoSeats)
        {
            //Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);


            //Use https://www.tablesgenerator.com/text_tables# for the table Generator
            //Shows what is showing, the screen, and the age rating
            Console.WriteLine((@"
+-------------------------------------------------+
|                     Showings                    |
+-------------------------------------------------+
|     Movie    | Screen | Age Rating | Seats left |
+--------------+--------+------------+------------+
|     Jaws     |    1   |     12A    |     "+screenOneSeats+@"     |
+--------------+--------+------------+------------+
| The Exorcist |    2   |     18     |     "+screenTwoSeats+@"     |
+--------------+--------+------------+------------+
"));

            //Shows prices of the different tickets
            Console.WriteLine(@"
+-------------------------------------------+
|                   Price                   |
+-------------------------------------------+
| Adult Price | Student Price | Child Price |
+-------------+---------------+-------------+
|    £2.35    |     £1.99     |    £1.50    |
+-------------+---------------+-------------+
");
            Console.WriteLine("Press 0000 for end of day calculations");
            Console.WriteLine("Press 9999 to check on sales");
            Console.WriteLine();
        }

        //Shows message that no seats are left
        public static void NoSeatsLeft()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**************************************");
            Console.WriteLine("There are no seats left in this screen");
            Console.WriteLine("**************************************");
            Console.ResetColor();
        }

        //Processing price, works as far as I can tell
        public static void EndOfDay(int adultsSold, int childrenSold, int studentSold, double adultPrice, double childPrice, double studentPrice, int screenOne, int screenTwo)
        {
            //Processing price, works as far as I can tell

            double totalTicketPrice = (adultsSold * adultPrice) + (childrenSold * childPrice) + (studentSold * studentPrice); //This is what the price should be
            double preVatPrice = Math.Round(totalTicketPrice / 1.2, 2); //Takings for cinema
            double vatAmountTotal = totalTicketPrice - preVatPrice; //Vat to pay
            //double endPrice = preVatPrice * 1.2;


            Console.WriteLine();
            Console.WriteLine("*******************");
            Console.WriteLine(" End of day Screen ");
            Console.WriteLine("*******************");
            Console.WriteLine();

            Console.WriteLine("Adult tickets sold:" + adultsSold);
            Console.WriteLine("Child Tickets Sold: " + childrenSold);
            Console.WriteLine("Student Ticket Sold " + studentSold);
            Console.WriteLine();
            Console.WriteLine("Showing in Screen 1: Jaws(12A)");
            Console.WriteLine("Number of seats left: " + screenOne);
            Console.WriteLine();
            Console.WriteLine("Showing in Screen 2: The Excorcist(18)");
            Console.WriteLine("Number of seats left: " + screenTwo);
            Console.WriteLine();

            Console.WriteLine("Takings for the day is :£" + totalTicketPrice.ToString("0.00"));
            Console.WriteLine("Cinema Money: £" + preVatPrice.ToString("0.00"));
            Console.WriteLine("VAT to pay £" + vatAmountTotal.ToString("0.00"));

        }
    }
}