using MoviesAPI.MoviesDB_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesAPI.Controllers
{
    public class MoviesController : ApiController
    {
        private MoviesRepository _repo;

        MoviesController()
        {
            _repo = new MoviesRepository();
        }

        [Route("api/movies/")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var movies = _repo.GetAllMovies();
            if (movies != null)
            {
                return Ok(movies);
            }
            return NotFound();
        }

        [Route("api/movies/{id}/")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var movie = _repo.GetMovie(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }

        [Route("api/movies/{id}/")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        [Route("api/movies/{id}/")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        [Route("api/movies/{id}/")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}