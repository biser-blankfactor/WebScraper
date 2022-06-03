using System;
using ConsoleTables;
using Demo_1.Entities;

namespace Demo_1.Services
{
    public class ConsolePrinter
    {
        public void PrintToTable(IList<CoronaModel> savedModels)
        {
            var table = new ConsoleTable("No", "Country", "Continent", "Total Cases", "Active Cases", "Total Tests");

            foreach (var model in savedModels)
            {
                table.AddRow(model.Id, model.Country, model.Continent, model.TotalCases, model.ActiveCases, model.TotalTests);
            }

            table.Write();

            Console.WriteLine();
        }
    }
}

