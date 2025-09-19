namespace EndavaNaloga.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        
        public Category()
        {
        }

        public Category(int id, string name, string? description)
        {
            Id = id;
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
