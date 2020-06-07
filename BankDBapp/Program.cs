using System;

using System.Collections.Generic;

using System.Data.Entity;

using System.Linq;

using System.Runtime.Remoting.Contexts;

using System.Security.Cryptography.X509Certificates;

using System.Text;

using System.Threading.Tasks;



namespace BankDBapp

{

    /*

            class Asiakas
            {
                public string etunimi;
                public string sukunimi;


                public string Name()
                {

                    return etunimi + " " + sukunimi;

                }



                public string WholeName
                {

                    get { return etunimi + " " + sukunimi; }

                }



                public void GetPersonInfo(out string etu, out string suku)
                {
                    etu = this.etunimi;
                    suku = this.sukunimi;
                }


                public void mymethod()
                {
                    string vastaus = this.Name();
                    string vastaustoo = this.WholeName;
                    string etuA, sukuA;
                    this.GetPersonInfo(out etuA, out sukuA);
                }





                public string name { get; set; } = "unknown";
                public int customerNumber { get; }
                public List<int> accountList = new List<int>();



                Asiakas() { }

                public Asiakas(string nimi)
                {
                    name = nimi;
                    customerNumber = BankDefaults.createCustomerNumber();
                }


                public void ResetCustomer()
                {
                    name = "unknown";
                    accountList.Clear();
                }

            }



            class PankkiTili
            {
                public int accountNumber = default;
                public int customerNumber = default;
                protected double saldo = default;

                public double currentsaldo
                {
                    get { return saldo; }
                }


                public PankkiTili()
                {
                    accountNumber = BankDefaults.createAccountNumber();
                }

                public PankkiTili(double initialSaldo)
                {
                    accountNumber = BankDefaults.createAccountNumber();
                    saldo = initialSaldo;

                }



                public virtual void ShowAccountInfo()
                {

                    Console.WriteLine(accountNumber + " " +
                        customerNumber + " " +
                        "Saldo is " + saldo + " "

                        );

                }



                public virtual void ChangeSaldo(double nosto)
                {

                    if ((saldo + nosto) < 0)
                    {

                        Console.WriteLine("Bank Account cannot be negative");
                        return;
                    }

                    saldo += nosto;
                    Console.WriteLine($"new saldo is {saldo}");
                }


            }



            class LuottoTili : PankkiTili

            {

                double creditLimit = default;



                LuottoTili() { }

                public LuottoTili(double saldo, double creditLimit)
                {
                    this.saldo = saldo;
                    this.creditLimit = creditLimit;

                }

                public override void ShowAccountInfo()
                {
                    Console.WriteLine(accountNumber + " " +

                        customerNumber + " " +
                        "Saldo is " + saldo + " " +
                        "Credit Limit is " + creditLimit
                        );
                }



                public override void ChangeSaldo(double nosto)
                {

                    if ((saldo + nosto) < -creditLimit)
                    {

                        Console.WriteLine("You cannot go over creditlimit!");
                        return;
                    }

                    saldo += nosto;
                    Console.WriteLine($"new saldo is {saldo}");

                }



            }



            class YhteisöTili : PankkiTili

            {
                public List<int> customerList = new List<int>();
                public YhteisöTili(double newsaldo, List<int> newcustomers)

                {

                    saldo = newsaldo;

                    if (newcustomers.Count > 0)
                    {
                        customerNumber = newcustomers[0];
                        foreach (int iter in newcustomers)

                        {

                            customerList.Add(iter);

                        }

                    }

                }

                public override void ShowAccountInfo()

                {

                    Console.Write(accountNumber + " " +
                        customerNumber + " " +
                        "Saldo is " + saldo + " " +
                        "Customers are ");

                    foreach (int iter in customerList)
                    {

                        Console.Write(iter + "  ");

                    }

                    Console.WriteLine("");

                }

                public void ResetAccount()
                {

                    // remove all customers from account

                    customerNumber = default;
                    customerList.Clear();

                }

            }



            public static class BankDefaults

            {
                public const int maxCredit = 500;

                static int customerNumber = 0;
                static int accountNumber = 0;
                public static int createCustomerNumber()

                {

                    return ++customerNumber;

                }

                public static int createAccountNumber()

                {

                    return ++accountNumber;

                }
            }
    */

    public static class BankDefs
    {
        public const int BankAccount = 1;
        public const int CreditAccount = 2;
    }




    class Program

    {

        public static PankkiEntities context;



        //          static List<Asiakas> customerList;

        //          static List<PankkiTili> accountList;



        static void Main(string[] args)

        {

            context = new PankkiEntities();



            //              customerList = new List<Asiakas>();

            //              accountList = new List<PankkiTili>();



            // App title



            Console.WriteLine("BANK");

            Console.WriteLine("====");

            bool leaveBank = default;

            do

            {

                switch (GUIMainDisplay())

                {

                    case 0:

                        leaveBank = true;

                        Console.WriteLine("Leaving Bank...");

                        break;

                    case 1:

                        GUICreateCustomer();

                        break;

                    case 2:

                        GUICreateBankAccount();

                        break;

                    case 3:

                        GUICreateCreditAccount();

                        break;

                    case 4:

                        GUIJoinCustomerAccount();

                        break;

                    case 5:

                        GUITransferAccount();

                        break;

                    case 6:

                        GUIShowCustomer();

                        break;

                    case 7:

                        GUIShowAccount();

                        break;

                    case 8:

                        GUIDeleteCustomer();

                        break;

                    case 9:

                        GUIDeleteAccount();

                        break;

                    case 10:

                        GUIChangeSaldo();

                        break;



                    default:

                        break;

                }



            } while (!leaveBank);





            // end program

            Console.ReadLine();

        }



        private static int GUIMainDisplay()

        {

            bool validResponse = false;

            int response;

            do

            {

                Console.WriteLine(@"

                           Select Activity (0 to 10)

                           0) Lopetus

                           1) Uusi Asiakas

                           2) Uusi Pankkitili

                           3) Uusi Luottotili

                           4) Liitä tili asiakkaalle

                           5) Liitä tili uudelle asiakkaalle

                           6) Näytä asiakkaat

                           7) Näytä tilit

                           8) Poista asiakas

                           9) Poista tili

                           10) Tee tilitapahtumia (nosto ja talletus)


                        ");

                string guessInput = Console.ReadLine();



                // convert string to number

                validResponse = int.TryParse(guessInput, out response);

            } while (!validResponse);

            return response;

        }



        private static void GUICreateCustomer()
        {
            Console.WriteLine(@"

                           Customer First Name?

            ");

            string firstInput = Console.ReadLine();

            Console.WriteLine(@"

                           Customer Family Name?

            ");

            string familyInput = Console.ReadLine();


            if (confirmInput())
            {
                var newCustomer = new customers()
                {
                    customer_first_name = firstInput,
                    customer_last_name = familyInput,
                };

                context.customers.Add(newCustomer);
                context.SaveChanges();
            }
        }



        private static void GUICreateBankAccount()
        {

            bool validResponse = false;
            int customerNumber = default;
            int accountType = 1;
            decimal creditLimit = default;
            decimal currentSaldo = default;

            GUIShowCustomer();

            do
            {

                Console.WriteLine(@"

                        Who gets new account (customer number)?

                ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = int.TryParse(guessInput, out customerNumber);

            } while (!validResponse);

            /*           do
                       {

                           Console.WriteLine(@"

                                   What is account type (1 = bank, 2 = credit)?

                           ");

                           string guessInput = Console.ReadLine();

                           // convert string to number

                           validResponse = int.TryParse(guessInput, out accountType);

                       } while (!validResponse);



                       if (accountType.Equals(2))
                       {
                           do
                           {
                               Console.WriteLine(@"

                                   Credit Limit?

                           ");

                               string guessInput = Console.ReadLine();

                               // convert string to number
                               validResponse = decimal.TryParse(guessInput, out creditLimit);

                           } while (!validResponse);

                       }
             */


            do
            {
                Console.WriteLine(@"

                        Current saldo?

                ");

                string guessInput = Console.ReadLine();



                // convert string to number
                validResponse = decimal.TryParse(guessInput, out currentSaldo);

            } while (!validResponse);





            if (confirmInput())
            {
                var henkilö = context.customers.FirstOrDefault<customers>
                    (x => x.customer_number.Equals(customerNumber));



                var newAccount = new accounts()
                {

                    account_name = henkilö.customer_last_name,
                    account_type = accountType,
                    account_saldo = currentSaldo,
                    credit_limit = creditLimit,
                    customer_number = customerNumber
                };

                context.accounts.Add(newAccount);
                context.SaveChanges();
            }
        }



        private static void GUICreateCreditAccount()
        {

            bool validResponse = false;
            //double response = default;
            //double response2 = default;
            int accountType = 2;
            int customerNumber = default;
            decimal creditLimit = default;
            decimal currentSaldo = default;

            GUIShowCustomer();

            do
            {

                Console.WriteLine(@"

                        Who gets new credit account (customer number)?

                ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = int.TryParse(guessInput, out customerNumber);

            } while (!validResponse);



            do
            {
                Console.WriteLine(@"

                        Credit Limit?

                ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = decimal.TryParse(guessInput, out creditLimit);

            } while (!validResponse);



            do
            {
                Console.WriteLine(@"

                           Initial saldo?
            ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = decimal.TryParse(guessInput, out currentSaldo);

            } while (!validResponse);



            /*            do
                        {
                            Console.WriteLine(@"

                                       Initial creditlimit (0 to inifinity)?
                        ");

                            string guessInput = Console.ReadLine();

                            // convert string to number
                            validResponse = double.TryParse(guessInput, out response2);

                        } while (!validResponse);
            */


            if (confirmInput())
            {
                var henkilö = context.customers.FirstOrDefault<customers>
                    (x => x.customer_number.Equals(customerNumber));



                var newAccount = new accounts()
                {

                    account_name = henkilö.customer_last_name,
                    account_type = accountType,
                    account_saldo = currentSaldo,
                    credit_limit = creditLimit,
                    customer_number = customerNumber
                };

                context.accounts.Add(newAccount);
                context.SaveChanges();

            }


            /*
                            if (confirmInput())
                            {
                                LuottoTili newAccount = new LuottoTili(saldo: response, creditLimit: response2);
                               accountList.Add(newAccount);
                          }
            */


        }



        private static void GUIJoinCustomerAccount()
        {
            bool validResponse = false;
            int response = default;
            int response2 = default;

            GUIShowAccount();
            GUIShowCustomer();

            do
            {
                Console.WriteLine(@"

                           Select account number?

            ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = int.TryParse(guessInput, out response);

            } while (!validResponse);

            do
            {
                Console.WriteLine(@"

                           Select customer number?

            ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = int.TryParse(guessInput, out response2);

            } while (!validResponse);

        }




        private static void GUIShowCustomer()
        {
            Console.WriteLine(@"
                           Customer List:
            ");
            var list =
                from customer in context.customers
                select new
                {
                    Customer = customer.customer_number +
                    " " + customer.customer_first_name +
                    " " + customer.customer_last_name,
                    Account = customer.customer_number
                };



            foreach (var iter in list)
            {
                Console.Write("  " + iter.Customer);
                Console.Write(" Tilisi ovat: ");

                foreach (accounts iter2 in context.accounts)
                {
                    if (iter2.customer_number.Equals(iter.Account))
                    {
                        Console.Write(iter2.account_number + " ");
                    }
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Press Key to continue");
            Console.ReadLine();
        }




        private static void GUIShowAccount()
        {
            Console.WriteLine(@"

                           Account List:

            ");


            foreach (accounts iter in context.accounts)
            {
                Console.WriteLine("Tilin nro: " + iter.account_number + ", Tilin nimi: " + iter.account_name + ", Tilin saldo: " + iter.account_saldo);
                //Console.WriteLine(iter.account_name + " ");
                //Console.WriteLine(iter.account_saldo + " ");
            }
            /*
                            foreach (PankkiTili iter in accountList)
                            {
                                iter.ShowAccountInfo();
                            }
            */

            Console.WriteLine("Press Key to continue");
            Console.ReadLine();
        }



        private static void GUIDeleteCustomer()
        {
            GUIShowCustomer();
            bool validResponse = false;
            int response;

            do
            {
                Console.WriteLine(@"

                           Select Customernumber to be deleted

                        ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = int.TryParse(guessInput, out response);

            } while (!validResponse);


            if (confirmInput())
            {
                var dummy = context.customers.FirstOrDefault<customers>
                    (x => x.customer_number.Equals(response));

                var dummy2 = context.accounts.FirstOrDefault<accounts>
                    (x => x.customer_number.Equals(response));

                if (dummy2 is null)
                {
                    context.customers.Remove(dummy);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Cannot remove customer with an account");
                }


            }
            Console.ReadLine();
            /*                       Asiakas dummy = customerList.

                                       Find(x => x.customerNumber == response);

                                   Console.WriteLine($"Account {response} removed...");
                                   customerList.Remove(dummy);
                               }
               */
        }


        private static void GUITransferAccount()
        {

            GUIShowCustomer();
            bool validResponse = false;
            int response;
            int response2;

            do
            {
                Console.WriteLine(@"

                           Select Customernumber to be transferred to another customer.

                        ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = int.TryParse(guessInput, out response);

            } while (!validResponse);


            do
            {
                Console.WriteLine(@"

                           Select Customernumber of a new account holder.

                        ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = int.TryParse(guessInput, out response2);

            } while (!validResponse);


            if (confirmInput())
            {
                accounts dummy = context.accounts.Find(response);
                dummy.customer_number = response2;
                context.SaveChanges();
                Console.WriteLine($"Account {response} has new customer...");


            }
            Console.ReadLine();
            /*                       Asiakas dummy = customerList.

                                       Find(x => x.customerNumber == response);

                                   Console.WriteLine($"Account {response} removed...");
                                   customerList.Remove(dummy);
                               }
               */
        }

        private static void GUIDeleteAccount()
        {

            GUIShowAccount();

            bool validResponse = false;
            int response;
            do
            {
                Console.WriteLine(@"

                           Select Account number to be deleted

                        ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = int.TryParse(guessInput, out response);

            } while (!validResponse);



            if (confirmInput())
            {
                var dummy = context.accounts.FirstOrDefault<accounts>
                (x => x.account_number.Equals(response));

                context.accounts.Remove(dummy);
                context.SaveChanges();
            }

            /*                   foreach (PankkiTili iter in accountList)
                               {
                                   if (iter.accountNumber == response)
                                   {
                                       Console.WriteLine($"Account {response} removed...");
                                       accountList.Remove(iter);
                                       break;
                                   }
                               }
                           }
           */

        }



        private static void GUIChangeSaldo()
        {

            GUIShowAccount();
       

            bool validResponse = false;
            int response = default;
            decimal response2 = default;

            do
            {
                Console.WriteLine(@"
                           Select Account?
            ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = int.TryParse(guessInput, out response);

            } while (!validResponse);
            do
            {
                Console.WriteLine(@"

                           Initial change in saldo (negative for withdrawal)?

            ");

                string guessInput = Console.ReadLine();

                // convert string to number
                validResponse = decimal.TryParse(guessInput, out response2);
            } while (!validResponse);

            //---------------------------------------------------------------------------
            accounts dummy = context.accounts.Find(response);

            if (dummy.account_type.Equals(BankDefs.BankAccount))
            {
                dummy.account_saldo += response2;
                context.SaveChanges();
                Console.WriteLine($"Account {response} saldo changed...");
            }

            else
            {
                decimal? dummy2 = dummy.account_saldo + response2;

                if (dummy2 >= 0)
                {
                    dummy.account_saldo += response2;
                    context.SaveChanges();
                    Console.WriteLine($"Account {response} saldo changed...");
                }

                else if (dummy2 >= -dummy.credit_limit)
                {
                    dummy.account_saldo += response2;
                    context.SaveChanges();
                    Console.WriteLine($"Account uses now credit...");
                }

                else
                {
                    Console.WriteLine($"Account saldo cannot go that low...");
                }

            }
            Console.ReadLine();
        }





        private static bool confirmInput()
        {
            bool response = default;

            Console.WriteLine("Confirm Y/N?");

            string confirmInput = Console.ReadLine();

            if (confirmInput.ToUpper() == "Y")
            {
                return true;
            }

            return response;

        }

    }

}