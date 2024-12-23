﻿namespace CoreERP.Dtos
{
    public class CompanyDtos
    {
        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Gstnumber { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Website { get; set; }

        public decimal? Capital { get; set; }

        public decimal? Income { get; set; }
    }
}
