using System;
using Demo_1.Entities;
using HtmlAgilityPack;

namespace Demo_1.Services
{
    public class HtmlDataParser
    {
        private readonly string siteUrl;
        private readonly string tableId;

        public HtmlDataParser(string siteUrl, string tableId)
        {
            this.siteUrl = siteUrl;
            this.tableId = tableId;
        }

        public IList<CoronaModel> Parse()
        {
            var web = new HtmlWeb();

            var doc = web.Load(siteUrl);

            var table = doc.DocumentNode
                .Descendants("table")
                .FirstOrDefault(d => d.Id.ToLower() == tableId);

            if (table == null)
            {
                throw new InvalidDataException("Invalid data source");
            }

            var tbody = table.Descendants("tbody").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains(""));

            var countryTrs = tbody.Descendants("tr").Where(d => !d.GetAttributeValue("class", "").Contains("total_row_world")).ToList();

            var models = new List<CoronaModel>();

            foreach (var countryElement in countryTrs)
            {
                var text = countryElement.InnerText;

                var splited = text.Split('\n', StringSplitOptions.None);

                if (splited.Length != 23)
                {
                    continue;
                }

                var model = new CoronaModel();
                model.Country = splited[2].Trim();
                model.Continent = splited[16].Trim();

                var totalCases = 0;
                if (int.TryParse(splited[3].Replace(",", ""), out totalCases))
                {
                    model.TotalCases = totalCases;
                }

                var activeCases = 0;
                if (int.TryParse(splited[9].Replace(",", ""), out activeCases))
                {
                    model.ActiveCases = activeCases;
                }

                var totalTests = 0;
                if (int.TryParse(splited[13].Replace(",", ""), out totalTests))
                {
                    model.TotalTests = totalTests;
                }

                models.Add(model);

            }

            return models;
        }
    }
}

