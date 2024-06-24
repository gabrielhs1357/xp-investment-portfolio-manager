﻿using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolioManager.Application.DTOs.Client
{
    public class CreateClientDto
    {
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public required string Email { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; }
    }
}
