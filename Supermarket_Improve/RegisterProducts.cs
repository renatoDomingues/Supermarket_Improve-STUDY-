using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_Improve
{
    internal class RegisterProducts
    {



        //Attribute,Variable
        private string codeNumber;
        private string nameProduct;
        private DateTime enterDate;
        private UInt32 quantities;



        //Property to attribute above
        public string CodeNumber 
        { 
            get { return codeNumber; } set { codeNumber = value; } 
        }
        public string NameProduct
        {
            get { return nameProduct; } set { nameProduct = value; }
        }
        public DateTime EnterDate
        {
            get { return enterDate; } set { enterDate = value; }
        }
        public UInt32 Quantities
        {
            get { return quantities; } set { quantities = value; }
        }



        //Constructor with use "this." and parameters
        public RegisterProducts(string pCodeNumber, string pNameProduct, DateTime pEnterDate,UInt32 pQuantities) 
        {
            this.codeNumber = pCodeNumber; this.nameProduct = pNameProduct; this.enterDate = pEnterDate; this.quantities = pQuantities;
        }
    }
}
