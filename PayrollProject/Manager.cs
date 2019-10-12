using System;

namespace PayrollProject
{
    public class Manager : Staff
    {
        private const float managerHourlyRate = 50;
        public int Allowance { get; private set; }

        public Manager(string name) : base(name, managerHourlyRate)
        {
        }

        public override void CalculatePay()
        {
            base.CalculatePay();

            if (HoursWorked > 160)
            {
                Allowance = 1000;
                TotalPay = BasePay + Allowance;
            }
            else
            {
                Allowance = 0;
            }
                
        }

        public override string ToString()
        {
            return $"Manager Payroll Mode \n Name: {NameOfStaff} \n Hours Worked: {HoursWorked} \n Base Pay: {BasePay} \n Allowance: {Allowance} \n Total Pay: {TotalPay}";
        }
    }
}
