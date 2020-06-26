using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Net;
using C.R.E.A.M.Models;
using Microsoft.Ajax.Utilities;

namespace C.R.E.A.M.Controllers
{
    public class StoreManageController : Controller
    {
        private static FakeDatabase _database = new FakeDatabase();
        // GET: StoreManage
        public ActionResult Index()
        {
            var albums = _database.Albums;

            return View(albums);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var album = _database.Albums.Where(x => x.AlbumId == id).FirstOrDefault();
            if (album == null)
            {
                return HttpNotFound();
            }

            ViewBag.ArtistId =
               new SelectList(_database.artist, "ArtistId", "Name", album.Artist.ArtistId);
            ViewBag.GenreId =
                new SelectList(_database.Genres, "GenreId", "Name", album.Genre.GenreId);

            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(Album updateAlbum)
        {
            if(ModelState.IsValid)
            {
                _database.UpdateAlbum(updateAlbum);

                return RedirectToAction("index");
            }
            else
            {
                List<KeyValuePair<string, ModelState>> errors = ModelState.Where(x => x.Value.Errors.Count > 0).ToList();
                ViewBag.ErrorList = errors;

                return Edit(updateAlbum.AlbumId);
            }


        }

        public ActionResult CreatAlbum()
        {
            var album = _database.Albums.Where(x => x.AlbumId == 1).FirstOrDefault();

            ViewBag.ArtistId =
              new SelectList(_database.artist, "ArtistId", "Name", 1);

            ViewBag.GenreId =
                new SelectList(_database.Genres, "GenreId", "Name", 1);

            return View(album);

        }


        [HttpPost]
        public ActionResult CreatAlbum(Album newalbum)
        {
            if(!ModelState.IsValid)
            {
                return CreatAlbum();
            }

            _database.CreateAlbum(newalbum);
            return RedirectToAction("index");
        }

        public ActionResult Search(string parameter)
        {
            var albums = _database.Albums.Where(x => x.Title.ToLower().Contains(parameter.ToLower()));

            return View("index", albums);
        }

    }
}