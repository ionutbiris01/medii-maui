using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medii_maui.Models
{
    public class Delivery
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string? StartLocation { get; set; }

        public string? EndLocation { get; set; }

        public int PhoneNumber { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Status))]
        public int StatusID { get; set; }


        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Status Status { get; set; }
    }
}
