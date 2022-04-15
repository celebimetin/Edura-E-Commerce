namespace Edura.WebUI.Entity
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageName { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}