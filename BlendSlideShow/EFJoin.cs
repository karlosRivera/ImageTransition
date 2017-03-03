using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlendSlideShow
{
    public partial class EFJoin : Form
    {
        public EFJoin()
        {
            InitializeComponent();
        }

        private void EFJoin_Load(object sender, EventArgs e)
        {
            List<MyData> data;
            DateTime StartDate = new DateTime(2017, 01, 01);
            DateTime EndDate = new DateTime(2017, 01, 20);

            using (var db = new LocalDbContext())
            {

                data = (from n in db.MyDatas
                        orderby n.AddDate
                        where DbFunctions.TruncateTime(n.EDate) >= StartDate.Date
                        && DbFunctions.TruncateTime(n.EDate) <= EndDate
                        select n).ToList();

                var result = from p in DateRange.GetDates(new DateTime(2017, 01, 01), new DateTime(2017, 01, 20))
                             join n in db.MyDatas on p equals n.EDate into g
                             from x in g.DefaultIfEmpty()
                             select new
                             {
                                 date = p,
                                 amount = x == null ? 0 : x.EAmount
                             };

                var xx = result.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<MyData> data;
            DateTime StartDate = new DateTime(2017, 01, 01);
            DateTime EndDate = new DateTime(2017, 01, 20);

            List<DateTime> list = DateRange.GetDates(StartDate, EndDate);

            using (var db = new LocalDbContext())
            {

                data = (from n in db.MyDatas
                        orderby n.AddDate
                        where DbFunctions.TruncateTime(n.EDate) >= StartDate.Date && DbFunctions.TruncateTime(n.EDate) <= EndDate
                        select n).ToList();

                var result = (from p in list
                             join n in data on p equals n.EDate into g
                             from x in g.DefaultIfEmpty()
                             select new
                             {
                                 date = p,
                                 amount = x == null ? 0 : x.EAmount
                             }).ToList();


            }
        }
    }
}
