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
            Allowance = 1000;

            if (HoursWorked > 160)
                TotalPay = BasePay + Allowance;
        }

        public override string ToString()
        {
            return $"Manager Payroll Mode \n Name: {NameOfStaff} \n Hours Worked: {HoursWorked} \n Base Pay: {BasePay} \n Allowance: {Allowance} \n Total Pay: {TotalPay}";
        }
    }
}
