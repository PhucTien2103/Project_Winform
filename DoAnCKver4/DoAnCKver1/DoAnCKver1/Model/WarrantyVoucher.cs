﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCKver1.Model
{
    public class WarrantyVoucher
    {
        public int VoucherId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
