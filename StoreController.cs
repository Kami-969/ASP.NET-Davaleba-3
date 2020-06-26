using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace C.R.E.A.M.Controllers
{
    public class StoreController : Controller
    {
        private FakeDatabase _database = new FakeDatabase();
        // GET: Store
        public ActionResult Index()
        {
            var genres = _database.Genres;

            return View(genres);
        }

        public ActionResult Browse(string genre)
        {
            var genreModel = _database.Genres.Where(x => x.Name == genre).FirstOrDefault();

            var albums = _database.Albums.Where(x => x.Genre.Name == genre).ToList();

            genreModel.Albums = albums;

            return View(genreModel);
        }

        public ActionResult Detail(int id)
        {
            var album = _database.Albums.Where(x => x.AlbumId == id).FirstOrDefault();

            return View(album);
        }
    }
}