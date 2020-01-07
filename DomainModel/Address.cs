using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Address : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.CityNameRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.CityRangeLength, MinimumLength = 5)]
        public string City { get; set; }

        [Required(ErrorMessage = ErrorMessages.StreetNameRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.StreetLength, MinimumLength = 2)]
        public string Street { get; set; }

        [Required(ErrorMessage = ErrorMessages.HouseNumberRequired)]
        [Range(1, 5000, ErrorMessage = ErrorMessages.HouseNumberRange)]
        public int? Number { get; set; }

        public Address()
        {

        }

        public Address(string city, string street, int? number)
        {
            City = city;
            Street = street;
            Number = number;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Number.HasValue && Number <= 0)
            {
                yield return new ValidationResult(ErrorMessages.HouseNumberRequired, new List<string> { "Number" });
            }
        }

        public override string ToString()
        {
            return $"{City} | str {Street} | nr {Number}";
        }
    }
}