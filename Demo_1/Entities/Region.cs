using Demo_1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_1.Entities
{
    public class Region : Enumeration
    {
        //public static Region Unknown = new(0, nameof(Unknown));
        public static Region Europe = new(1, "Europe");
        public static Region NorthAmerica = new (2, "North America");
        public static Region Asia = new(3, "Asia");
        public static Region SouthAmerica = new (4, "South America");
        public static Region Africa = new(5, "Africa");
        public static Region Australia = new(6, "Australia/Oceania");
        public static Region Antarctica = new(7, "Antarctica");
        public static Region All = new(8, nameof(All));

        public Region(int id, string name) : base(id, name)
        {

        }
    }
}
