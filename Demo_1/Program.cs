using Demo_1.Entities;
using Demo_1.Services;
using HtmlAgilityPack;

namespace Demo_1
{
    public class Program
    {
        public static int Main()
        {
            var url = @"https://www.worldometers.info/coronavirus/";
            var tableId = "main_table_countries_today";

            Console.WriteLine($"Our data source: {url}");
            var regions = Region.GetAll<Region>().ToList();
            var validSelections = regions.Select(r => r.Id.ToString()).ToList();
            var regionsFormatted = regions.OrderBy(r => r.Id).Select(r => $"{r.Id}.{r.Name}");
            Console.WriteLine($"Available Regions:");
            Console.WriteLine(String.Join(" | ", regionsFormatted));
            Console.Write($"Press Enter for All or Select region number: ");
            var selection = Console.ReadLine().Trim();

            Console.WriteLine("Loading...");

            var parser = new HtmlDataParser(url, tableId);

            var models = parser.Parse();

            var repoService = new RepositoryService();

            repoService.UpdateModels(models);

            var hasValidSelection = validSelections.Contains(selection);

            IList<CoronaModel> savedModels = default;

            var selectedRegionName = "All";

            if (hasValidSelection)
            {
                selectedRegionName = regions.First(r => r.Id.ToString() == selection).Name;

                savedModels = repoService.GetModelsForRegion(selectedRegionName);
            }
            else
            {
                savedModels = repoService.GetModelsForRegion();
            }

            Console.WriteLine($"Results for {selectedRegionName} region(s)");

            var printer = new ConsolePrinter();

            printer.PrintToTable(savedModels);

            var fileService = new FileWriterService();

            fileService.WriteToCSV(selectedRegionName, savedModels);

            Console.Write($"Press any key to exit");
            Console.ReadKey();
            return 0;
        }
    }
}

