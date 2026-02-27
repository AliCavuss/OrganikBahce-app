namespace Admin.Mvc.Models.ViewModels
{
    public class CategoryEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public string? IconCssClass { get; set; }
    }
}
