using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wedding_planner.Models;

namespace wedding_planner.Models
{
    public class RSVP
    {
        [Key] // the below prop is the primary key, [Key] is not needed if named with pattern: ModelNameId
        public int RSVPId { get; set; }

        [Required]
        public int WeddingId { get; set; }

        [Required]
        public int UserId { get; set; }

        public Wedding wedding { get; set; }

        public User guest { get; set; }
    }
}
