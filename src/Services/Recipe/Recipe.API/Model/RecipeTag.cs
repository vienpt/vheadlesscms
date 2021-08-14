namespace Recipe.API.Model
{
    public record RecipeTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}