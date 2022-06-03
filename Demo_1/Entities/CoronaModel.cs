using System;
using System.ComponentModel.DataAnnotations;

namespace Demo_1.Entities
{
    public class CoronaModel
    {
        [Key]
        public int Id { get; set; }

        public string Continent { get; set; }

        public string Country { get; set; }

        public int TotalTests { get; set; } = -1;

        public int ActiveCases { get; set; } = -1;

        public int TotalCases { get; set; } = -1;
    }
}

