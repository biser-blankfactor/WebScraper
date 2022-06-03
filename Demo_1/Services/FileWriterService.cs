using CsvHelper;
using Demo_1.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_1.Services
{
    public class FileWriterService
    {
        public void WriteToCSV(string regionName, IList<CoronaModel> coronaModels)
        {
            var date = DateTime.Now.ToString("yy_MM_dd");

            using (var writer = new StreamWriter($"export_{regionName}_{date}.csv"))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(coronaModels);
                }
            }           
        }
    }
}
