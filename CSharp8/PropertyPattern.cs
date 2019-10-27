namespace CSharp8
{
    public class PropertyPattern
    {
        public class Address
        {
            public string State { get; set; }

            public string ZipCode { get; set; }
        }

        public static decimal GetTax(Address address) =>
            address switch
            {
                { State: "WA" } => 9M,
                { State: "MN" } => 10M,
                { ZipCode: "100" } => 12M,
                _ => 0M
            };
    }
}
