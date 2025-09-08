using System;
using System.Linq; // Needed for LINQ extension methods
using System.Collections.Generic;

namespace LinqTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== LINQ Queries Tutorial =====\n");

            // Filtering Operators
            var numbers = new[] { 1, 2, 3, 4, 5, 6 };
            var evenNumbers = numbers.Where(n => n % 2 == 0);

            Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));
            Console.ReadLine();

            // Projection Operators
            var squaredNumbers = numbers.Select(n => n * n);
            Console.WriteLine("Squared Numbers: " + string.Join(", ", squaredNumbers));
            Console.ReadLine();

            var words = new[] { "hello", "world" };
            var characters = words.SelectMany(w => w.ToCharArray());
            Console.WriteLine("Characters: " + string.Join(", ", characters));
            Console.ReadLine();

            // Sorting Operators
            var unsorted = new[] { 5, 1, 4, 2 };
            var sorted = unsorted.OrderBy(n => n);
            Console.WriteLine("Sorted Asc: " + string.Join(", ", sorted));
            Console.ReadLine();

            var sortedDesc = unsorted.OrderByDescending(n => n);
            Console.WriteLine("Sorted Desc: " + string.Join(", ", sortedDesc));
            Console.ReadLine();

            var people = new[]
            {
                new { Name = "John", Age = 30 },
                new { Name = "Alice", Age = 25 },
                new { Name = "John", Age = 22 }
            };
            var sortedPeople = people.OrderBy(p => p.Name).ThenBy(p => p.Age);
            Console.WriteLine("Sorted People (by Name then Age):");
            foreach (var p in sortedPeople)
                Console.WriteLine($"  {p.Name} - {p.Age}");

            Console.ReadLine();

            // Aggregation Operators
            Console.WriteLine($"Count: {numbers.Count()}");
            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.WriteLine($"Average: {numbers.Average()}");
            Console.WriteLine($"Min: {numbers.Min()}");
            Console.WriteLine($"Max: {numbers.Max()}");
            Console.WriteLine($"Has Even: {numbers.Any(n => n % 2 == 0)}");
            Console.WriteLine($"All Positive: {numbers.All(n => n > 0)}");
            Console.WriteLine($"Contains 3: {numbers.Contains(3)}");
            Console.ReadLine();

            // Distinct, Union, Intersect, Except
            var numbersWithDuplicates = new[] { 1, 2, 2, 3, 4, 4 };
            var distinctNumbers = numbersWithDuplicates.Distinct();
            Console.WriteLine("Distinct: " + string.Join(", ", distinctNumbers));
            Console.ReadLine();

            var set1 = new[] { 1, 2, 3 };
            var set2 = new[] { 3, 4, 5 };
            Console.WriteLine("Union: " + string.Join(", ", set1.Union(set2)));
            Console.WriteLine("Intersect: " + string.Join(", ", set1.Intersect(set2)));
            Console.WriteLine("Except: " + string.Join(", ", set1.Except(set2)));
            Console.ReadLine();

            // Partitioning
            Console.WriteLine("Take(2): " + string.Join(", ", numbers.Take(2)));
            Console.WriteLine("Skip(2): " + string.Join(", ", numbers.Skip(2)));
            Console.ReadLine();

            // Element Operators
            Console.WriteLine($"First: {numbers.First()}");
            Console.WriteLine($"FirstOrDefault Even: {numbers.FirstOrDefault(n => n % 2 == 0)}");
            Console.WriteLine($"Last: {numbers.Last()}");
            Console.WriteLine($"ElementAt(1): {numbers.ElementAt(1)}");
            Console.WriteLine($"ElementAtOrDefault(10): {numbers.ElementAtOrDefault(10)}");
            Console.ReadLine();

            // Join
            var employees = new[]
            {
                new { Id = 1, deptId=1, Name = "Alice" },
                new { Id = 2, deptId=2, Name = "Bob" }
            };
            var departments = new[]
            {
                new { Id = 1, Department = "HR" },
                new { Id = 2, Department = "IT" }
            };
            var employeeDepartments = employees.Join(departments,
                emp => emp.deptId,
                dept => dept.Id,
                (emp, dept) => new { emp.Name, dept.Department });

            Console.WriteLine("Employee Departments:");
            foreach (var ed in employeeDepartments)
                Console.WriteLine($"  {ed.Name} - {ed.Department}");
            Console.ReadLine();

            // GroupBy
            var groupedByAge = people.GroupBy(p => p.Age);
            Console.WriteLine("Grouped By Age:");
            foreach (var group in groupedByAge)
            {
                Console.WriteLine($"Age {group.Key}: {string.Join(", ", group.Select(p => p.Name))}");
            }
            Console.ReadLine();

            // Conversion Operators
            var list = numbers.ToList();
            var array = numbers.ToArray();
            var dictionary = people.ToDictionary(p => p.Name);
            Console.WriteLine("Dictionary Keys: " + string.Join(", ", dictionary.Keys));
            Console.ReadLine();

            var emptyNumbers = new int[] { };
            var defaultIfEmpty = emptyNumbers.DefaultIfEmpty(42);
            Console.WriteLine("DefaultIfEmpty: " + string.Join(", ", defaultIfEmpty));
            Console.ReadLine();
        }
    }
}
