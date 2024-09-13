using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingMall.Data;
using ParkingMall.Models;
using ParkingMall.Models.BuffModels;
using DetailParking = ParkingMall.Models.DetailParkir;
using Parkir = ParkingMall.Models.Parkir;

namespace ParkingMall.Controllers
{
    [Authorize]
    public class ParkirController : Controller
    {
        private readonly AppDbContext _context;

        public ParkirController(AppDbContext c)
        {
            _context = c;
        }

        public IActionResult Index(string search)
        {
        //TOMBOL SEARCH BERFUNGSI KETIKA KITA TEKAH MENAMBAHKAN 1 PARKIR LALU MENAMBAHKAN 2 TYPE KENDARAAN
            var parkir = _context.Parkir.Include(x => x.TypeTransportasi).ToList();

            if (String.IsNullOrEmpty(search))
            {
                return View(parkir);
            }
            else if (!String.IsNullOrEmpty(search))
            {
                parkir = _context.Parkir.Where(x => x.PlateNomor.ToLower().Contains(search)).ToList();
                return View(parkir);
            }
            return View();

        }

        public IActionResult Create()
        {
            ViewBag.TransportationTypes = _context.TransportationTypes.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nama
            });

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] ParkirTampForm ParkirTampForm)
        {
            var transportationType = _context.TransportationTypes.FirstOrDefault(x => x.Id == ParkirTampForm.TypeTransportasi);

            var Parkir = new Parkir()
            {
                TypeTransportasi = transportationType,
                PlateNomor = ParkirTampForm.PlateNomor,
                WaktuMasuk = ParkirTampForm.WaktuMasuk
            };

            _context.Parkir.Add(Parkir);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            ViewBag.TransportationTypes = _context.TransportationTypes.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nama
            });
            var parkir = _context.Parkir.Include(x => x.TypeTransportasi).FirstOrDefault(x => x.Id == id);

            return View(parkir);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Parkir parkir)
        {
            _context.Parkir.Update(parkir);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var parkir = _context.Parkir.FirstOrDefault(x => x.Id == id);

            _context.Parkir.Remove(parkir);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id, string status = "belum bayar")
        {
            var parkir = _context.Parkir.Include(x => x.TypeTransportasi).FirstOrDefault(x => x.Id == id);

            int biayaPerjam = parkir.TypeTransportasi.BiayaPerJam;
            decimal biayaParkir = 0;
            if (status == "sudah bayar")
            {
                status = "sudah bayar";
                biayaParkir = _context.DetailParking
                    .Where(x => x.Parkir.Id == id)
                    .Select(x => x.BiayaParkir)
                    .FirstOrDefault();
            }
            else
            {
                status = "belum bayar";
                biayaParkir = biayaPerjam * (decimal)(DateTime.Now - parkir.WaktuMasuk).TotalHours;
            }

            var detailView = new DetailParkirTampView()
            {
                ParkirId = parkir.Id,
                NamaType = parkir.TypeTransportasi.Nama,
            PlateNomor = parkir.PlateNomor,
                WaktuMasuk = parkir.WaktuMasuk,
                BiayaPerJam = biayaPerjam, 
                BiayaParkir = biayaParkir,
                Status = status
            };

            return View(detailView);
        }


        [HttpPost]
        public IActionResult Detail([FromForm] DetailParkirTampForm DetailParkirTampForm)
        {
            var detailParkir = _context.DetailParking.FirstOrDefault(x => x.Parkir.Id == DetailParkirTampForm.Parkir);
            var parkir = _context.Parkir.FirstOrDefault(x => x.Id == DetailParkirTampForm.Parkir);

            var DetailParkir = new DetailParking()
            {
                Parkir = parkir,
                BiayaPerJam = DetailParkirTampForm.BiayaPerjam,
                BiayaParkir = DetailParkirTampForm.BiayaParkir,
                Status = DetailParkirTampForm.Status
            };

            if (detailParkir == null)
            {
                _context.DetailParking.Add(DetailParkir);
            }
            else
            {

                detailParkir.BiayaPerJam = DetailParkirTampForm.BiayaPerjam;
                detailParkir.BiayaParkir = DetailParkirTampForm.BiayaParkir;
                detailParkir.Status = DetailParkirTampForm.Status;
                _context.DetailParking.Update(detailParkir);
            }

            _context.SaveChanges();

            return RedirectToAction("Detail", new { id = DetailParkirTampForm.Parkir, status = DetailParkirTampForm.Status });
        }

        

    }
}