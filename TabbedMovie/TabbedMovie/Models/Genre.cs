﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TabbedMovie.Models;

namespace TabbedMovie.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MinLength(3), MaxLength(100)]
        public string Name { get; set; }
        public Movie Movies { get; set; }
    }
}
