namespace TeaShop.EntityLayer.Concrete
{
    public class Shop
    {
        public int ShopID { get; set; }
        public string ShopTitle { get; set; }
        public string ShopDescription { get; set; }
        public string ShopImageURL { get; set; }
        public bool IsHome { get; set; }
        public bool ShopStatus { get; set; }
    }
}