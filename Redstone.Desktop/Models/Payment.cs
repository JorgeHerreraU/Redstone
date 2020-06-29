using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop.Models
{
    public class Payment
    {
        public string FormOfPayment { get; set; }
        public DateTime TransactionDate { get; set; }
        public int StageId { get; set; }
        public int PaidAmmount { get; set; }

        public virtual Stage Stage { get; set; }
    }
}
