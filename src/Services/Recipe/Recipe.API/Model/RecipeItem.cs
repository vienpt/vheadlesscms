using System;
using System.Collections.Generic;

namespace Recipe.API.Model
{
    public record RecipeItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Meal { get; set; }
        public string Img { get; set; }
        public int? Time { get; set; }
        public int? Rating { get; set; }
        public int? Order { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public RecipeTag Tags { get; set; } // recipe can have many tags
        public int TagId { get; set; }
        public RecipeAuthor Author { get; set; } // recipe has 1 author
        public int AuthorId { get; set; }
    }
}