using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
