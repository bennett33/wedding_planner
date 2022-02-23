using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wedding_planner.Models;

namespace wedding_planner.Models
{
    public class Wedding
    {
        [Key] // the below prop is the primary key, [Key] is not needed if named with pattern: ModelNameId
        public int WeddingId { get; set; }


        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Wedder One")]
        public string WedderOne { get; set; }


        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Wedder Two")]
        public string WedderTwo { get; set; }


        [Required(ErrorMessage = "is required")]
        [Display(Name = "Date")]
        public DateTime WeddingDate { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        public int UserId { get; set; }
        public User Creator { get; set; }
        public List<RSVP> GuestList { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
