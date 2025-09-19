namespace EndavaNaloga.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string? Description { get; set; }
        
        public Category()
        {
        }

        public Category(string name, string? description)
        {
            Name = name;
            Description = description;
        }

        public Category(Category category)
        {
            Id = category.Id;
            this.Name = category.Name;
            this.Description = category.Description;
        }
    }
}
