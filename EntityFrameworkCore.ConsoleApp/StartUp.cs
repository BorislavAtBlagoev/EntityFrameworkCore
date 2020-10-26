using EntityFrameworkCore.Data.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EntityFrameworkCore.ConsoleApp
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();

            //var result = GetEmployeesFullInformation(context);
            //var result = GetEmployeesWithSalaryOver50000(context);
            //var result = GetEmployeesFromResearchAndDevelopment(context);
            //var result = AddNewAddressToEmployee(context);
            //var result = GetEmployeesInPeriod(context);
            //var result = GetAddressesByTown(context);
            //var result = GetEmployee147(context);
            //var result = GetDepartmentsWithMoreThan5Employees(context);
            //var result = GetLatestProjects(context);
            //var result = IncreaseSalaries(context);
            //var result = GetEmployeesByFirstNameStartingWithSa(context);
            //var result = DeleteProjectById(context, 2);
            var result = RemoveTown(context, "Seattle");

            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    Name = $"{e.FirstName} {e.MiddleName} {e.LastName}",
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.Id)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Name} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.Salary:F2}");
            }

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research And Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} {employee.Salary:F2}");
            }

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var adress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = adress;
            context.SaveChanges();

            var sb = new StringBuilder();

            var EmployeesAdresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .Take(10)
                .ToList();

            return sb.Append(String.Join(Environment.NewLine, EmployeesAdresses
                .Select(ea => ea.AddressText)))
                .ToString()
                .TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeesWithProjects = context.Employees
                .Where(e => e.EmployeesProjects
                             .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            ProjectStartDate = ep.Project.StartDate,
                            ProjectEndDate = ep.Project.EndDate
                        })
                })
                .Take(10)
                .ToList();

            foreach (var employee in employeesWithProjects)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    var endDate = project.ProjectEndDate != null
                        ? project.ProjectEndDate.Value.ToString("yyyy/d/M HH:mm:ss")
                        : "not finished";

                    sb.AppendLine($"-----{project.ProjectName} {project.ProjectStartDate} {endDate}");
                }

            }

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var adresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    EmployeeCount = a.Employees.Count,
                    TownName = a.Town.Name
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var adress in adresses)
            {
                sb.AppendLine($"{adress.AddressText}, {adress.TownName} - {adress.EmployeeCount}");
            }

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .OrderBy(ep => ep.Project.Name)
                        .Select(ep => ep.Project.Name)
                })
                .FirstOrDefault();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"-------{project}");
            }

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        })
                })
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.DepartmentName)
                .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"------{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate
                    .ToString("M / d / yyyy h: mm: ss tt"));
            }
            return sb
                .ToString()
                .TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var salaryIncrease = 1.12m;

            var employees = context.Employees
                .Where(e => departments.Contains(e.Department.Name));

            foreach (var employee in employees)
            {
                employee.Salary *= salaryIncrease;
            }

            context.SaveChanges();

            var employeeToPrint = employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employeeToPrint)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.Salary:F2}");
            }

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName
                             .StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context, int Id)
        {
            var sb = new StringBuilder();

            var project = context.Projects
                .Find(Id);

            var employeesProjects = context.EmployeesProjects
                .Where(ep => ep.Project.ProjectId == project.ProjectId);

            context.RemoveRange(employeesProjects);
            context.Remove(project);
            context.SaveChanges();

            var projectsToPrint = context.Projects
                .Select(e => new
                {
                    e.Name
                })
                .Take(10)
                .ToList();

            foreach (var projectToPrint in projectsToPrint)
            {
                sb.AppendLine(projectToPrint.Name);
            }

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context, string townName)
        {
            var townForDelete = context.Towns
                .Where(t => t.Name == townName)
                .FirstOrDefault();

            var addresses = context.Addresses
                .Where(a => a.TownId == townForDelete.TownId);

            var employees = context.Employees
                .Where(e => addresses.Contains(e.Address));

            foreach (var employee in employees)
            {
                employee.Address = null;
            }

            var removedAddresses = addresses.Count();

            context.RemoveRange(addresses);
            context.Remove(townForDelete);
            context.SaveChanges();

            var result = $"{removedAddresses} addresses in {townName} were deleted";

            return result
                .TrimEnd();
        }
    }
}
