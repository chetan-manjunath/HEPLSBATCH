using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_schedule
{
    public class editmodel
    {
        public DateTime arrivalDate { get; set; }
        public DateTime depatureDate { get; set; }
        public int TravelID { get; set; }

       public editmodel(DateTime arrivalDate, DateTime depatureDate, int TravelID)
        {
            this.arrivalDate = arrivalDate;
            this.depatureDate = depatureDate;
            this.TravelID = TravelID;
        }


    }
}
