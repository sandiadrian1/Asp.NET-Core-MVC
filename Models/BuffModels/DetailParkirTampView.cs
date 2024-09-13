namespace ParkingMall.Models.BuffModels
{
    public class DetailParkirTampView
    {
        public int ParkirId { get; set; }
        public string NamaType { get; set; }
        public string PlateNomor { get; set; }
        public DateTime WaktuMasuk { get; set; }
        public int BiayaPerJam { get; set; }
        public decimal BiayaParkir  { get; set; }
        public string Status { get; set; }
    }
}
