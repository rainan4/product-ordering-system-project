using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainaN_Assign1
{
    internal class Product
        // read-only properties
    {   
        public string ProductName
        {
            get;
          
        }

        public double PricePerUnit
        {
            get;
           
        }
        //read-write property
        public int Quantity
        {
            get;
            set;
        }
        //Computed read-only property
        public double ProductTotalBeforeTax
        {
            get
            {
                return PricePerUnit * Quantity;
            }
        }

        public double ProductTax
        {
            get
            {
                return (0.08 * ProductTotalBeforeTax); // converting 8% to 0.08 and multiplying it to product total before tax
            }

        }

        public double ProductTotalAfterTax
        {
            get
            {
                return ProductTotalBeforeTax + ProductTax;
            }
        }

        //overide string
        public override string ToString()
        {
            string asterikLinek1 = new string ('=', 40);
            //string outPut = String.Format(asterikLinek1+ "||{0, 20}: {1, -26}\n {3,20}: {4, -26}\n {5, 20}: {6, -26}\n {7, 20}: {8, -26}\n {9,20}: {10, -26}", ProductName , PricePerUnit.ToString("C") , 
            //                                    "Quantity", Quantity , "Product Total Before Tax", ProductTotalBeforeTax.ToString("C")
            //                                        ,"ProductTax", ProductTax.ToString("C") +  
            //                                        "Product Total After Tax", ProductTotalAfterTax.ToString("C"));

            string outPut = asterikLinek1 +"\n"+ "* Product Name: " + ProductName + "\n" +"* Price Per Unit: "+ PricePerUnit.ToString("C") + "\n" + 
                                                   "* Quantity: " + Quantity + "\n" + "* Product Total Before Tax: " + ProductTotalBeforeTax.ToString("C")
                                                       + "\n" + "* Product Tax: " + ProductTax.ToString("C") + "\n" +
                                                       "* Product Total After Tax: " + ProductTotalAfterTax.ToString("C") + "\n" + asterikLinek1;
            return outPut;
                //string.format()
        }

      
      
        // Constructor
        public Product(string product, double perUnitPrice) 
        {
           ProductName = product;
           PricePerUnit = perUnitPrice;
           
        }
       
    }
}
