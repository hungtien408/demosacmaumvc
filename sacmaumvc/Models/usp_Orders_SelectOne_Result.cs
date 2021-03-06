//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sacmaumvc.Models
{
    using System;
    
    public partial class usp_Orders_SelectOne_Result
    {
        public string OrderID { get; set; }
        public string UserName { get; set; }
        public Nullable<int> OrderStatusID { get; set; }
        public Nullable<int> ShippingStatusID { get; set; }
        public string PaymentMethodID { get; set; }
        public decimal Commission { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string OrderStatusName { get; set; }
        public string OrderStatusNameEn { get; set; }
        public string ShippingStatusName { get; set; }
        public string ShippingStatusNameEn { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodNameEn { get; set; }
        public Nullable<int> BillingAddressID { get; set; }
        public Nullable<int> ShippingAddressID { get; set; }
        public Nullable<decimal> OrderTotal { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string DeliveryMethodsName { get; set; }
        public string DeliveryMethodsNameEn { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string Email { get; set; }
    }
}
