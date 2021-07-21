using System;
using System.Collections.Generic;
using System.Text;

namespace PSQL_Dapper.Models
{
    public class State
    {
        public int id { get; set; }
        public string entity { get; set; }
        public double state{ get; set; }
        public DateTime timestamp { get; set; }
    }
}
