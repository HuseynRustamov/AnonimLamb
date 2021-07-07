using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonimLambda
{
	class Program
	{
		static void Main(string[] args)
		{
			var debtors = DebtorContainer.GetDebtors();

			var debtorsByDomains = debtors
				.Where(d =>
				{
					var domainAddress = d.Email.Split('@')[1];

					if (domainAddress == "rhyta.com" || domainAddress == "dayrep.com")
						return true;
					return false;
				})
				.ToList();


			var debtorsByAge = debtors.Where(d =>
			{
				var age = DateTime.Now.Year - d.BirthDay.Year;

				if (age > 25 && age < 36)
					return true;
				return false;
			})
				.ToList();


			var debtorsByDebt = debtors
				.Where(d => d.Debt <= 5000)
				.ToList();


			var debtorsByNameLength = debtors
				.Where(d => d.FullName.Length > 18)
				.Where(d => d.Phone.Count(c => c == '7') >= 2)
				.ToList();


			var onlyWinterDebtors = debtors
				.Where(d => d.BirthDay.Month == 12 || d.BirthDay.Month == 1 || d.BirthDay.Month == 2)
				.ToList();


			var averageDebt = debtors.Average(d => d.Debt);

			var debtorsHigherThanAvg = debtors.
				Where(d => d.Debt > averageDebt)
				.ToList();

			var debtorsSortedBySurname = debtorsHigherThanAvg.OrderBy(d =>
			{
				var nameComponents = d.FullName.Split(' ');

				return nameComponents[nameComponents.Length - 1];
			})
				.ToList();


			var descDebtorsSortedByDebt = debtorsHigherThanAvg
				.OrderByDescending(d => d.Debt)
				.ToList();


			var debtors3 = debtors
				.Where(d => !d.Phone.Contains('8'))
				.ToList();

			debtors3.ForEach(d =>
			{
				var nameComponents = d.FullName.Split(' ');

			});



			var debtors4 = debtors
				.Where(d => d.FullName.CheckOccurrence(3))
				.OrderBy(d => d.FullName)
				.ToList();



			var years = debtors.Select(d => d.BirthDay.Year).ToList();

			var year = years.GetMostOccurrenceData();


			var firstFiveHigherDebtors = debtors
				.OrderByDescending(d => d.Debt)
				.Take(5)
				.ToList();




			var totalDebt = debtors.Sum(d => d.Debt);



			var debtorsBySecondWoW = debtors
				.Where(d => d.BirthDay.Year >= 1939 &&
							d.BirthDay.Year <= 1945)
				.ToList();



			var debtors5 = debtors.Where(d =>
			{
				for (var i = 0; i < d.Phone.Length; i++)
				{
					if (!char.IsDigit(d.Phone[i]))
						continue;

					if (d.Phone.Count(n => n == d.Phone[i]) != 1)
						return false;
				}

				return true;
			}).ToList();

			debtors5.ForEach(d =>
			{
				Console.WriteLine($"{d.FullName} {d.Debt}");
			});


			var oneYearDebt = 6000;

			Func<int, int, bool> payChecker = (debt, month) => debt - (month * 500) <= 0;
			var debtors6 = debtors.Where(d =>
			{
				if (d.Debt <= oneYearDebt)
				{
					var birthMonth = d.BirthDay.Month;
					var nowMonth = DateTime.Now.Month;

					if (birthMonth > nowMonth)
					{
						if (payChecker(d.Debt, (birthMonth - nowMonth)))
							return true;
					}
					else
					{
						if (payChecker(d.Debt, ((12 + birthMonth) - nowMonth)))
							return true;
					}
				}
				return false;
			}).ToList();

			debtors6.ForEach(Console.WriteLine);



			var debtors7 = debtors.Where(d =>
			{
				var fullname = d.FullName.ToLower();
				foreach (var character in "smile")
				{
					if (!fullname.Contains(character))
						return false;
				}

				return true;
			}).ToList();

			debtors7.ForEach(Console.WriteLine);

			Console.ReadLine();
		}

	}
}