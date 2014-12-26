using System.Collections.Generic;
using System.Linq;
using BanKai.Progress.LinqRelated.Models;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class BasicWhereFiltering
    {
        private readonly EmployeeRepository m_employeeRepository = new EmployeeRepository();

        private IEnumerable<Employee> GivenTheseEmployee()
        {
            return m_employeeRepository.GetAll();
        }

        private IEnumerable<Employee> GetEmployeeWhoseFullNameStartsWithU(
            IEnumerable<Employee> employees)
        {
            // Please delete the return statement and write your implementation here.
            // You are allowed to write just one line of code here (a line of code is
            // a statment ended with comma).
            return employees.Where(t=>t.FullName.StartsWith("U"));
        }

        private void CheckResult(IEnumerable<Employee> yourResult)
        {
            var expectedResult = new[]
            {
                m_employeeRepository["Naruto"],
                m_employeeRepository["Tatsuya"]
            };

            Assert.NotNull(yourResult);
            Assert.Equal(expectedResult, yourResult.Where(t => t.Equals(expectedResult[0]) || t.Equals(expectedResult[1])));
        }

        [Fact]
        public void RunTest()
        {
            IEnumerable<Employee> allEmployees = GivenTheseEmployee();

            IEnumerable<Employee> employeesGreaterThan15 =
                GetEmployeeWhoseFullNameStartsWithU(allEmployees);

            CheckResult(employeesGreaterThan15);
        }
    }
}