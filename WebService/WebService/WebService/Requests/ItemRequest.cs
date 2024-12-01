namespace WebsServices.Requests
{
    public class ItemRequest
    {
        public String ?Code { get; set; }
        public String ?Name { get; set; }
        public String ?Description { get; set; }
        public String ?Measure { get; set; }
        public String ?Category { get; set; }
        public String ?Location { get; set; }
        public String ?Material { get; set; }
        public short ?Quantity { get; set; }

    }
}