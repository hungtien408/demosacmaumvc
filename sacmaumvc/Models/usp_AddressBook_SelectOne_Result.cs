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
    
    public partial class usp_AddressBook_SelectOne_Result
    {
        public int AddressBookID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Fax { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public Nullable<bool> IsPrimary { get; set; }
        public Nullable<bool> IsPrimaryBilling { get; set; }
        public Nullable<bool> IsPrimaryShipping { get; set; }
        public string CountryShortName { get; set; }
        public string Nationality { get; set; }
        public string CountryName { get; set; }
        public string ProvinceShortName { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string RoleName { get; set; }
        public Nullable<decimal> ShippingPrice { get; set; }
        public Nullable<decimal> ProvinceShippingPrice { get; set; }
        public Nullable<bool> Gender { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
    }
}
