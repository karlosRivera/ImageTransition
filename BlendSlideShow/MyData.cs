using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;


namespace BlendSlideShow
{


    [Table("MyData")]
    public partial class MyData
    {
        public int ID { get; set; }

        public DateTime? EDate { get; set; }

        public decimal? EAmount { get; set; }

        public DateTime? AddDate { get; set; }

        public DateTime? ModDate { get; set; }
    }

    public class DateRange
    {
        public static List<DateTime> GetDates(DateTime startdate, DateTime enddate)
        {
            //DateTime StartDate = new DateTime(2017, 01, 01);
            //DateTime EndDate = new DateTime(2017, 01, 20);

            List<DateTime> dates = Enumerable.Range(0, (enddate - startdate).Days + 1)
                .Select(day => startdate.AddDays(day)).ToList();

            return dates;
        }
    }
}
