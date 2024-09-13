using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingMall.Models
{
    public class Parkir
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TypeTransportasi TypeTransportasi { get; set; }
        public string PlateNomor { get; set; }
        public DateTime WaktuMasuk { get; set; }
    }
}
