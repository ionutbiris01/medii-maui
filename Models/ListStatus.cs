using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Medii_maui.Models
{
    public class ListStatus
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Delivery))]
        public int DeliveryID { get; set; }
        public int StatusID { get; set; }
    }
}
