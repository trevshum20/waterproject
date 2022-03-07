﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WaterProject.Models
{
    public class Donation
    {
        [Key]
        [BindNever]  // will never be passed through the url or the form (for security)
        public int DonationId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage ="Please enter a name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line:")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state:")]
        public string State { get; set; }

        
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country:")]
        public string Country { get; set; }

        public bool Anonymous { get; set; }

        [BindNever]
        public bool DonationReceived { get; set; }



    }
}
