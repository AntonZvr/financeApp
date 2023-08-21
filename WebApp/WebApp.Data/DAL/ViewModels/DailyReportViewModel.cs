using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Models;

namespace WebApp.Data.DAL.ViewModels
{
    public class DailyReport
    {
        public double Income { get; set; }
        public double Expenses { get; set; }
        public List<Transaction> Transactions { get; set; }
    }

}
