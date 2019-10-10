using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PayrollProject
{
    public class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear { JAN = 1, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff n in myStaff)
            {
                path = $"{n.NameOfStaff}.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    WriteLine($"PAYSLIP FOR {(MonthsOfYear)month} {year}");
                    WriteLine("==============================");
                    WriteLine($"Name of Staff: {n.NameOfStaff}");
                    WriteLine($"Hours Worked: {n.HoursWorked}\n");
                    WriteLine($"Base Pay: {n.BasePay}");

                    if (n.GetType() == typeof(Manager))
                    {
                        WriteLine($"Allowance: {((Manager)n).Allowance}\n");
                    }
                    else if (n.GetType() == typeof(Admin))
                    {
                        WriteLine($"Hours of Overtime: {((Admin)n).Overtime}\n");
                    }

                    WriteLine("==============================");
                    WriteLine($"Total Pay: {n.TotalPay:C}");
                    WriteLine("==============================");

                    writer.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result = from n in myStaff
                         where n.HoursWorked < 10
                         orderby n.NameOfStaff ascending
                         select new { n.NameOfStaff, n.HoursWorked };

            string path = "summary.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                WriteLine("Staff w/ less than 10 working hours this month\n");

                foreach (var n in result)
                {
                    WriteLine($"Name: {n.NameOfStaff}, Hours Worked: {n.HoursWorked}");
                }
                writer.Close();
            }
        }

        public override string ToString()
        {
            return $"Month: {month}, Year: {year}";
        }
    }
}
