using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_schedule
{
    class PlacesModel
    {
        public string PlaceName { get; set; }
        public PlacesModel(string placeName)
        {
            PlaceName = placeName;
        }
    }
}
