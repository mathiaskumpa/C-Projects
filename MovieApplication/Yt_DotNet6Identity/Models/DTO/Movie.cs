using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using MovieApp.Models.Domain;

namespace MovieApp.Models.DTO
{
    public class Movie
    {
        public long MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; } = 0.0;
        public DateTime ReleaseDate { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}
