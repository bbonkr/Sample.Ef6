namespace Sample.Ef6.Entities
{
    public class Address
    {
        public Guid UserId { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string ZipCode { get; set; }
    }
}
