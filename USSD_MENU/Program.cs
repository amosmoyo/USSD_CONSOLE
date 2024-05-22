using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace USSD_MENU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            menu();

            var choice = getUserChoice();

            var choiceIndex = (int)choice - 1;

            if(choiceIndex >= 0 && choiceIndex < Enum.GetValues(typeof(MenuChoices)).Length)
            {
                switch (choiceIndex) 
                {
                    case (int)MenuChoices.balance:
                        Console.WriteLine("Your balance is 200");
                        break;
                    case (int)MenuChoices.ministatement:
                        Console.WriteLine("Your Ministatement is 200");
                        break;
                    case (int)MenuChoices.fullstatement:
                        Console.WriteLine("Your fullstatement request has been sent to your phone");
                        break;
                    case (int)MenuChoices.exit:
                        Console.WriteLine("Are you sure you what to quit this operation? Y/N?");

                        var confirmation = Console.ReadLine().ToUpper()[0];

                        if(confirmation.ToString() == "Y")
                        {
                            Console.WriteLine("You are exiting this application");
                            return;
                        }

                        Console.Clear();

                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option, try again.");
            }

            Console.Write("Press any key to proceed...");
            Console.ReadKey();
            Console.Clear();

        }



        private static MenuChoices getUserChoice()
        {
            var input = Console.ReadLine();

            return Enum.TryParse<MenuChoices>(input, out MenuChoices choice) ? choice : MenuChoices.Unknown;
        }


        private static string getEnumDescription(Enum choice)
        {
            var field = choice.GetType().GetField(choice.ToString());

            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attribute == null ? choice.ToString() : attribute.Description;
        }

        private static void menu()
        {
            Console.WriteLine("Select the below option: \n");

            var options = 1;

            foreach (MenuChoices menuChoices in Enum.GetValues(typeof(MenuChoices)))
            {
                if (menuChoices != MenuChoices.Unknown)
                {
                    var description = getEnumDescription(menuChoices);

                    Console.WriteLine($"{options}. {description}");
                    options++;
                }

            }
            Console.Write("\n type your selection ");
        }
    }
}
