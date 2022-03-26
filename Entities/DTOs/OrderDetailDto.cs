using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDetailDto : IDto
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string ProductName { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public int Price { get; set; }
    }
}
