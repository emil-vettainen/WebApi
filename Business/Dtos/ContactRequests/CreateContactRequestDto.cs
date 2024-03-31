using System.ComponentModel.DataAnnotations;

namespace Business.Dtos.ContactRequestsDtos;

public class CreateContactRequestDto
{
    [Required]
    public string FullName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [RegularExpression(@"^(([^<>()\]\\.,;:\s@\""]+(\.[^<>()\]\\.,;:\s@\""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "The field Email must match xx@xx.xx")]
    public string Email { get; set; } = null!;

    public string? Service { get; set; }

    [Required]
    public string Message { get; set; } = null!;
}