using System;
namespace PayrollProject
{
    public class Admin : Staff
    {
        private const float overtimeRate = 15.5F;
        private const float adminHourlyRate = 30F;

        public float Overtime { get; private set; }

        public Admin(string name) : base(name, adminHourlyRate)
        {
        }

        public override void CalculatePay()
        {
            base.CalculatePay();

            if (HoursWorked > 160)
            {
                Overtime = (HoursWorked - 160) * overtimeRate;
                TotalPay = BasePay + Overtime;
            }
            else
            {
                Overtime = 0;
            }
        }

        public override string ToString()
        {
            return $"Admin Payroll Mode \n Name: {NameOfStaff} \n Hours Worked: {HoursWorked} \n Base Pay: {BasePay} \n Overtime Hours: {Overtime} \n Total Pay: {TotalPay}";
        }
    }
}
