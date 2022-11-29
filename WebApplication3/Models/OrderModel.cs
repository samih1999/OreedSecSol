using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public  class OrderModel
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public CustomerModel Customer { get; set; }
        public Type OrderType { get; set; }
        //public abstract void SendOrder(OrderModel order);

    }

   public enum Type {Special , Normal }
}
