using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingMall.Models
{
    public class DetailParkir
    {
        [Key]
        public int Id { get; set; }
        public Parkir Parkir { get; set; }
        public int BiayaPerJam { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal BiayaParkir{ get; set; }
        public string Status { get; set; }
    }
}
