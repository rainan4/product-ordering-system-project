using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RainaN_Assign1
{
    internal class Program
    { //Main Program
        static void Main(string[] args)
        {

            Product product1 = new Product("Granola Bar", 7.99);
            Product product2 = new Product("Cheesecake", 12.99);
            Product product3 = new Product("Tandoori Chicken", 19.99);

            WriteLine("Hi there, welcome to Costco!" + "\n" + "Your products are listed below along with the price per unit." + "\n");
            WriteLine(product1.ProductName + ": " + product1.PricePerUnit.ToString("C"));
            WriteLine(product2.ProductName + ": " + product2.PricePerUnit.ToString("C"));
            WriteLine(product3.ProductName + ": " + product3.PricePerUnit.ToString("C") +"\n"); //using ToString("C") to convert into currency for PricePerUnit

            //  WriteLine(productObject1);
            //  WriteLine(productObject2);
            // WriteLine(productObject3);

            // then call updateproductqty method three times
            UpdateProductQty(product1); // displays the amount of quantity to enter
            UpdateProductQty(product2);
            UpdateProductQty(product3);

            //call the chooseaction method 
            ChooseAction(product1, product2, product3);// displays the options to choose
            
        }

        // Method definitions
       static void UpdateProductQty (Product anyProduct) //takes one Product object as its parameters and updates quantity based on user input // nonvalue returning method
        {
            
            Write("Enter the quantity for " + anyProduct.ProductName + ", " + anyProduct.PricePerUnit.ToString("C") + ": ");
            anyProduct.Quantity = int.Parse(ReadLine());   // whatever the user inputs, it gets stored in anyProduct.Quantity
            
        }

        static void ChooseAction(Product product1, Product product2, Product product3) // takes 3 input product objects as parameters // non value returning method
        {
            /* displays three action options for the user using a numbered input: Press 1 for View Cart, 
                Press 2 for Update Order and Press 3 for quitting the application */

            WriteLine("\n"+"Please choose the options below");
            Write("Press 1 for View Cart, Press 2 for Update Order, Press 3 for quitting application: ");
            int option = int.Parse(ReadLine()); //using user input to choose three options by using the if and else conditions below
           

            if (option == 1) // if user presses 1 then it views the cart
            {
                ViewCart(product1, product2, product3); // this static method takes three product objects as agruments
            }
            else if (option == 2) // if user presses 2 then prompts to update the products
            {
                UpdateCart(product1, product2, product3); // takes three product objects as parameters
            }
            else  if (option == 3) // if user presses 3 then it clears the console 
            {
                Console.Clear(); //Clears the console
                WriteLine("Thank you for placing an order with us. Good Bye!"); //gets diplayed after console.clear

            }
        }

        static void ViewCart(Product product1, Product product2, Product product3) //takes three product objects as input parameters
        {
           
           double totalAfterDiscount = GetCartTotalSummary(product1, product2, product3, out double totalBeforeDiscount, out double discountAmount);
            // calling GetCartTotalSummary to get the total of all three objects before discount, discount amount and grand total after discount

            //Displays all the order details of the cart
            WriteLine("\n"+"The total of your order are displayed below: ");
      
            WriteLine(product1.ToString()); // calling ToString() to display my products,totals before and after tax instead of manually adding WriteLine();
            WriteLine(product2.ToString());
            WriteLine(product3.ToString());

            //display total before discoount, discountamount, and grand total afetr discount using output banner and formatted output
            string asterikLine = new string('*', 40);
            WriteLine(asterikLine);
            // formatted using currency format specifer
            WriteLine("*{0, 20}: {1, -16:C}*", "Total before discount", totalBeforeDiscount);
            WriteLine("*{0, 20}: {1, -16:C}*", "Discount amount", discountAmount);
            WriteLine("*{0, 20}: {1, -16:C}*", "Total after discount", totalAfterDiscount);
            WriteLine(asterikLine);

            // call chooseaction method at the end of viewcart method 
            ChooseAction(product1, product2, product3); // allows users to choose action they want to take



        }

       static double GetCartTotalSummary(Product product1, Product product2, Product product3,
                                            out double totalBeforeDiscount, out double discountAmount) //static method that returns total after discount // takes three product objects
       {
            double totalAfterDiscount; // returns as totalbeforediscount minus discountamount
            
            //compute totalBeforeDiscount and discountAmount
             totalBeforeDiscount = product1.ProductTotalAfterTax + product2.ProductTotalAfterTax + product3.ProductTotalAfterTax; //computed sum of three products objects and using it to get the value for totalBeforeDiscount
            
            // If the total amount before discount exceeds $100.00 then the customer gets 10 % off
            if (totalBeforeDiscount > 100.00) // if the total before discount is over $100 then it will apply 10% to the order after
            {
                
                discountAmount = (0.10 * totalBeforeDiscount); //logic used to compute 10% of total before discount
                //discountAmount is 10% of the totalBeforeDiscount
            }
            else
            {             
                discountAmount = 0;
              
            }
            //return totalAfterDiscount as return(totalBeforeDiscount - discountAmount)
            return totalAfterDiscount = (totalBeforeDiscount - discountAmount);  // assigns it totalafterdiscount

        }

        static void UpdateCart(Product product1, Product product2, Product product3) // static method // takes three product objects as input parameters
            /* i made this a void method because im not computing properties and returning the value. i used if and else if to allow users to update then called ChooseAction method
             to display the options again */
        {
            WriteLine("\n"+"**** You have choosen to update QUANTITY. ****");
            WriteLine("Press 1 to update quantity for Granola Bar");
            WriteLine("Press 2 to update quantity for Cheesecake");
            WriteLine("Press 3 to update quantity for Tandoori Chicken");
            Write("Enter the number (1, 2 or 3): "); 
            int option1 = int.Parse(ReadLine()); //user inputs // using int to allow users to enter in whole numbers only
            if (option1 == 1) // using if and else conditions and gathering user inputs to enter the new updated quantity of the three products
            {
                Write("Enter the new quantity for Granola Bar: ");
                int productOne = int.Parse(ReadLine()); //user inputs 
                WriteLine("Fantastic! Quantity for Granola Bar is now updated to: " + productOne);
                product1.Quantity = productOne; // storing the updated quantity of product 1
            }
            else if (option1 == 2)
            {
                Write("Enter the new quantity for Cheesecake: ");
                int productTwo = int.Parse(ReadLine());
                WriteLine("Fantastic! Quantity for Cheesecake is now updated to: " + productTwo);
                product2.Quantity = productTwo;//storing the updated quantity of product 2

            } 
            else if (option1 == 3)
            {
                Write("Enter the new quantity for Tandoori Chicken: ");
                int productThree = int.Parse(ReadLine());
                WriteLine("Fantastic! Quantity for Cheesecake is now updated to: " + productThree);
                product3.Quantity = productThree;// storing updated quantity of product 3
            }

            ChooseAction(product1, product2, product3); // allows user to choose actions again
        }
        

    }
}
