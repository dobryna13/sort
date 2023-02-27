using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Підключення до бази даних
        using (var context = new MyDbContext())
        {
            // Отримуємо список співробітників з бази даних
            List<Employee> employees = context.Employees.ToList();

            // Сортуємо співробітників за зарплатою від найменшої до найбільшої
            employees = employees.OrderBy(e => e.Salary).ToList();

            // Виводимо відсортований список співробітників
            foreach (var employee in employees)
            {
                Console.WriteLine("Name: {0}, Salary: {1}", employee.Name, employee.Salary);
            }
        }
    }
}

// Клас співробітника
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public int Experience { get; set; }
}

// Клас контексту бази даних
class MyDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
    }
}

