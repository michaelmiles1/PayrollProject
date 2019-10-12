using System;
using static System.Console;

namespace PayrollProject
{
    public class Staff
    {
        private float hourlyRate;
        private int hWorked;

        public float TotalPay { get; protected set; }
        public float BasePay { get; private set; }
        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            WriteLine("Calculating Pay...");
            BasePay = hWorked * hourlyRate;
            TotalPay = BasePay;
        }

        public override string ToString()
        {
            return $"Name: {NameOfStaff} \n Hours Worked: {HoursWorked} \n Base Pay: {BasePay} \n Total Pay: {TotalPay}";
        }
    }
}
