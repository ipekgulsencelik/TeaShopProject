﻿namespace TeaShop.DTO.DTOs.ContactDTOs
{
    public class UpdateContactDTO
    {
        public int ContactID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool ContactStatus { get; set; }
    }
}