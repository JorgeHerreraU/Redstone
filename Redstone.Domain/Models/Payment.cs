using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class Payment : BaseEntity
    {
        public int Id { get; set; }
        public string FormOfPayment { get; set; }
        public DateTime TransactionDate { get; set; }
        public int StageId { get; set; }
        public int PaidAmmount { get; set; }

        public virtual Stage Stage { get; set; }
    }
}
