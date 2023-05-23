using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_Improve
{
    internal class DataBaseDB
    {



        //Attribute,Variable with "List<>"
        private List<RegisterProducts> productsList;



        //Method to add
        public void AddProducts(RegisterProducts Product) 
        {
            //From products to product
            productsList.Add(Product);
        }



        //Method to search
        public List<RegisterProducts> SearchProduct(string pCodeNumber) 
        {
            //Create List temporary
            List<RegisterProducts> productsListTemporary = productsList.Where( x => x.CodeNumber == pCodeNumber).ToList();

            //Condition
            if(productsListTemporary.Count > 0) 
            {
                return productsListTemporary;
            }
            else 
            {
                return null;
            }
        }



        //Method to remove,delete
        public List<RegisterProducts> DeleteProduct(string pCodeNumber) 
        {
            //Create List temporary
            List<RegisterProducts> productsListTemporary = productsList.Where( x => x.CodeNumber == pCodeNumber).ToList();

            //Condition
            if(productsListTemporary.Count > 0) 
            {
                //loop
                foreach(RegisterProducts product in productsListTemporary) 
                {
                    productsList.Remove(product);
                }
                return productsListTemporary;
            }
            else 
            {
                return null;
            }
        }



        //Constructor without parameters to DataBase DB
        public DataBaseDB() 
        {
            productsList = new List<RegisterProducts>();
        }
    }
}
