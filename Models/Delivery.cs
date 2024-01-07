using SQLite;

namespace Medii_maui.Models
{
    public class Delivery
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string? StartLocation { get; set; }

        public string? EndLocation { get; set; }

        public int PhoneNumber { get; set; }
    }
}
