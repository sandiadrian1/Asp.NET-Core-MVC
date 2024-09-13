using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingMall.Data;
using ParkingMall.Models;

namespace ParkingMall.Controllers
{
    [Authorize]
    public class TypeTransportasiController : Controller
    {
        private readonly AppDbContext _context;

        public TypeTransportasiController(AppDbContext c)
        {
            _context = c;
        }

        public IActionResult Index()
        {
            var typeTransportasi = _context.TransportationTypes.ToList();

            return View(typeTransportasi);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] TypeTransportasi TransportationType)
        {
            var transportationType = new TypeTransportasi()
            {
                Nama = TransportationType.Nama,
                BiayaPerJam = GetBiayaPerJam(TransportationType.Nama) // Mendapatkan biaya per jam berdasarkan jenis transportasi
            };

            _context.TransportationTypes.Add(transportationType);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private int GetBiayaPerJam(string namaTransportasi)
        {
            if (namaTransportasi == "Motor")
            {
                return 3000; 
            }
            else if (namaTransportasi == "Mobil")
            {
                return 5000; 
            }
            else if (namaTransportasi == "Becak")
            {
                return 5000;
            }
            else
            {
                return 0; 
            }
        }

        public IActionResult Edit(int id)
        {
            var transportationType = _context.TransportationTypes.FirstOrDefault(x => x.Id == id);

            return View(transportationType);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] TypeTransportasi TransportationType)
        {
            _context.TransportationTypes.Update(TransportationType);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var transportationType = _context.TransportationTypes.FirstOrDefault(x => x.Id == id);

            _context.TransportationTypes.Remove(transportationType);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
