using System;
using System.Collections.Generic;
using static System.Console;

namespace PayrollProject
{
    class Program
    {        
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();
            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Write("\nPlease enter the year: ");

                try
                {
                    string userInput = ReadLine();
                    year = Convert.ToInt32(userInput);
                }
                catch (FormatException e)
                {
                    WriteLine(e.Message);
                }
            }

            while (month == 0)
            {
                Write("\nPlease enter the month: ");

                try
                {
                    string userInput = ReadLine();
                    month = Convert.ToInt32(userInput);

                    if (month < 1 || month > 12)
                    {
                        WriteLine("Invalid month input");
                        month = 0;
                    }
                }
                catch (FormatException e)
                {
                    WriteLine(e.Message);
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                var employee = myStaff[i];

                try
                {
                    WriteLine($"Enter hours worked for {employee.NameOfStaff}");
                    string userInput = ReadLine();
                    employee.HoursWorked = Convert.ToInt32(userInput);
                    employee.CalculatePay();
                    WriteLine(employee);
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    i--;
                }
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            Read();
        }
    }
}
