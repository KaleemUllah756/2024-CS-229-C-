using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Train_Ticketing_System
{
    class Train
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }

        public Train(int id, string name, string route)
        {
            Id = id;
            Name = name;
            Route = route;
        }
    }
}
