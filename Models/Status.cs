using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Medii_maui.Models
{
    public class Status
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string StatusName { get; set; }
        [OneToMany]
        public List<ListStatus> ListStatuses { get; set; }
    }
}
