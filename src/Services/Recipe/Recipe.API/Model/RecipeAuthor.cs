namespace Recipe.API.Model
{
    public record RecipeAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}