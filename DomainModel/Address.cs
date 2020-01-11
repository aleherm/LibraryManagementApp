// <copyright file="Address.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Address entity.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1101", Justification = "In .NET this is rarely used.")]
    public class Address : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="city">The city name.</param>
        /// <param name="street">The street name.</param>
        /// <param name="number">The number of the house.</param>
        public Address(string city, string street, int? number)
        {
            City = city;
            Street = street;
            Number = number;
        }

        /// <summary>
        /// Gets or sets the ID of the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the City name.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.CityNameRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.CityRangeLength, MinimumLength = 5)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Street name.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.StreetNameRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.StreetLength, MinimumLength = 2)]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the Number of the house.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.HouseNumberRequired)]
        [Range(1, 5000, ErrorMessage = ErrorMessages.HouseNumberRange)]
        public int? Number { get; set; }

        /// <summary>
        /// Validates specific properties of the Address entity.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A validation result containing the errors and member names of the invalid properties.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Number.HasValue && Number <= 0)
            {
                yield return new ValidationResult(ErrorMessages.HouseNumberRequired, new List<string> { "Number" });
            }
        }

        /// <summary>
        /// Shows the data of the current entity.
        /// </summary>
        /// <returns>Output string for an Address entity.</returns>
        public override string ToString()
        {
            return $"{City} | str {Street} | nr {Number}";
        }
    }
}