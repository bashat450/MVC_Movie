using System.ComponentModel.DataAnnotations;

public class Customer
{
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Full Name is required.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Mobile Number is required.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile Number must be exactly 10 digits.")]
    public string MobileNumber { get; set; }
}
