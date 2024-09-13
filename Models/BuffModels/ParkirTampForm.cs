namespace ParkingMall.Models.BuffModels
{
    public class ParkirTampForm
    {
        //variabel yang akan digunakan di controller,dan mengambil value dari class parkir yang telah di migrasi
        public int TypeTransportasi { get; set; }
        public string PlateNomor { get; set; }
        public DateTime WaktuMasuk { get; set; }

    }
}
