using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
namespace codingchallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            dynamic op,username,type,id,cal;
            Console.WriteLine("do u want to  calculate interest rate:(y/n):");
            cal=Console.ReadLine();
            //while loop start
            while (cal == "y")
            {
                Console.WriteLine("you want to calculate compound or simple interest(c/s):");
                op = Console.ReadLine();
                //simpleinterst start
                if (op == "s")
                {
                    type = "simpleinterest";
                    Random random = new Random();
                    id = random.Next(0, 1000);
                    Console.WriteLine("enter user name:");
                    username = Console.ReadLine();
                    double prin, rate, interest, total_amt;
                    int year;
                    Console.Write("enter the Loan Amount:");
                    prin = Convert.ToDouble(Console.ReadLine());
                    Console.Write("enter the number of years :");
                    year = Convert.ToInt16(Console.ReadLine());
                    Console.Write("enter the rate Of interest:");
                    rate = Convert.ToDouble(Console.ReadLine());
                    interest = (prin * year * rate) / 100;
                    total_amt = prin + interest;
                    Console.WriteLine("total amount : {0}", total_amt);
                    Console.WriteLine("total interest :{0}", interest);
                  
                    SqlConnection myCon = new SqlConnection(@"Data Source=.;initial catalog=codingchellenge;Integrated Security=True");
                    SqlDataAdapter sqlda2 = new SqlDataAdapter($"insert into codingchellenge.dbo.userinfo(id,username,intersttype,total,principle,interest,time)values('{id}','{username}','{type}','{ total_amt}','{prin}','{rate}','{year}')", myCon);
                    DataTable dt = new DataTable();
                    sqlda2.Fill(dt);
                    Console.WriteLine("inserted successfully");
                }
                //simpleinterst end
                //compoundinterst start
                else if (op == "c")
                {

                    double Total=0, interest, y, annualCompound, Amount, tinterst;
                    type = "compoundinterest";
                    Random random = new Random();
                    id = random.Next(0, 1000);
                    Console.WriteLine("enter user name:");
                    username = Console.ReadLine();
                    Console.Write("enter the loan amount : ");
                    Amount = Convert.ToDouble(Console.ReadLine());
                    Console.Write("enter the Rate of interest : ");
                    interest = Convert.ToDouble(Console.ReadLine()) / 100;
                    Console.Write("enter the number of years : ");
                    y = Convert.ToDouble(Console.ReadLine());
                    Console.Write("number of times the interest will be Compounded (for anualy(1)/for semianualy(2)/for quetrly(3)/for monthly(12): ");
                    annualCompound = Convert.ToDouble(Console.ReadLine());
                   

                    for (int t = 1; t < y + 1; t++)
                    {
                        Total = Amount * Math.Pow((1 + interest / annualCompound),
                                                 (annualCompound * t));
                        Console.Write("your totalamount for Year {0} "+ "is {1:F0}. \n", t, Total);

                    }
                    
                    tinterst = Total - Amount;
                    Console.Write("total amount:");
                    Console.WriteLine(Total);
                    Console.Write("total compound interst:");
                    Console.WriteLine(tinterst);
                    SqlConnection myCon = new SqlConnection(@"Data Source=.;initial catalog=codingchellenge;Integrated Security=True");
                    SqlDataAdapter sqlda2 = new SqlDataAdapter($"insert into codingchellenge.dbo.userinfo(id,username,intersttype,total,principle,interest,time)values('{id}','{username}','{type}','{Total }','{Amount}','{interest}',{y})", myCon);
                    DataTable dt = new DataTable();
                    sqlda2.Fill(dt);
                    Console.WriteLine("inserted successfully");
                    // Console.ReadLine();

                }
                //compound interst end
                Console.WriteLine("do u want to  calculate interst rate:(y/n):");
                cal = Console.ReadLine();
            }
            //while loop end
        }

    }
    
}
