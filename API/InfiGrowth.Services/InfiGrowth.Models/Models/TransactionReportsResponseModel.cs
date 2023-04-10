using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Models.Models
{
    public class TransactionReportsResponseModel
    {
        public int ReportId { get; set; }
        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int PaymentId { get; set; }

    }
}
