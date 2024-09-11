using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FM.Modles;
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        public string City { get; set; }

        [StringLength(6)]
        public string Pincode { get; set; }

        [Phone]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Phone]
        [StringLength(15)]
        public string MobileNumber { get; set; }

        public string CreditCardType { get; set; }

        [StringLength(16)]
        public string CreditCardNumber { get; set; }

        public string DrivingLicenseNumber { get; set; }

        public string IdpNumber { get; set; }

        public string IssuedByDL { get; set; }

        public DateTime? ValidThroughDL { get; set; }

        public string PassportNumber { get; set; }

        public DateTime? PassportValidThrough { get; set; }

        public string PassportIssuedBy { get; set; }

        public DateTime? PassportValidFrom { get; set; }

        public DateTime? PassportIssueDate { get; set; }

        public DateTime? DateOfBirth { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        // Default constructor

}
        // Constructor with fields (if needed)
       // public Customer(string firstName, string lastName, string addressLine1, string addressLine2, string email, string city, string pincode, string phoneNumber, string mobileNumber, string creditCardType, string creditCardNumber, string drivingLicenseNumber, string idpNumber, string issuedByDL, DateTime? validThroughDL, string passportNumber, DateTime? passportValidThrough, string passportIssuedBy,
