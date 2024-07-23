using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptmk_test
{
    internal class Employee
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }

        public Employee(string fullName, DateTime birthDate, string sex)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Sex = sex;
        }
    }
}
