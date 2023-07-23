//using Microsoft.Ajax.Utilities;
using UETV.Controllers;
using UETV;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace UETV.Models
{

    public class Models
    {

    }
    public class SensorReadings
    {
        public string firstSensor { get; set; }
        public string fMinVal { get; set; }
        public string fMaxVal { get; set; }
        public string secondSensor { get; set; }
        public string sMinVal { get; set; }
        public string sMaxVal { get; set; }

    }
    public class LoginRequest
    {

        //[Required(ErrorMessage = "3001")]
        //public string Username { get; set; }
        //[Required(ErrorMessage = "3001")]
        //[StringLength(100, MinimumLength = 6, ErrorMessage =  "3002") ]

        //public string Password { get; set; }
        [Required(ErrorMessage = "3001")]
        public string userToken { get; set; }
    }
    public class LoginGetRequest
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
    }
    public class Dynammic_Dashboard_Filters_Element_Alone : LoginGetRequest
    {
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
        public int? pageSize { get; set; }
        public int? pageNumber { get; set; }
        [Required(ErrorMessage = "3001")]
        public int elementId { get; set; }
        [Required(ErrorMessage = "3001")]
        public string appendex { get; set; }

    }
    public class Dynammic_Dashboard_Filters : LoginGetRequest
    {
   public DateTime? dateFrom { get; set; }
   public DateTime? dateTo { get; set; }
   public int? pageSize { get; set; }
   public int? pageNumber { get; set; }
    }
        public class Get_Visits_Filters : LoginGetRequest
    {
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
    }
    public class PushNotificationModel
    {
        public int id { get; set; }
        public int deviceId { get; set; }
        public string deviceName { get; set; }
        public string deviceIp { get; set; }
        public string deviceLat { get; set; }
        public string deviceLong { get; set; }
        public string deviceRtsp { get; set; }
        public int areaId { get; set; }
        public string areaName { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
        public string strangerImageUrl { get; set; }
        public string creationTime { get; set; }
        public bool isSent { get; set; }

    }
    public class CameraRecordsFilters : LoginGetRequest
    {
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
        public int? cameraId { get; set; }
    }
    public class CameraCandidatesFilters : LoginGetRequest
    {
        public int? deviceId { get; set; }
        public int? areaId { get; set; }
        public int? floorId { get; set; }
        public string candidateId { get; set; }
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
    }
    public class CameraRealTimeFilters : LoginGetRequest
    {
        public int? deviceId { get; set; }
        public int? areaId { get; set; }
        public int? floorId { get; set; }
        public int? personId { get; set; }
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
    }
    public class DashboardGetRequest
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
    }
    public class TowFactorAuth
    {
        [Required(ErrorMessage = "3001")]
        public string email { get; set; }
        [Required(ErrorMessage = "3001")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{4}$", ErrorMessage = "Please enter valid code")]

        public string code { get; set; }
    }
    public class APIStatus
    {
        public int code { get; set; }
        public string message { get; set; }

    }
    public class Get_Item_Group
    {

        public int id { get; set; }

        public string itemGroupName { get; set; }
        public string itemGroupImage { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
    }
    public class Post_Item_Group

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [Required(ErrorMessage = "3001")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "3022")]
        [CustomValidation(typeof(Bussiness_API_Config), "IsContainsNumbersOrSpecialCharsOnly")]
        public string itemGroupName { get; set; }
        public string itemGroupImage { get; set; }

        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }

    }
    public class Edit_Item_Group : Post_Item_Group
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }

    }
    public class Get_Items_Preques
    {
        public int id { get; set; }
        public string itemName { get; set; }
        public string itemImage { get; set; }
    }
    public class Item_Package_Preques
    {
        public List<Get_Items_Preques> items { get; set; }
        public List<RelatedUsersOfLoggedUser> relatedUsers { get; set; }
    }
    public class Post_Item_Package

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "3023")]
        [CustomValidation(typeof(Bussiness_API_Config), "ValidateItemPackageName")]

        public string itemPackageName { get; set; }
        [Required(ErrorMessage = "3001")]
        public int itemId { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3024")]
        public double packageQuantity { get; set; }
    }
    public class Edit_Item_Package : Post_Item_Package
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }

    }
    public class Get_Maintenance_Types
    {

        public int id { get; set; }

        public string maintenanceTypeName { get; set; }
        public bool isActive { get; set; }
    }
    public class Post_MaintenanceType

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "3001")]
        public string maintenanceTypeName { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isActive { get; set; }
    }
    public class Edit_MaintenanceTypes : Post_MaintenanceType
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }

    }
    public class Get_Currencies
    {

        public int id { get; set; }

        public string currencyName { get; set; }
        public bool isActive { get; set; }

    }
    public class Post_Currency

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "3001")]
        public string currencyName { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isActive { get; set; }
    }
    public class Edit__Currency : Post_Currency
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }

    }
    public class Get_Sub_Categories
    {

        public int id { get; set; }
        public string subCategoryName { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public bool isActive { get; set; }
    }
    public class Post_Sub_Category

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "3001")]
        public string subCategoryName { get; set; }
        [Required(ErrorMessage = "3001")]
        public int categoryId { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isActive { get; set; }
    }
    public class Edit_Sub_Category : Post_Sub_Category
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }

    }
    public class Get_UOMs
    {

        public int id { get; set; }
        public string uomName { get; set; }
        public string uomDescription { get; set; }
        public bool isActive { get; set; }
    }
    public class Post_UOM
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "3001")]
        public string uomName { get; set; }
        public string uomDescription { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isActive { get; set; }
    }
    public class Edit_UOM : Post_UOM
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }

    }
    public class Get_Fuels
    {
        public int id { get; set; }
        public string fuelName { get; set; }
        public string fuelCode { get; set; }
        public int uomId { get; set; }
        public string uomName { get; set; }
    }
    public class Post_Fuel

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "3001")]
        public string fuelName { get; set; }
        [Required(ErrorMessage = "3001")]
        public string fuelCode { get; set; }
        [Required(ErrorMessage = "3001")]
        public int uomId { get; set; }

    }
    public class Edit_Fuel : Post_Fuel
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }

    }
    public class Get_Customers
    {
        public int id { get; set; }
        public string customerName { get; set; }
        public string mailAddress { get; set; }
        public string mobileNumber { get; set; }
        public string landLine { get; set; }
        public string address { get; set; }
        public bool isActive { get; set; }
    }
    public class Post_Customer

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "3001")]
        public string customerName { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required(ErrorMessage = "3001")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string mailAddress { get; set; }

        [StringLength(15)]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid mobile no.")]
        public string mobileNumber { get; set; }

        [StringLength(15)]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{8,15}$", ErrorMessage = "Please enter valid landline no.")]
        public string landLine { get; set; }

        [Required(ErrorMessage = "3001")]
        [StringLength(300)]
        public string address { get; set; }

        [Required(ErrorMessage = "3001")]
        public bool isActive { get; set; }
    }
    public class Edit_Customer : Post_Customer
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
    }
    public class Get_MaintenanceCenters
    {
        public int id { get; set; }
        public string maintenanceCenterName { get; set; }
        public string mailAddress { get; set; }
        public string mobileNumber { get; set; }
        public string landLine { get; set; }
        public string address { get; set; }
        public bool isActive { get; set; }
    }
    public class Post_MaintenanceCenter

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "3001")]
        public string maintenanceCenterName { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required(ErrorMessage = "3001")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string mailAddress { get; set; }

        [StringLength(15)]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid mobile no.")]
        public string mobileNumber { get; set; }

        [StringLength(15)]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{8,15}$", ErrorMessage = "Please enter valid landline no.")]
        public string landLine { get; set; }

        [Required(ErrorMessage = "3001")]
        [StringLength(300)]
        public string address { get; set; }

        [Required(ErrorMessage = "3001")]
        public bool isActive { get; set; }
    }
    public class Edit_MaintenanceCenter : Post_MaintenanceCenter
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
    }
    public class Get_Technicians
    {
        public int id { get; set; }
        public string technicianName { get; set; }
        public int maintenanceCenterId { get; set; }
        public string maintenanceCenterName { get; set; }
        public string creator { get; set; }
        public string creationTime { get; set; }
        public string modifier { get; set; }
        public string modificationTime { get; set; }
        public bool isActive { get; set; }
    }
    public class Post_Technician
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public string technicianName { get; set; }
        [Required(ErrorMessage = "3001")]
        public int maintenanceCenterId { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isActive { get; set; }
    }
    public class Edit_Technician : Post_Technician
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
    }
    public class APIRequestUser
    {
        public int userId { get; set; }
        public int timeZone { get; set; }
        // public Role role { get; set; }
    }
    public class Employee_APIRequestUser
    {
        public int userId { get; set; }
        public int timeZone { get; set; }
        public int parentId { get; set; }
        public Employee_Role role { get; set; }
    }
    public class RelatedUsersOfLoggedUser
    {
        public int userId { get; set; }
        public string name { get; set; }
    }
    public class RelatedUsersIncomingInvoicePrequs : RelatedUsersOfLoggedUser
    {
        public List<SupplierItems> suppliersItems { get; set; }
    }
    public class IncomingInvoicePrequs
    {
        public List<Item_Vendors> suppliers { get; set; }
        public List<RelatedUsersOfLoggedUser> relatedUsers { get; set; }
        public List<Invoice_Type> invoiceTypes { get; set; }
        public List<ItemsInStock> items { get; set; }

    }
    public class Invoice_Type
    {
        public string invoiceTypeName { get; set; }
    }
    public class Get_Invoices
    {
        public int id { get; set; }
        public string invoiceNumber { get; set; }
        public double taxPercent { get; set; }
        public double shippingPercent { get; set; }
        public double othersPercent { get; set; }
        public double discountPercent { get; set; }
        public int supplierId { get; set; }
        public string supplierName { get; set; }
        public double totalCost { get; set; }
        public string invoiceType { get; set; }
        public bool updateItemInventoryQuantity { get; set; }
        public bool updateItemInventoryCost { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public string addedIn { get; set; }
        public string addedBy { get; set; }
        public string editedBy { get; set; }
        public List<IncomingInvoiceItems> invoiceItems { get; set; }
    }
    public class IncomingInvoiceItems
    {
        public int invoiceItemId { get; set; }
        public int itemId { get; set; }
        public string itemName { get; set; }
        public double unitCost { get; set; }
        public double itemQuantity { get; set; }
        public double totalCost { get; set; }
        public string itemImage { get; set; }
    }
    public class PostIncomingInvoiceItems
    {
        [Required(ErrorMessage = "3001")]
        public int itemId { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3010")]
        public double unitCost { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3011")]
        public double itemQuantity { get; set; }
    }
    public class EditIncomingInvoiceItems : PostIncomingInvoiceItems
    {
        [Required(ErrorMessage = "3001")]
        public int invoiceItemId { get; set; }
    }
    public class Post_Invoice
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [Required(ErrorMessage = "3001")]
        [RegularExpression("([0-9]+)", ErrorMessage = "3003")]
        public string invoiceNumber { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, 100, ErrorMessage = "3004")]
        public double taxPercent { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, 100, ErrorMessage = "3005")]
        public double shippingPercent { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, 100, ErrorMessage = "3006")]
        public double othersPercent { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, 100, ErrorMessage = "3007")]
        public double discountPercent { get; set; }
        [Required(ErrorMessage = "3001")]
        public int supplierId { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "3008")]
        public double totalCost { get; set; }
        [Required(ErrorMessage = "3001")]
        [CustomValidation(typeof(Bussiness_API_Config), "ValidateinvoiceType", ErrorMessage = "3009")]
        public string invoiceType { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool updateItemInventoryQuantity { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool updateItemInventoryCost { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool updateItemSupplier { get; set; }

        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        public List<PostIncomingInvoiceItems> invoiceItems { get; set; }
    }
    public class Edit_Invoice
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
        [Required(ErrorMessage = "3001")]
        [RegularExpression("([0-9]+)", ErrorMessage = "3003")]
        public string invoiceNumber { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, 100, ErrorMessage = "3004")]
        public double taxPercent { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, 100, ErrorMessage = "3005")]
        public double shippingPercent { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, 100, ErrorMessage = "3006")]
        public double othersPercent { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, 100, ErrorMessage = "3007")]
        public double discountPercent { get; set; }
        [Required(ErrorMessage = "3001")]
        public int supplierId { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "3008")]
        public double totalCost { get; set; }
        [Required(ErrorMessage = "3001")]
        [CustomValidation(typeof(Bussiness_API_Config), "ValidateinvoiceType", ErrorMessage = "3009")]
        public string invoiceType { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool updateItemInventoryQuantity { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool updateItemInventoryCost { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool updateItemSupplier { get; set; }


        [Required(ErrorMessage = "3001")]
        public List<EditIncomingInvoiceItems> invoiceItems { get; set; }
    }
    public class LoggedUser
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string personName { get; set; }
        public string userEmail { get; set; }
        public int timeZone { get; set; }
        //  public long endDate { get; set; }
        public Role role { get; set; }
        public List<RelatedUsersOfLoggedUser> relatedUsers { get; set; }
    }
    public class Employee_LoggedUser
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string personName { get; set; }
        public string userEmail { get; set; }
        public int timeZone { get; set; }
        public int parentId { get; set; }
        public long endDate { get; set; }
        public Employee_Role role { get; set; }
    }
    public class JumpToRole
    {
        public int gps_tracking { get; set; }
        public int fms { get; set; }
        public int crm { get; set; }
        public int workforce { get; set; }
        public int events { get; set; }
        public int sales_orders { get; set; }
        public int inventory { get; set; }
        public int hr { get; set; }
        public int sdms { get; set; }
        public int indroors { get; set; }
        public int tenders { get; set; }
        public int talk { get; set; }
    }
    public class Role
    {

        public int roleid { get; set; }
        public List<int> users { get; set; }
        public List<int> dashboard { get; set; }
        public List<int> cameras { get; set; }
        public List<int> records { get; set; }
        public List<int> stream { get; set; }
        public List<int> ftpCredntials { get; set; }
        public List<int> dahwaCameraAnalytics { get; set; }


    }
    public class Post_User_Role
    {
        public int[] users = new int[4];
        public int[] dashboard = new int[4];
        public int[] cameras = new int[4];
        public int[] records = new int[4];
        public int[] stream = new int[4];
        public int[] ftpCredntials = new int[4];
    }
    public class Edit_User_Role
    {
        public int id { get; set; }
        public int[] users = new int[4];
        public int[] dashboard = new int[4];
        public int[] cameras = new int[4];
        public int[] records = new int[4];
        public int[] stream = new int[4];
        public int[] ftpCredntials = new int[4];

    }
    public class Employee_Role
    {
        public int bills { get; set; }
    }
    public class ItemStatus
    {
        public string itemStatusId { get; set; }
        public string itemStatusName { get; set; }
    }
    public class ItemDescription
    {
        public string itemDescriptionId { get; set; }
        public string itemDescriptionName { get; set; }
    }
    public class UomPreques
    {
        public int uomId { get; set; }
        public string uomName { get; set; }
    }
    public class CurrenciesPreques
    {
        public int currencyId { get; set; }
        public string currencyName { get; set; }
    }
    public class CategoriesPreques
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public List<SubCategoriesPreques> subcategoriesList { get; set; }
    }
    public class SubCategoriesPreques
    {
        public int subcategoryId { get; set; }
        public string subcategoryName { get; set; }
        public int categoryId { get; set; }

    }
    public class ItemsPreqs
    {
        public List<RelatedUsersOfLoggedUser> relatedUsers { get; set; }
        public List<Item_Units> itemUnits { get; set; }
        public List<Item_Groups> itemGroups { get; set; }
        public List<Item_Vendors> vendors { get; set; }
    }
    public class Item_Vendors
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class SupplierItems
    {
        public int supplierId { get; set; }
        public string supplierName { get; set; }
        public List<ItemsInStock> items { get; set; }
    }
    public class ItemsInStock
    {
        public int itemId { set; get; }
        public string itemName { get; set; }
        public string itemImage { get; set; }
        public string itemBarcode { get; set; }
        public string itemSku { get; set; }
        public double purchasingPrice { get; set; }
    }
    public class Item_Groups
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }
    public class Item_Units
    {
        public string name { get; set; }
    }
    public class Get_Items
    {
        public int id { get; set; }
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public string itemImage { get; set; }
        public string itemBarcode { get; set; }
        public string itemSku { get; set; }
        public double itemWeight { get; set; }
        public string manufacturer { get; set; }
        public string brand { get; set; }
        public string upc { get; set; }
        public string mpn { get; set; }
        public string ean { get; set; }
        public string isbn { get; set; }

        public int vendorId { get; set; }
        public string vendorName { get; set; }

        public double sellingPrice { get; set; }
        public double purchasingPrice { get; set; }
        public double quantity { get; set; }
        public double quantityCost { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public double reorderLevel { get; set; }
        public string itemDimension { get; set; }

        public Dimentions itemDimensions { get; set; }
        public string itemUnit { get; set; }
    }
    public class Get_Staff_Safe
    {
        public int id { get; set; }
        public string name { get; set; }
        public double safe { get; set; }
    }
    public class Get_Staff_Balance
    {
        public int id { get; set; }
        public string name { get; set; }
        public double balance { get; set; }
    }
    public class Get_Company_Safes
    {
        public int id { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public double safe { get; set; }
    }
    public class Edit_Staff_Balance
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool addToBalance { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool reduceFromBalance { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3057")]
        public double balance { get; set; }
    }
    public class Get_Customer_Balance
    {
        public int id { get; set; }
        public string name { get; set; }
        public double balance { get; set; }
    }
    public class Edit_Customer_Balance
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool addToBalance { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool reduceFromBalance { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3057")]
        public double balance { get; set; }
    }
    public class Get_Supplier_Balance
    {
        public int id { get; set; }
        public string name { get; set; }
        public double balance { get; set; }
    }
    public class Edit_Supplier_Balance
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool addToBalance { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool reduceFromBalance { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3057")]
        public double balance { get; set; }
    }
    public class Get_Customer_Creadit
    {
        public int id { get; set; }
        public string customerName { get; set; }
        public string companyId { get; set; }
        public string company { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public double balance { get; set; }
        public double creadit { get; set; }
    }
    public class Edit_Customer_Creadit
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3056")]
        public double creadit { get; set; }
    }
    public class Get_Supplier_Creadit
    {
        public int id { get; set; }
        public string supplierName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public double creadit { get; set; }
    }
    public class Edit_Supplier_Creadit
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3057")]
        public double creadit { get; set; }
    }
    public class Dimentions
    {
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3049")]
        public double length { get; set; }
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3050")]
        public double height { get; set; }
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3051")]
        public double width { get; set; }
    }
    public class Post_Item

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int groupId { get; set; }
        [Required(ErrorMessage = "3001")]
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public string itemImage { get; set; }
        [Required(ErrorMessage = "3001")]
        public string itemBarcode { get; set; }
        [Required(ErrorMessage = "3001")]
        public string itemSku { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3064")]
        public double itemWeight { get; set; }
        public string manufacturer { get; set; }
        public string brand { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "3041")]
        public string upc { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "3042")]
        [StringLength(70, MinimumLength = 1, ErrorMessage = "3065")]
        public string mpn { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "3043")]
        public string ean { get; set; }

        [CustomValidation(typeof(Bussiness_API_Config), "ValidateISBN")]
        public string isbn { get; set; }
        [Required(ErrorMessage = "3001")]
        public int vendorId { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3045")]
        public double sellingPrice { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3046")]
        public double purchasingPrice { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3047")]
        public double quantity { get; set; }
        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "3048")]
        public double reorderLevel { get; set; }
        [Required(ErrorMessage = "3001")]
        public Dimentions itemDimensions { get; set; }
        [Required(ErrorMessage = "3001")]
        public string itemUnit { get; set; }
    }
    public class Edit_Item : Post_Item
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }

    }
    public class Get_Mainstocks
    {
        public int id { get; set; }
        public string mainstockName { get; set; }
        public bool isActive { get; set; }

    }
    public class Post_Mainstock

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "3001")]
        public string mainstockName { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isActive { get; set; }
    }
    public class Edit_Mainstock : Post_Mainstock
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }

    }
    public class Get_MainstockItems : Get_Items
    {
        public int mainstockItemId { get; set; }
        public int mainstockId { get; set; }
        public string mainstockName { get; set; }
        public double itemQuantity { get; set; }
    }
    public class Get_Substocks
    {
        public int id { get; set; }
        public string substockName { get; set; }
        public int mainstockId { get; set; }
        public string mainstockName { get; set; }
        public bool isActive { get; set; }
    }
    public class Post_Substock

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "3001")]
        public string substockName { get; set; }
        [Required(ErrorMessage = "3001")]
        public int mainstockId { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isActive { get; set; }
    }
    public class Edit_Substock : Post_Substock
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }

    }
    public class Get_SubstockItems : Get_Items
    {
        public int substockItemId { get; set; }
        public int substockId { get; set; }
        public string substockName { get; set; }
        public double itemQuantity { get; set; }
    }
    public class Get_Suppliers
    {
        public int id { get; set; }
        public string supplierName { get; set; }
        public string mobileNumber { get; set; }
        public string landLine { get; set; }
        public string fax { get; set; }
        public string address { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
    }
    public class Post_Supplier

    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [Required(ErrorMessage = "3001")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "3028")]
        [CustomValidation(typeof(Bussiness_API_Config), "IsContainsNumbersOrSpecialCharsOnly")]
        public string supplierName { get; set; }

        [Required(ErrorMessage = "3001")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "3029")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "3030")]
        public string mobileNumber { get; set; }

        [StringLength(13, MinimumLength = 7, ErrorMessage = "3031")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{7,13}$", ErrorMessage = "3032")]
        public string landLine { get; set; }


        [StringLength(13, MinimumLength = 7, ErrorMessage = "3033")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{7,13}$", ErrorMessage = "3034")]
        public string fax { get; set; }

        [Required(ErrorMessage = "3001")]
        [CustomValidation(typeof(Bussiness_API_Config), "AddressContainsSpecialCharsOnly")]
        public string address { get; set; }

        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
    }

    public class Get_Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public string timeZone { get; set; }

        public string phone { get; set; }
        public string email { get; set; }
        //   public string expireDate { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationtime { get; set; }
        public Role role { get; set; }


    }
    public class Users_Preques
    {
        public List<RelatedUsersOfLoggedUser> relatedUsers { get; set; }
    }
    public class Post_User
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "4000")]
        public string name { get; set; }

        [Required(ErrorMessage = "3001")]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "4001")]
        public string userName { get; set; }

        [Required(ErrorMessage = "3001")]
        //  [StringLength(50, MinimumLength = 6, ErrorMessage = "Password field must be at least 6 characters")]
        [CustomValidation(typeof(Bussiness_API_Config), "PasswordValidation")]
        public string password { get; set; }

        [Required(ErrorMessage = "3001")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "4005")]
        [StringLength(15)]
        public string phone { get; set; }

        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, 24, ErrorMessage = "Invalid value for input timeZone")]
        public double timeZone { get; set; }

        [Required(ErrorMessage = "3001")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "4006")]
        public string email { get; set; }

        [Required(ErrorMessage = "3001")]
        [CustomValidation(typeof(Bussiness_API_Config), "accountExpiresIn")]
        public DateTime accountExpiresIn { get; set; }

        [Required(ErrorMessage = "3001")]
        public Post_User_Role role { get; set; }
    }
    public class Edit_User
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "4000")]
        public string name { get; set; }

        [Required(ErrorMessage = "3001")]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "4001")]
        public string userName { get; set; }

        //[Required(ErrorMessage = "3001")]
        //  [StringLength(50, MinimumLength = 6, ErrorMessage = "Password field must be at least 6 characters")]
        [CustomValidation(typeof(Bussiness_API_Config), "PasswordValidation")]
        public string password { get; set; }

        [Required(ErrorMessage = "3001")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "4005")]
        [StringLength(15)]
        public string phone { get; set; }

        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, 24, ErrorMessage = "Invalid value for input timeZone")]
        public double timeZone { get; set; }

        [Required(ErrorMessage = "3001")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "4006")]
        public string email { get; set; }

        [Required(ErrorMessage = "3001")]
        [CustomValidation(typeof(Bussiness_API_Config), "accountExpiresIn")]
        public DateTime accountExpiresIn { get; set; }

        [Required(ErrorMessage = "3001")]
        public Edit_User_Role role { get; set; }
    }

    public class Get_Cameras
    {
        public int id { get; set; }
        public string cameraIp { get; set; }
        public string cameraName { get; set; }
        public string cameraImage { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }

        public int framePerSecond { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string rtspLink { get; set; }
        public bool isActive { get; set; }
        public bool cameraSupportsOnvif { get; set; }
        public bool isAiCamera { get; set; }
        public bool enableAutomaticRecording { get; set; }
        public int numberOfChannels { get; set; }
        public int portNumber { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationtime { get; set; }

    }
    public class Post_Cameras
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b", ErrorMessage = "4052")] // IP Address Regular Expression
        public string camera_ip { get; set; }
        [Required(ErrorMessage = "3001")]
        public string cameraImage { get; set; }
        [Required(ErrorMessage = "3001")]
        public int fps { get; set; }
        [Required(ErrorMessage = "3001")]
        public string user_name { get; set; }
        [Required(ErrorMessage = "3001")]
        public string password { get; set; }
        public int channelsNumber { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool enableAutomaticRecording { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool supportOnVif { get; set; }
        [Required(ErrorMessage = "3001")]
        public int portNumber { get; set; }
        [Required(ErrorMessage = "3001")]
        public string cameraName { get; set; }

        [Required(ErrorMessage = "3001")]
        public string lat { get; set; }
        [Required(ErrorMessage = "3001")]
        public string lng { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isAiCamera { get; set; }

    }
    public class Edit_Camera
    {
        [Required(ErrorMessage = "3001")]
        public int Id { get; set; }
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b", ErrorMessage = "4052")] // IP Address Regular Expression
        public string camera_ip { get; set; }
        public string cameraImage { get; set; }
        [Required(ErrorMessage = "3001")]
        public int fps { get; set; }
        [Required(ErrorMessage = "3001")]
        public string user_name { get; set; }
        [Required(ErrorMessage = "3001")]
        public string password { get; set; }
        public int channelsNumber { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool enableAutomaticRecording { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool supportOnVif { get; set; }
        [Required(ErrorMessage = "3001")]
        public int portNumber { get; set; }
        [Required(ErrorMessage = "3001")]
        public string cameraName { get; set; }

        [Required(ErrorMessage = "3001")]
        public string lat { get; set; }
        [Required(ErrorMessage = "3001")]
        public string lng { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isAiCamera { get; set; }
    }
    public class Cameras_Preques
    {
        public List<RelatedUsersOfLoggedUser> relatedUsers { get; set; }
    }
    public class Cameras_Reocrds_Preques
    {
        public List<camera> relatedCameras { get; set; }
    }
    public class camera
    {
        public int id { get; set; }
        public string cameraIp { get; set; }
        public string cameraName { get; set; }
        public string cameraImage { get; set; }
    }
    public class Get_Cameras_Records
    {
        public int id { get; set; }
        public int cameraId { get; set; }
        public string cameraIp { get; set; }
        public string cameraName { get; set; }
        public string cameraImage { get; set; }
        public string recordStartTime { get; set; }
        public string recordEndTime { get; set; }
        public string recordHttpUrl { get; set; }
        public string recordFtpUrl { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationtime { get; set; }

    }
    public class Get_Cameras_Stream_Preques
    {
        public int camerasCount { get; set; }
    }
    public class Get_Cameras_Stream
    {
        public int id { get; set; }
        public string cameraName { get; set; }
        public string cameraIp { get; set; }
        public bool isActive { get; set; }
        //public string httpCameraStreamUrl { get; set; }
        public string rtspLink { get; set; }

    }
    public class Get_Ftp_Credentials
    {
        public int id { get; set; }
        public string name { get; set; }
        public string ftpServerUrl { get; set; }
        public string httpServerUrl { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public double usedSpacePercentAlerting { get; set; }
        public bool firstInFirstDeletedMode { get; set; }
        public bool onlyAlertingMode { get; set; }
        public double ftpStorageInGiga { get; set; }
        public double realUsedSpacePercentAlerting { get; set; }
    }
    public class Post_Ftp_Credentials
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public string name { get; set; }
        [Required(ErrorMessage = "3001")]
        // [Url(ErrorMessage = "6052")]

        public string ftpServerUrl { get; set; }
        [Required(ErrorMessage = "3001")]
        // [Url(ErrorMessage ="6051")]
        public string httpServerUrl { get; set; }
        [Required(ErrorMessage = "3001")]
        public string userName { get; set; }
        [Required(ErrorMessage = "3001")]
        public string password { get; set; }
        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }

        [Required(ErrorMessage = "3001")]
        public bool firstInFirstDeletedMode { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool onlyAlertingMode { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "5777")]
        public double ftpStorageInGiga { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(1, 100, ErrorMessage = "5777")]
        public double usedSpacePercentAlerting { get; set; }
    }
    public class Edit_Ftp_Credentials : Post_Ftp_Credentials
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
    }
    public class Get_Cameras_Registered_Users_Preques
    {
        public int cameraId { get; set; }
        public string cameraIp { get; set; }
        public string cameraName { get; set; }
        public string cameraImage { get; set; }

    }
    public class Get_Camera_History_Preques
    {
        public List<Get_Cameras_Registered_Users_Preques> cameras { get; set; }
        public List<Get_Candiadates_Preques> registeredUsers { get; set; }
        public List<AreassPreques> areas { get; set; }
    }
    public class Get_Real_Time_Preques
    {
        public List<Get_Cameras_Registered_Users_Preques> cameras { get; set; }
        public List<Get_Employees_Preques> persons { get; set; }
        public List<AreassPreques> areas { get; set; }
    }
    public class Get_Employees_Preques
    {
        public int personId { get; set; }
        public string personName { get; set; }
        public string personImage { get; set; }
    }
    public class Get_Employees_Real_Time
    {
        public int id { get; set; }
        public int personId { get; set; }
        public string personName { get; set; }
        public string personImage { get; set; }
        public int areaId { get; set; }
        public string areaName { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
        public int cameraId { get; set; }
        public string cameraIp { get; set; }
        public string cameraRtsp { get; set; }
        public string cameraName { get; set; }
        public string cameraImage { get; set; }

        public double lat { get; set; }
        public double lng { get; set; }
        public string lastSeenTime { get; set; }

    }
    public class Get_Candiadates_Preques
    {
        public string candidateId { get; set; }
        public string candidateName { get; set; }
        public string candidateImage { get; set; }
    }
    public class Get_Cameras_Registered_Users
    {
        public int id { get; set; }
        public string candidateName { get; set; }
        public string candidateImage { get; set; }
        public string candidateSex { get; set; }
        public string candidateDateOfBirth { get; set; }
        public string candidateSmililarityPercent { get; set; }
        public List<CandidatesLocations> candidateLocations { get; set; }

    }
    public class Get_All_Cameras_Registered_Users
    {
        public int id { get; set; }
        public string candidateName { get; set; }
        public string candidateImage { get; set; }
        public string candidateSex { get; set; }
        public string candidateDateOfBirth { get; set; }
        public string candidateSmililarityPercent { get; set; }
        public string candidateId { get; set; }
        public string candidateCategory { get; set; }
        public List<CandidatesLocationsAll> candidateLocations { get; set; }
    }
    public class CandidatesLocations
    {
        public int areaId { get; set; }
        public string areaName { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
        public int cameraId { get; set; }
        public string cameraIp { get; set; }
        public string cameraName { get; set; }
        public string cameraImage { get; set; }

        public double lat { get; set; }
        public double lng { get; set; }
        public string creationTime { get; set; }
        public bool doorStatus { get; set; }
    }
    public class CandidatesLocationsAll : CandidatesLocations
    {
        public bool isAccessDevice { get; set; }
    }
    public class Get_Access_Strangers
    {
        public int id { get; set; }
        public int areaId { get; set; }
        public string areaName { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
        public int cameraId { get; set; }
        public string cameraIp { get; set; }
        public string cameraName { get; set; }
        public string cameraImage { get; set; }
        public bool dooorStatus { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string strangerSex { get; set; }
        public string strangerAge { get; set; }
        public string strangerImage { get; set; }

        public string creationTime { get; set; }
        public string starngerSkinColor { get; set; }
        public string starngerEye { get; set; }
        public string starngerMouth { get; set; }
        public string starngerMask { get; set; }

        public string starngerBeard { get; set; }
        public string starngerFaceQuality { get; set; }

    }
    public class Get_All_Strangers : Get_Access_Strangers
    {

        public bool isAccessDevice { get; set; }
    }

    public class Get_Roles_Of_Sensors
    {
        public int id { get; set; }
        public string roleName { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationTime { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public double alertableValue { get; set; }
        public double actionedValue { get; set; }
    }
    public class Get_Sensors_Analytics
    {
        public int id { get; set; }
        public int areaId { get; set; }
        public string areaName { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
        public int gatewayId { get; set; }
        public string gatewayIp { get; set; }
        public int machineId { get; set; }
        public string machineName { get; set; }
        public int sensorId { get; set; }
        public string sensorName { get; set; }
        public string sensorImage { get; set; }
        public double value { get; set; }
        public char greaterThanOrLessThan { get; set; }
        public string creationTime { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public bool isAlertable { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }
    public class Post_Roles_Of_Sensor
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        // [Url(ErrorMessage = "6052")]

        public string roleName { get; set; }

        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }

        [Required(ErrorMessage = "3001")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "5778")]
        public double alertableValue { get; set; }
        [Required(ErrorMessage = "3001")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "5778")]
        public double actionedValue { get; set; }
    }
    public class Edit_Roles_Of_Sensor : Post_Roles_Of_Sensor
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
    }
    public class GetSensorsPreques
    {
        public List<RolesPreques> roles { get; set; }
        public List<RelatedUsersOfLoggedUser> relatedUsers { get; set; }
        public List<AreassPreques> areas { get; set; }

        public List<GatewaysPreques> gateways { get; set; }


    }
    public class GetSensorsAnalyticsPreques
    {
        public List<GetSensorPreques> sensors { get; set; }
        public List<AreassPreques> areas { get; set; }
        public List<GatewaysPreques> gateways { get; set; }
    }
    public class GetSensorPreques
    {
        public int sensorId { get; set; }
        public string sensorName { get; set; }
        public string sensorImage { get; set; }

    }
    public class AreassPreques
    {
        public int areaId { get; set; }
        public string areaName { get; set; }
        public List<FloorsPreques> areaFloors { get; set; }
    }
    public class GatewaysPreques
    {
        public int gatewayId { get; set; }
        public string gatewayName { get; set; }
        public string gatewayIp { get; set; }
        public string gatewayImage { get; set; }
        public List<MachinesPreques> gatewayMachines { get; set; }
    }
    public class GatewaysMachinePreques
    {
        public int gatewayId { get; set; }
        public string gatewayName { get; set; }
        public string gatewayImage { get; set; }
    }
    public class MachinesPreques
    {
        public int machineId { get; set; }
        public string machineName { get; set; }
        public string machineImage { get; set; }
    }
    public class FloorsPreques
    {
        public int floorId { get; set; }
        public string floorName { get; set; }
    }
    public class RolesPreques
    {
        public int roleId { get; set; }
        public string roleName { get; set; }
        public double alertableValue { get; set; }
        public double actionedValue { get; set; }
    }
    public class SensorRoles
    {
        public int sensorRoleId { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public double alertableValue { get; set; }
        public double actionedValue { get; set; }
    }
    public class Get_Sensors
    {
        public int id { get; set; }
        public string sensorName { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationTime { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public string sensorImage { get; set; }
        public string sensormacAddress { get; set; }
        public int areaId { get; set; }
        public string areaName { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
        public int gatwayId { get; set; }
        public string gatewayName { get; set; }
        public int machineId { get; set; }
        public string machineName { get; set; }
        public List<SensorRoles> sensorRoles { get; set; }
    }
    public class Post_Sensor
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public string sensorName { get; set; }
        [Required(ErrorMessage = "3001")]
        public int areaId { get; set; }
        [Required(ErrorMessage = "3001")]
        public int floorId { get; set; }
        [Required(ErrorMessage = "3001")]
        public double sensorLatitude { get; set; }
        [Required(ErrorMessage = "3001")]
        public double sensorLongitude { get; set; }
        [Required(ErrorMessage = "3001")]
        public int machineId { get; set; }
        [Required(ErrorMessage = "3001")]
        public int gatwayId { get; set; }

        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        public List<int> roles { get; set; }
        public string sensormacAddress { get; set; }
        public string sensorImage { get; set; }


    }
    public class Edit_Sensor
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
        [Required(ErrorMessage = "3001")]
        public string sensorName { get; set; }
        public int areaId { get; set; }
        [Required(ErrorMessage = "3001")]
        public int floorId { get; set; }
        [Required(ErrorMessage = "3001")]
        public double sensorLatitude { get; set; }
        [Required(ErrorMessage = "3001")]
        public double sensorLongitude { get; set; }
        [Required(ErrorMessage = "3001")]
        public int machineId { get; set; }
        [Required(ErrorMessage = "3001")]
        public int gatwayId { get; set; }

        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        public List<EditSensorRoles> roles { get; set; }
        public string sensormacAddress { get; set; }

        public string sensorImage { get; set; }
    }
    public class EditSensorRoles
    {
        public int sensorRoleId { get; set; }
        public int roleId { get; set; }
    }

    public class GetMachinesPreques
    {
        public List<RelatedUsersOfLoggedUser> relatedUsers { get; set; }
        public List<AreassPreques> areas { get; set; }
        public List<GatewaysMachinePreques> gateways { get; set; }

    }
    public class SensorsMachine
    {
        public int sensorId { get; set; }
        public string sensorName { get; set; }
        public string sensorImage { get; set; }
    }
    public class Get_Machines
    {
        public int id { get; set; }
        public string machineName { get; set; }
        public string machineImage { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationTime { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public int areaId { get; set; }
        public string areaName { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
        public int gatwayId { get; set; }
        public string gatewayName { get; set; }
        public List<SensorsMachine> sensors { get; set; }
    }
    public class Post_Machine
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public string machineName { get; set; }
        [Required(ErrorMessage = "3001")]
        public int areaId { get; set; }
        [Required(ErrorMessage = "3001")]
        public int floorId { get; set; }
        [Required(ErrorMessage = "3001")]
        public double machineLatitude { get; set; }
        [Required(ErrorMessage = "3001")]
        public double machineLongitude { get; set; }
        [Required(ErrorMessage = "3001")]
        public int gatwayId { get; set; }

        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        public string machineImage { get; set; }


    }
    public class Edit_Machine : Post_Machine
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
    }

    public class GetVisitsPreques
    {
        public List<RelatedUsersOfLoggedUser> relatedUsers { get; set; }
        public List<GetEmployeePreques> employees { get; set; }
    }
    public class GetEmployeePreques
    {
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public string employeeImage { get; set; }
    }
    public class Get_Visits
    {
        public int id { get; set; }
        public string visitPurpose { get; set; }
        public string visitStarts { get; set; }
        public string visitEnds { get; set; }
        public string visitCode { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationTime { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public bool isAttended { get; set; }
        public bool isApproved { get; set; }
        public string visitCheckOut { get; set; }
        public Get_Visitor visitorData { get; set; }
    }
    public class Get_Visitor
    {
        public int id { get; set; }
        public string visitorName { get; set; }
        public string visitorNationalId { get; set; }
        public string visitorPhone { get; set; }
        public string visitorImage { get; set; }
        public string visitorIdImage { get; set; }
        public string visitorEmail { get; set; }
    }

    public class Post_Visit
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public string visitPurpose { get; set; }
        [Required(ErrorMessage = "3001")]
        public int employeeId { get; set; }
        [Required(ErrorMessage = "3001")]
        public DateTime visitStarts { get; set; }
        [Required(ErrorMessage = "3001")]
        public DateTime visitEnds { get; set; }
        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isAttended { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isApproved { get; set; }
        [Required(ErrorMessage = "3001")]

        public Post_Visitor visitorData { get; set; }

    }
    public class Post_Visitor
    {
        [Required(ErrorMessage = "3001")]
        public string visitorName { get; set; }
        [Required(ErrorMessage = "3001")]
        public string visitorPhone { get; set; }
        [Required(ErrorMessage = "3001")]
        public string visitorNationalId { get; set; }
        [Required(ErrorMessage = "3001")]
        public string visitorIdImage;
        [Required(ErrorMessage = "3001")]
        public string visitorImage { get; set; }
        [Required(ErrorMessage = "3001")]
        public string visitorEmail { get; set; }
    }
    public class Edit_Visitor : Post_Visitor
    {
        [Required(ErrorMessage = "3001")]
        public int visitorId { get; set; }
    }
    public class Edit_Visit
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }

        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
        [Required(ErrorMessage = "3001")]
        public string visitPurpose { get; set; }
        [Required(ErrorMessage = "3001")]
        public int employeeId { get; set; }
        [Required(ErrorMessage = "3001")]
        public DateTime visitStarts { get; set; }
        [Required(ErrorMessage = "3001")]
        public DateTime visitEnds { get; set; }
        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isAttended { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool isApproved { get; set; }
        [Required(ErrorMessage = "3001")]
        public Edit_Visitor visitorData { get; set; }

    }
    public class Get_mail_server_config
    {

        public int id { get; set; }
        public string mailServer { get; set; }
        public string senderMail { get; set; }
        public string senderMailPassword { get; set; }
        public int portNumber { get; set; }
        public bool enableSsl { get; set; }
        public string mailSubject { get; set; }
        public string mailBody { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationTime { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
    }
    public class Post_mail_server_config
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "3001")]
        public string mailServer { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "3001")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string senderMail { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "3001")]
        public string senderMailPassword { get; set; }
        [Required(ErrorMessage = "3001")]
        public int portNumber { get; set; }
        [Required(ErrorMessage = "3001")]
        public bool enableSsl { get; set; }
        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        public string mailSubject { get; set; }

        [Required(ErrorMessage = "3001")]
        public string mailBody { get; set; }
    }
    public class Edit_mail_server_config : Post_mail_server_config
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
    }
    public class Get_Visitor_Mail_Object
    {
        public string visitorName { get; set; }
        public string visitorMail { get; set; }
        public string employeeName { get; set; }
        public string visitStarts { get; set; }
        public string visitEnds { get; set; }
        public string visitCode { get; set; }
        public string barcodeImageUrl { get; set; }
    }

    public class Get_Acc_Dashboard_Preques
    {
        public List<string> dashboardAppenexes { get; set; }
        public List<string> devicesTypes { get; set; }
        public List<GetEmployeePreques> employees { get; set; }
        public List<AreassPreques> areas { get; set; }
        public List<Get_Acc_Dashboard_Devices_Preques> devices { get; set; }
        public List<Get_Acc_Dashboard_Sensors_Preques> sensors { get; set; }
        public List<Get_Acc_Dashboard_Events_Preques> events { get; set; }
        public List<Get_Acc_Dashboard_Integrations_Preques> integrations { get; set; }

    }
    public class Get_Acc_Dashboard_Integrations_Preques
    {
        public int integrationId { get; set; }
        public string integrationName { get; set; }
    }
    public class Get_Acc_Dashboard_Sensors_Preques
    {
        public int sensorId { get; set; }
        public string sensorName { get; set; }
    }
    public class Get_Acc_Dashboard_Events_Preques
    {
        public int eventId { get; set; }
        public string eventName { get; set; }
    }
    public class Get_Acc_Dashboard_Devices_Preques
    {
        public int deviceId { get; set; }
        public string deviceName { get; set; }
        public string deviceIp { get; set; }
        public string deviceType { get; set; }
    }
    public class DashboardFilters : LoginGetRequest
    {
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
        public string appendex { get; set; }
        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }
        public string deviceType { get; set; }
        public int? floorId { get; set; }
        public int? areaId { get; set; }
        public int? employeeId { get; set; }
        public int? deviceId { get; set; }
        public int? sensorId { get; set; }
        public int? eventId { get; set; }
        public int? integrationId { get; set; }
    }
    public class Get_Acc_Dashboard
    {
        public Get_Acc_Dashboard_Devices devicesData { get; set; }
        public Get_Acc_Dashboard_Areas areasData { get; set; }
        public Get_Acc_Dashboard_Floors floorsData { get; set; }
        public Get_Acc_Dashboard_Employees employeesData { get; set; }
        public Get_Acc_Dashboard_Visits visitsData { get; set; }
        public Get_Acc_Dashboard_Strangers strangersData { get; set; }
        public Get_Acc_Dashboard_Sensors sensorsData { get; set; }
        public Get_Acc_Dashboard_Integrations integrationsData { get; set; }
        public Get_Acc_Dashboard_Events eventsData { get; set; }
        public Get_Acc_Dashboard_Heat_Map heatmapData { get; set; }
        public List<Get_Acc_Dashboard_Sensors_Graph> sensorsGraphData { get; set; }
    }

    public class Get_Acc_Dashboard_Devices
    {
        public int totalDevicesNumber { get; set; }
        public int offlineDeveices { get; set; }
        public int onlineDeveices { get; set; }
        public List<Get_Acc_Dashboard_Devices_Data> devicesData { get; set; }
    }
    public class Get_Acc_Dashboard_Devices_Data
    {
        public int deviceId { get; set; }
        public string deviceName { get; set; }
        public string deviceIp { get; set; }
        public string deviceImage { get; set; }
        public string deviceType { get; set; }
        public bool deviceStatus { get; set; }

    }
    public class Get_Acc_Dashboard_Devices_Data_Without_Ids
    {
        public string deviceName { get; set; }
        public string deviceIp { get; set; }
        public string deviceImage { get; set; }
        public string deviceType { get; set; }
        public bool deviceStatus { get; set; }

    }
    public class Get_Acc_Dashboard_Areas
    {
        public int totalAreasNumber { get; set; }
        public List<Get_Acc_Dashboard_Areas_Data> areasList { get; set; }
    }
    public class Get_Acc_Dashboard_Areas_Data
    {
        public int areaId { get; set; }
        public string areaName { get; set; }
    }
    public class Get_Acc_Dashboard_Floors
    {
        public int totalFloorsNumber { get; set; }
        public List<Get_Acc_Dashboard_Floors_Data> floorsData { get; set; }
    }
    public class Get_Acc_Dashboard_Floors_Data
    {
        public int floorId { get; set; }
        public string floorName { get; set; }
        public int areaId { get; set; }
        public string areaName { get; set; }
    }
    public class Get_Acc_Dashboard_Employees
    {
        public int totalEmployeesNumber { get; set; }
        public int checkedInEmployeesNumber { get; set; }
        public int absentEmployeesNumber { get; set; }
        public List<Get_Acc_Dashboard_Employees_Data> employeesList { get; set; }
    }
    public class Get_Acc_Dashboard_Employees_Data
    {
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public string employeeImage { get; set; }
        public bool isCheckedIn { get; set; }
    }
    public class Get_Acc_Dashboard_Employees_Data_Without_Ids
    {
        public string employeeName { get; set; }
        public string employeeImage { get; set; }
        public bool isCheckedIn { get; set; }
    }
    public class Get_Acc_Dashboard_People_Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }
    public class Get_Acc_Dashboard_People_Data_Without_Ids
    {
        public string name { get; set; }
        public string image { get; set; }
    }
    public class Get_Acc_Dashboard_Visits_Data
    {
        public int VisitId { get; set; }
        public string visitPurpose { get; set; }
        public string visitStarts { get; set; }
        public string visitEnds { get; set; }
        public string visitCode { get; set; }
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public bool isAttended { get; set; }
        public bool isApproved { get; set; }
        public string visitCheckOut { get; set; }
        public int visitorId { get; set; }
        public string visitorName { get; set; }
        public string visitorImage { get; set; }
    }
    public class Get_Acc_Dashboard_Visits
    {
        public int totalVisitsNumber { get; set; }
        public int approvedVisitsNumber { get; set; }
        public int attendedVisitsNumber { get; set; }
        public List<Get_Acc_Dashboard_Visits_Data> visitList { get; set; }
    }
    public class Get_Acc_Dashboard_Strangers
    {
        public int totalStrangersNumber { get; set; }
        public List<Get_Acc_Dashboard_Strangers_Data> strangersList { get; set; }
    }
    public class Get_Acc_Dashboard_Strangers_Data
    {
        public int strangerId { get; set; }
        public int areaId { get; set; }
        public string areaName { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
        public int cameraId { get; set; }
        public string cameraIp { get; set; }
        public string cameraName { get; set; }
        public string cameraImage { get; set; }
        public bool dooorStatus { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string strangerImage { get; set; }
        public string creationTime { get; set; }
    }
    public class Get_Acc_Dashboard_Strangers_Data_WithoutIds
    {
        public string areaName { get; set; }
        public string floorName { get; set; }
        public string cameraIp { get; set; }
        public string cameraName { get; set; }
        public string cameraImage { get; set; }
        public bool dooorStatus { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string strangerImage { get; set; }
        public string creationTime { get; set; }
    }
    public class Get_Acc_Dashboard_Sensors
    {
        public int totalSensorsNumber { get; set; }
        public List<Get_Acc_Dashboard_Sensors_Data> sensorsList { get; set; }
    }
    public class Get_Acc_Dashboard_Sensors_Data
    {
        public int areaId { get; set; }
        public string areaName { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
        public int sensorId { get; set; }
        public string sensorName { get; set; }
        public string normalVlaue { get; set; }
        public string currentVlaue { get; set; }
        public string sensorMaxValue { get; set; }
        public string sensorMinValue { get; set; }
        public string sensorMaxValueAlert { get; set; }
        public string sensorMinValueAlert { get; set; }
        public string criticalSensorMaxValue { get; set; }
        public string criticalSensorMinValue { get; set; }
        public string criticalSensorMaxValueAlert { get; set; }
        public string criticalSensorMinValueAlert { get; set; }
        public string lastUpdateTime { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public double minimumValue { get; set; }
        public double maximumValue { get; set; }
    }
    public class Get_Acc_Dashboard_Sensors_Data_Without_Ids
    {
        public string areaName { get; set; }
        public string floorName { get; set; }
        public string sensorName { get; set; }
        public int keyId { get; set; }
        public string keyName { get; set; }
        public string normalValue { get; set; }
        public string currentValue { get; set; }
        public string sensorMaxValue { get; set; }
        public string sensorMinValue { get; set; }
        public string sensorMaxValueAlert { get; set; }
        public string sensorMinValueAlert { get; set; }
        public string criticalSensorMaxValue { get; set; }
        public string criticalSensorMinValue { get; set; }
        public string criticalSensorMaxValueAlert { get; set; }
        public string criticalSensorMinValueAlert { get; set; }
        public string lastUpdateTime { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public double minimumValue { get; set; }
        public double maximumValue { get; set; }
    }
    public class Get_Acc_Dashboard_Integrations
    {
        public int totalIntegrationsNumber { get; set; }
        public List<Get_Acc_Dashboard_Integrations_Data> integrationsList { get; set; }
    }
    public class Get_Acc_Dashboard_Integrations_Data
    {
        public int integrationId { get; set; }
        public string integrationName { get; set; }
        public bool isIntegrationEnabled { get; set; }
    }
    public class Get_Acc_Dashboard_Integrations_Data_Without_Ids
    {
        public string integrationName { get; set; }
        public bool isIntegrationEnabled { get; set; }
    }
    public class Get_Acc_Dashboard_Events
    {
        public int totalEventsNumber { get; set; }
        public List<Get_Acc_Dashboard_Events_Data> eventsList { get; set; }
    }
    public class Get_Acc_Dashboard_Events_Data
    {
        public int eventId { get; set; }
        public string eventName { get; set; }
        public string eventType { get; set; }
        public string operate { get; set; }
        public string value { get; set; }
        public bool isAlertable { get; set; }
        public int sensorId { get; set; }
        public string sensorName { get; set; }
        public int integrationId { get; set; }
        public string integrationName { get; set; }
        public int gatewayId { get; set; }
        public string gatewayName { get; set; }

    }
    public class Get_Acc_Dashboard_Events_Data_Without_Ids
    {
        public string eventName { get; set; }
        public string eventType { get; set; }
        public string operate { get; set; }
        public string value { get; set; }
        public bool isAlertable { get; set; }
        public string sensorName { get; set; }
        public string integrationName { get; set; }
        public string gatewayName { get; set; }

    }
    public class Get_Acc_Dashboard_Heat_Map
    {
        public List<Get_Acc_Dashboard_Heat_Map_Data> heatMapPointsList { get; set; }
    }
    public class Get_Acc_Dashboard_Heat_Map_Data
    {
        public int candidateId { get; set; }
        public string candidateName { get; set; }
        public string candidateCategory { get; set; }
        public string candidateImage { get; set; }
        public List<Get_Acc_Dashboard_Heat_Map_Data_Locations> locations { get; set; }

    }
    public class Get_Acc_Dashboard_Heat_Map_Data_Locations
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
    public class Get_Acc_Dashboard_Sensors_Graph
    {
        public int sensorId { get; set; }
        public string sensorName { get; set; }
        public List<Get_Acc_Dashboard_Sensors_Graph_Data> sensorReadings { get; set; }
    }
    public class Get_Acc_Dashboard_Sensors_Graph_Data
    {
        public string date { get; set; }
        public string value { get; set; }
        public bool isAlertable { get; set; }
    }
    public class Get_Devices_Report
    {
        public int id { get; set; } //1
        public string deviceIp { get; set; } //2
        public string deviceName { get; set; }   //3
        public string deviceImage { get; set; }   //4
        public string deviceType { get; set; }   //5
        public int areaId { get; set; }  //6
        public string areaName { get; set; } //7
        public int floorId { get; set; } //8
        public string floorName { get; set; } //9
        public string lat { get; set; } //10
        public string lng { get; set; } //11
        public int framePerSecond { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string rtspLink { get; set; }
        public bool deviceStatus { get; set; }
        public bool cameraSupportsOnvif { get; set; }
        public bool isAiDevice { get; set; }
        public bool enableAutomaticRecording { get; set; }
        public int numberOfChannels { get; set; }
        public int portNumber { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationtime { get; set; }
    }
    public class Get_Dynamic_Dashboards_Preques_Data
    {
        public int dashboardId { get; set; }
        public string dashboardName { get; set; }
        public string dashboardIndex { get; set; }
    }
    public class Get_Dynamic_Dashboard_Creation_Preques
    {
        public List<AreasDynamicDashboardPreques> areas { get; set; }
        public List<FloorsDynamicDashboardPreques> floors { get; set; }
        public List<AreasSubAreasPerques> areasFloors { get; set; }
        public List<SenssDynamicDashboardPreques> sensors { get; set; }
        public List<RelatedUsersOfLoggedUser> relatedUsers { get; set; }
        public List<ContentTypesData> contentTypesData { get; set; }
        public List<Get_Dynamic_Dashboards_Preques_Data> dashboards { get; set; }
        //public List<string> contentTypes { get;  set; }
        //public List<string> contentData { get;  set; }
    }
    public class AreasSubAreasPerques
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
    public class ContentTypesData
    {
        public string contentType { get; set; }
        public List<string> contentData { get; set; }
    }
    public class SenssDynamicDashboardPreques
    {
        public int sensorId { get; set; }
        public string sensorName { get; set; }
        public List<SensorKeys> sensorKeys { get; set; }
    }
    public class SensorKeys
    {
        public int keyId { get; set; }
        public string keyName { get; set; }
    }
    public class AreasDynamicDashboardPreques
    {
        public int areaId { get; set; }
        public string areaName { get; set; }
    }
    public class NewAreasDynamicDashboardPreques
    {
        public int areaId { get; set; }
        public string areaName { get; set; }
        public List<FloorsDynamicDashboardPreques> floors { get; set; }
    }
    public class FloorsDynamicDashboardPreques
    {
        public int areaId { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
    }
    public class Post_Dynamic_Dashboard
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public string dashBoardName { get; set; }
        [Required(ErrorMessage = "3001")]
        public string dashBoardIndex { get; set; }
        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "3001")]
        public List<Post_Dynamic_Dashboard_Content> dashboardContentsData { get; set; }
    }
    public class Post_Dynamic_Dashboard_Without_Elements
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public string dashBoardName { get; set; }
        [Required(ErrorMessage = "3001")]
        public string dashBoardIndex { get; set; }
        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
      
    }
    public class Post_Dynamic_Dashboard_Content
    {
        [Required(ErrorMessage = "3001")]
        public string contentName { get; set; }
        [Required(ErrorMessage = "3001")]
        public int areaId { get; set; }
        [Required(ErrorMessage = "3001")]
        public int floorId { get; set; }
        [Required(ErrorMessage = "3001")]
        public int sensorId { get; set; }
        [Required(ErrorMessage = "3001")]
        public int keyId { get; set; }
        [Required(ErrorMessage = "3001")]
        public string index { get; set; }
        [Required(ErrorMessage = "3001")]
        public string elementType { get; set; }
        [Required(ErrorMessage = "3001")]
        public string elementData { get;  set; }

    }
    public class Edit_Dynamic_Dashboard_Without_Elements
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
        [Required(ErrorMessage = "3001")]
        public string dashBoardName { get; set; }
        [Required(ErrorMessage = "3001")]
        public string dashBoardIndex { get; set; }
        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }
    }
        public class Edit_Dynamic_Dashboard
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
        [Required(ErrorMessage = "3001")]
        public string dashBoardName { get; set; }
        [Required(ErrorMessage = "3001")]
        public string dashBoardIndex { get; set; }
        [Required(ErrorMessage = "3001")]
        public int parentId { get; set; }

        [Required(ErrorMessage = "3001")]
        public List<Edit_Dynamic_Dashboard_Content> dashboardContentsData { get; set; }
    }
    public class Edit_Dynamic_Dashboard_Content : Post_Dynamic_Dashboard_Content
    {
        [Required(ErrorMessage = "3001")]
        public int id { get; set; }
    }
    public class Get_Dynamic_Dashboards
    {
        public int id { get; set; }
        public string dashBoardName { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public string dashboardIndex { get; set; }
        public List<Get_Dynamic_Dashboard_Elements> dashboardElements { get; set; }
    }
    public class Get_Dynamic_Dashboard_Elements
    {
        public int elementId { get; set; }
        public string elementName { get; set; }
        public string elementType { get; set; }
        public string elementData { get; set; }
        public int areaId { get; set; }
        public string areaName { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
        public int sensorId { get; set; }
        public string sensorName { get; set; }

        public int keyId { get; set; }
        public string keyName { get; set; }

        public string index { get; set; }
        public Chart chart { get; set; }
        public List<string> tableHeaders { get; set; }
        public List<dynamic> data { get; set; }
    }
    public class Get_Dynamic_Dashboard_Elements_Alone
    {
        public int elementId { get; set; }
        public string elementName { get; set; }
        public string elementType { get; set; }
        public string elementData { get; set; }
        public int areaId { get; set; }
        public string areaName { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }
        public int sensorId { get; set; }
        public string sensorName { get; set; }
        public int keyId { get; set; }
        public string keyName { get; set; }
        public string index { get; set; }
        public Chart chart { get; set; }
        public List<string> tableHeaders { get; set; }
        public List<dynamic> data { get; set; }
    }
    public class ChartDataAlone
    {
        public string label { get; set; }
        public string value { get; set; }
        public List<string> tableHeaders { get; set; }
        public List<dynamic> clickableData { get; set; }
    }
    public class ChartData
    {
    //    public string key { get; set; }
        public string label { get; set; }
        public string value { get; set; }

    }
    public class Chart
    {
        public string caption { get; set; }
        public string plottooltext { get; set; }
        public string showLegend { get; set; }
        public string showPercentValues { get; set; }
        public string legendPosition { get; set; }
        public string useDataPlotColorForLabels { get; set; }
        public string enablemultislicing { get; set; }
        public string showlegend { get; set; }
        public string theme { get; set; }
    }
    public class Add_Dynamic_Dashboard_Element
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int dashboardId { get; set; }
        [Required(ErrorMessage = "3001")]
        public string contentName { get; set; }
        [Required(ErrorMessage = "3001")]
        public int areaId { get; set; }
        [Required(ErrorMessage = "3001")]
        public int floorId { get; set; }
        [Required(ErrorMessage = "3001")]
        public int sensorId { get; set; }
        public int keyId { get; set; }
        [Required(ErrorMessage = "3001")]
        public string index { get; set; }
        [Required(ErrorMessage = "3001")]
        public string elementType { get; set; }
        [Required(ErrorMessage = "3001")]
        public string elementData { get; set; }
    }
    public class Edit_Dynamic_Dashboard_Element : Add_Dynamic_Dashboard_Element
    {
        public int elementId { get; set; }
        public string areaName { get; set; }
        public string floorName { get; set; }
        public string sensorName { get; set; }
    }
    public class Sensors_Mesurements
    {
        public double normalValue { get; set; }
        public string sensorId { get; set; }
    }

    public class Get_Gateways_Sensors_Report
    {
        public int id { get; set; } //1
        public string deviceIp { get; set; } //2
        public string deviceName { get; set; }   //3
        public string deviceImage { get; set; }   //4
        public int areaId { get; set; }  //6
        public string areaName { get; set; } //7
        public int floorId { get; set; } //8
        public string floorName { get; set; } //9
        public string lat { get; set; } //10
        public string lng { get; set; } //11
        public string userName { get; set; }
        public string password { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationtime { get; set; }
        public bool deviceStatus { get; set; }
    }
    public class Get_Gateway_Sensors
    {
        public int id { get; set; }
        public string sensorName { get; set; }
        public string sensorImage { get; set; }
        public string sensorCurrentValue { get; set; }
        public string sensorMaxValue { get; set; }
        public string sensorMinValue { get; set; }
        public string sensorMaxValueAlert { get; set; }
        public string sensorMinValueAlert { get; set; }
        public string criticalSensorMaxValue { get; set; }
        public string criticalSensorMinValue { get; set; }
        public string criticalSensorMaxValueAlert { get; set; }
        public string criticalSensorMinValueAlert { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationTime { get; set; }
        public string recordsCount { get;  set; }
        public string sensorMaxValueSensorReading { get; set; }
        public string sensorMinValueSensorReading { get; set; }
        public string sensorAvgValueSensorReading { get;  set; }
        public int numberOfReadings { get; set; }
    }
 
    public class sensor_analytics_ado_classic
    {
        public string maxValue { get; set; }
        public string minValue { get; set; }
        public string avgValue { get; set; }
        public string numberOfRecords { get; set; }
    }
    public class sensor_analysis_ado_classic
    {
        public int id { get; set; }
        public int sensorId { get; set; }
        public int keyId { get; set; }
        public double sensorValue { get; set; }
        public DateTime from { get; set; }
        public DateTime? to { get; set; }
    }
    public class Get_Sensor_Analysis 
    {
        public int id { get; set; }
        public string sensorName { get; set; }
        public string sensorImage { get; set; }
        public string sensorCurrentValue { get; set; }
        public string sensorMaxValue { get; set; }
        public string sensorMinValue { get; set; }
        public string sensorMaxValueAlert { get; set; }
        public string sensorMinValueAlert { get; set; }
        public string criticalSensorMaxValue { get; set; }
        public string criticalSensorMinValue { get; set; }
        public string criticalSensorMaxValueAlert { get; set; }
        public string criticalSensorMinValueAlert { get; set; }
        public int parentId { get; set; }
        public string parentName { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public string creationTime { get; set; }
        public List<Sensor_Analysis> sensor_readings { get; set; }
    }
    public class Sensor_Analysis
    {
        public double sensorValue { get; set; }
        public string from { get; set; }
        public string to { get; set; }
    }
    public class Get_Gateway_Sensors_Keys : Get_Gateway_Sensors
    {
        public int keyId { get; set; }
        public string keyName { get; set; }
    }
    public class Get_Sensor_Analysis_Keys: Get_Sensor_Analysis
    {
        public int keyId { get; set; }
        public string keyName { get; set; }
    }
    public class Post_Collect_Data_Request
    {
        [Required(ErrorMessage = "3001")]
        public LoginRequest login { get; set; }
        [Required(ErrorMessage = "3001")]
        public int siteId { get; set; }

    }
}