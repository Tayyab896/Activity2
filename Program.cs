using System;

namespace HotelReservationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\tWelcome to Sydney Hotel");
            int i = 0;
            string[] name = new string[20];
            int[] night = new int[20];
            string[] roomservice = new string[20];
            double[] costlist = new double[20];
            int[] previousStays = new int[20]; // Tracks previous stays for loyalty discount

            // Loop to repeat steps for new reservations
            while (true)
            {
                // Taking customer name input
                Console.WriteLine("Enter Customer Name:");
                string Name = Console.ReadLine();
                name[i] = Name;

                // Taking input for number of nights and validating
                Console.WriteLine("Enter Number of Nights:");
                int NumberOfNights = 0;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out NumberOfNights) && NumberOfNights >= 1 && NumberOfNights <= 20)
                    {
                        night[i] = NumberOfNights;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number of nights between 1 and 20:");
                    }
                }

                // Room service input validation
                string roomService;
                while (true)
                {
                    Console.WriteLine("Enter yes/no to indicate whether you want room service:");
                    roomService = Console.ReadLine().ToLower();
                    if (roomService == "yes" || roomService == "no")
                    {
                        roomservice[i] = roomService;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                    }
                }

                // Calculating the base cost based on number of nights
                double cost = NumberOfNights * (NumberOfNights <= 3 ? 100 : (NumberOfNights <= 10 ? 80.5 : 75.3));

                // Checking loyalty discount for repeat stays
                int loyaltyDiscount = previousStays[i] * 5; // 5% discount for each previous stay
                if (loyaltyDiscount > 20) loyaltyDiscount = 20; // Max discount capped at 20%
                double discountAmount = cost * (loyaltyDiscount / 100.0);
                cost -= discountAmount;

                // Adding room service cost if applicable
                if (roomService == "yes")
                {
                    cost += cost * 0.10; // 10% additional cost for room service
                }

                // Storing and displaying total cost
                costlist[i] = cost;
                Console.WriteLine($"Total price for {Name} is ${cost:.2f}. Loyalty discount applied: {loyaltyDiscount}% (${discountAmount:.2f}).");

                // Incrementing reservation index
                i++;

                // Option to exit or continue
                Console.WriteLine("________________________________________");
                Console.WriteLine("Press 'q' to exit or any other key to continue:");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "q")
                {
                    break;
                }
            }

            // Displaying summary of all reservations
            Console.WriteLine("\t\t\tSummary of Reservations");
            Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,10}", "Name", "Number of Nights", "Room Service", "Charge ($)");
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,10:N2}", name[j], night[j], roomservice[j], costlist[j]);
            }
        }
    }
}

