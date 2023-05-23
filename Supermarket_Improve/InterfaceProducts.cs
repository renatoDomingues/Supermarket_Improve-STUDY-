using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_Improve
{
    internal class InterfaceProducts
    {



        //Enum with return
        public enum Result_And 
        {
            Sucess = 0,
            Exit = 1,
            Exception = 2
        }



        //Method withoud static
        public void ShowMessage(string message) 
        {
            Console.WriteLine(message);//This after remover to test
            Console.WriteLine("You can press any to continue ...");
            Console.ReadKey();
            Console.Clear();
        }



        //Method with modifier ref and parameters
        public Result_And CodeNumberTake(ref string pCodeNumber, string message)//=>Need chage name method 
        {
            //To return with Result_And and message
            Result_And back;
            Console.WriteLine(message);

            //Variable temporary to you will go writing
            string productTemporary = Console.ReadLine().ToUpper();

            //Condition
            if(productTemporary == "E") 
            {
                //To exit
                back = Result_And.Exit;
            }
            else 
            {
                pCodeNumber = productTemporary;
                back = Result_And.Sucess;
            }

            //Finishing this stage
            Console.Clear();
            return back;
        }



        //Method with modifier ref and parameters
        public Result_And NameProductTake(ref string pNameProduct, string message)//=>Need chage name method 
        {
            //To return with Result_And and message
            Result_And back;
            Console.WriteLine(message);

            //Variable temporary to you will go writing
            string productTemporary = Console.ReadLine().ToUpper();

            //Condition
            if (productTemporary == "E")
            {
                //To exit
                back = Result_And.Exit;
            }
            else
            {
                pNameProduct = productTemporary;
                back = Result_And.Sucess;
            }

            //Finishing this stage
            Console.Clear();
            return back;
        }



        //Method with modifier ref
        public Result_And EnterDateTake(ref DateTime pEnterDate, string message) 
        {
            //To return with Result_And and message
            Result_And back;

            //Loop
            do
            {
                //Exception treatment
                try
                {
                    Console.WriteLine(message);

                    //Variable temporary to you will go writing
                    string productTemporary = Console.ReadLine().ToUpper();

                    //Condition
                    if (productTemporary == "E")
                    {
                        back = Result_And.Exit;
                    }
                    else
                    {
                        pEnterDate = Convert.ToDateTime(productTemporary);
                        back = Result_And.Sucess;
                    }
                }
                catch (Exception and)
                {
                    ShowMessage("EXCEPTION: " + and.Message);
                    back = Result_And.Exception;
                }
            }while(back == Result_And.Exception);

            //Finishing this stage
            Console.Clear();
            return back;
        }



        //Method with modifier ref
        public Result_And QuantitiesTake(ref UInt32 pQuantities, string message) 
        {
            //To return with Result_And and message
            Result_And back;

            //Loop
            do
            {
                //Exception treatment
                try 
                {
                    Console.WriteLine(message);

                    //Variable temporary to you will go writing
                    string productTemporary = Console.ReadLine().ToUpper();

                    //Loop
                    if(productTemporary == "E") 
                    {
                        back = Result_And.Exit;
                    }
                    else 
                    {
                        pQuantities = Convert.ToUInt32(productTemporary);
                        back = Result_And.Sucess;
                    }
                }
                catch(Exception and) 
                {
                    ShowMessage("EXCEPTION: " + and.Message);
                    back = Result_And.Exception;
                }
            }while(back == Result_And.Exception);

            //Finishing this stage
            Console.Clear();
            return back;
        }



        //Attribute that points to class "DataBaseDB"
        DataBaseDB dataBaseDB;



        //Constructor with parameter DataBaseDB to connection attribute above
        public InterfaceProducts(DataBaseDB pDataBaseDB) 
        {
            dataBaseDB = pDataBaseDB;
        }



        //Method to print screen with parameter
        public void PrintScreenRegisterProducts(RegisterProducts pProduct) 
        {
            Console.WriteLine("Create a code your product: " + pProduct.CodeNumber);
            Console.WriteLine("What is your name product: " + pProduct.NameProduct);
            Console.WriteLine("How old is your product: " + pProduct.EnterDate);
            Console.WriteLine("What is quantities to put stock: " + pProduct.Quantities);
            Console.WriteLine("\r\a");
        }



        //Method list product
        public void PrintDataBaseDBscreen(List<RegisterProducts> pListProduct) 
        {
            //Loop
            foreach(RegisterProducts product in pListProduct) 
            {
                PrintScreenRegisterProducts(product);//=>It is errors
            }
        }



        //Method to register all products
        public Result_And RegisterProducts() 
        {
            Console.Clear();

            //Variable impty
            string CodeNumber = "";
            string NameProduct = "";
            DateTime EnterDate = new DateTime().Date;
            UInt32 Quantities = 0;

            //Condition
            if(CodeNumberTake(ref CodeNumber, "Do you can type a code your product with four numbers OR type 'E' to go out: ") == Result_And.Exit) 
            {
                return Result_And.Exit;
            }
            if(NameProductTake(ref NameProduct, "What is your name product OR type 'E' to go out: ") == Result_And.Exit)
            {
                return Result_And.Exit;
            }
            if(EnterDateTake(ref EnterDate, "How old is your product with format (dd/MM/yyyy) OR type 'E' to go out: ") == Result_And.Exit)
            {
                return Result_And.Exit;
            }
            if(QuantitiesTake(ref Quantities, "What is quantities to put our stock OR type 'E' to go out: ") == Result_And.Exit)
            {
                return Result_And.Exit;
            }

            //Object,Instance
            RegisterProducts registerProduct = new RegisterProducts(CodeNumber, NameProduct, EnterDate, Quantities);

            //Add
            dataBaseDB.AddProducts(registerProduct);

            //Finishing this stage
            Console.Clear();
            Console.WriteLine("Your registration of the code, name, date and quantity product has been successfully!! ");
            Console.WriteLine(" Thank you ");
            PrintScreenRegisterProducts(registerProduct);//=>This errors
            ShowMessage("");

            return Result_And.Sucess;

        }



        //Method to fetch
        public void FetchProduct() 
        {
            //To clear all above
            Console.Clear();

            Console.WriteLine("What is your code name product to fetch OR type 'E' to go out: ");

            //Variable temporary
            string productTemporary = Console.ReadLine().ToUpper();

            //Condition
            if(productTemporary == "E") 
            {
                return;
            }

            List<RegisterProducts> ListProductsTemporary = dataBaseDB.SearchProduct(productTemporary);

            //Condition
            if(ListProductsTemporary != null) 
            {
                Console.WriteLine("This code nume product " + productTemporary + " found! ");
                PrintDataBaseDBscreen(ListProductsTemporary);
            }
            else 
            {
                Console.WriteLine("No code name product " + productTemporary + " was found! ");
                ShowMessage("");
            }
        }



        //method to delete,remove
        public void DeleteProduct() 
        {
            //To clear all above
            Console.Clear();

            Console.WriteLine("What is your code name product to delete OR type 'E' to go out: ");

            //Variable temporary
            string productTemporary = Console.ReadLine().ToUpper();

            //Condition
            if(productTemporary == "E") 
            {
                return;
            }

            List<RegisterProducts> ListProductTemporary = dataBaseDB.DeleteProduct(productTemporary);

            //Condition
            if(ListProductTemporary != null) 
            {
                Console.WriteLine("The code name product " + productTemporary + " removed! ");
                PrintDataBaseDBscreen(ListProductTemporary);
            }
            else 
            {
                Console.WriteLine("No code name product " + productTemporary + " was found! ");
                ShowMessage("");
            }
        }



        //Method to do out
        public void ToGoOut() 
        {
            //To clear all above
            Console.Clear();
            ShowMessage("Finishing this program ...");
        }



        //Method unknown option
        public void UnknownOption() 
        {
            //To clear all above
            Console.Clear();
            ShowMessage("Unknown option! ");
        }



        //Method start interface
        public void StartInterface() 
        {
            //Variable temporary
            string productTemporary;

            //Loop
            do
            {
                Console.WriteLine("You can type 'R' to register code name product: ");
                Console.WriteLine("You can type 'S' to search your product: ");
                Console.WriteLine("You can type 'D' to delete your product: ");
                Console.WriteLine("You can type 'E' to go out: ");
                productTemporary = Console.ReadLine().ToUpper();

                //Switch
                switch(productTemporary) 
                {
                    case "R":

                        /* Call a Method */
                        //Register code name product
                        RegisterProducts();
                        break;

                    case "S":

                        /* Call a Method */
                        //Search code name product
                        FetchProduct();
                        break;

                    case "D":

                        /* Call a Method */
                        //Delete, remove product
                        DeleteProduct();
                        break;

                    case "E":

                        /* Call a Method */
                        //To go out this program 
                        ToGoOut();
                        break;

                    default:

                        /* Call a Method */
                        //Unknown option
                        UnknownOption();
                        break;
                }

            }while(productTemporary != "E");
        }
    }
}
