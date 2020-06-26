using C.R.E.A.M.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C.R.E.A.M
{
    public class FakeDatabase
    {
        private List<Album> _albums;
        private List<Genre> _genres;
        private List<Artist> _artists;

        public List<Album> Albums
        {
            get { return _albums; }
        }

        public List<Genre> Genres
        {
            get { return _genres; }
        }

        public List<Artist> artist
        {
            get { return _artists; }
        }

        public FakeDatabase()
        {
            initializeArtists();
            initializeGenres();
            initializeAlbums();
        }

        private void initializeArtists()
        {
            _artists = new List<Artist>();

            _artists.Add(new Artist() { ArtistId = 1, Name = "Pink Floyd", BasicInfo = "Eng", ImageUrl = "" });
            _artists.Add(new Artist() { ArtistId = 2, Name = "Daft Punk", BasicInfo = "Frn", ImageUrl = "" });
            _artists.Add(new Artist() { ArtistId = 3, Name = "KayaKata", BasicInfo = "Geo", ImageUrl = "" });
            _artists.Add(new Artist() { ArtistId = 4, Name = "Biggie", BasicInfo = "Usa", ImageUrl = "" });
            _artists.Add(new Artist() { ArtistId = 5, Name = "Lady Gaga", BasicInfo = "Eng", ImageUrl = "" });
            _artists.Add(new Artist() { ArtistId = 6, Name = "Skillex", BasicInfo = "Eng", ImageUrl = "" });
        }

        private void initializeGenres()
        {
            _genres = new List<Genre>();

            _genres.Add(new Genre() { GenreId = 1, Name = "Progresive Rock" });
            _genres.Add(new Genre() { GenreId = 2, Name = "Electronic" });
            _genres.Add(new Genre() { GenreId = 3, Name = "Mumble" });
            _genres.Add(new Genre() { GenreId = 4, Name = "Hip-Hop" });
            _genres.Add(new Genre() { GenreId = 5, Name = "Pop Rock" });
        }

       private void initializeAlbums()
        {
            _albums = new List<Album>();

            _albums.Add(new Album()
            {
                AlbumId = 1,
                Title = "Dark Side Of The Moon",
                Price = 20.99M,
                Genre = _genres.Where(x => x.Name == "Progresive Rock").FirstOrDefault(),
                Artist = _artists.Where(x => x.Name == "Pink Floyd").FirstOrDefault(),
                AlbumUrl = "/App_Files/Images/1.jpg",
                ReleaseYear = 1973
            }) ;

            _albums.Add(new Album()
            {
                AlbumId = 2,
                Title = "Random Access Memmory",
                Price = 15.99M,
                Genre = _genres.Where(x => x.Name == "Electronic").FirstOrDefault(),
                Artist = _artists.Where(x => x.Name == "Daft Punk").FirstOrDefault(),
                AlbumUrl = "/App_Files/Images/2.jpg",
                ReleaseYear = 2015
            });

            _albums.Add(new Album()
            {
                AlbumId = 3,
                Title = "recess",
                Price = 20.99M,
                Genre = _genres.Where(x => x.Name == "Electronic").FirstOrDefault(),
                Artist = _artists.Where(x => x.Name == "Skillex").FirstOrDefault(),
                AlbumUrl = "/App_Files/Images/3.jpg",
                ReleaseYear = 2015
            });
        }

        public void UpdateAlbum(Album updateAlbum)
        {
            updateAlbum.Genre = Genres.Where(x => x.GenreId == updateAlbum.GenreId).FirstOrDefault();
            updateAlbum.Artist = artist.Where(x => x.ArtistId == updateAlbum.ArtistId).FirstOrDefault();

            _albums[updateAlbum.AlbumId - 1] = updateAlbum;
        }
        public void CreateAlbum(Album newAlbum)
        {
            newAlbum.Genre = Genres.Where(x => x.GenreId == newAlbum.GenreId).FirstOrDefault();
            newAlbum.Artist = artist.Where(x => x.ArtistId == newAlbum.ArtistId).FirstOrDefault();

            newAlbum.AlbumId = _albums.Max(x => x.AlbumId) + 1;
            _albums.Add(newAlbum);
        }

    }
}