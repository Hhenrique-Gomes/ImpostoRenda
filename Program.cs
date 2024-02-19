using ImpostoRenda.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ImpostoRenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of tax payers: ");
            int n = Convert.ToInt16(Console.ReadLine());
            List<TaxPayer> payer = new List<TaxPayer>();

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Tax payer {0} data", i+1);
                Console.Write("Individual or campany (i/c)? ");
                char type = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double income = Convert.ToDouble(Console.ReadLine(),CultureInfo.InvariantCulture);
                if(type == 'I')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = Convert.ToDouble(Console.ReadLine(),CultureInfo.InvariantCulture);
                    payer.Add(new Individual(name,income,healthExpenditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int employees = Convert.ToInt16(Console.ReadLine());
                    payer.Add(new Company(name, income, employees));
                }

            }

            Console.WriteLine();
            Console.WriteLine("Taxes paid: ");

            double sum = 0;

            foreach (TaxPayer tp in payer)
            {
                Console.WriteLine("{0}: R$ {1}", tp.Name, tp.Tax().ToString("F2", CultureInfo.InvariantCulture));
                sum += tp.Tax();
            }
            Console.Write("Total taxes: R$ {0}",sum);

            Console.ReadKey();
        }
    }
}
