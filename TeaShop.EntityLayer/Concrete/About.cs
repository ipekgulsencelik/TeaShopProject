namespace TeaShop.EntityLayer.Concrete
{
    public class About
    {
        public int AboutID { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string? AboutImageURL { get; set; }
        public bool IsHome { get; set; }
        public bool IsFooter { get; set; }
        public bool AboutStatus { get; set; }
    }
}