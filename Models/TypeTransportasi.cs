using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ParkingMall.Models
{
    public class TypeTransportasi
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
        public int BiayaPerJam { get; set; }
    }
}
