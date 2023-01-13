﻿using Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ResponseModel
{
    public class Order : VBaseModel
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProdProcessingId { get; set; }
        public string Code { get; set; }
        public string CodeVoucher { get; set; }
        public int? TypeVoucher { get; set; }
        public int Status { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime? TimeOrder { get; set; }
        public DateTime? TimeDeliveryStart { get; set; }
        public DateTime? EstimateDeliveryTime { get; set; }
        public DateTime? SuccessfulDeliveryTime { get; set; }
        public string Note { get; set; }
    }
}
