using AutoMapper;
using Robotics.Core.DTOs;
using Robotics.Core.Entities;
using Robotics.Core.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Robotics.WebAPI.Controllers
{
    public class BooksController : ApiController
    {

        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private IBookRepository _repo;
        public BooksController(IMapper mapper, IBookRepository repo, ILogger logger)
        {
            _logger = logger;
            _mapper = mapper;
            _repo = repo;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            try
            {
                IEnumerable<Books> result = await _repo.GetAll();

                _logger.Information($"Returned all Books from database");

                IEnumerable<BookDTO> resultDTO = _mapper.Map<IEnumerable<Books>, IEnumerable<BookDTO>>(result);
                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetAllAsync action: {ex.Message}");
                return InternalServerError();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IHttpActionResult> GetFilteredByTitleAsync(String title)
        {
            try
            {
                IEnumerable<Books> result = await _repo.GetFiltered(o => o.Title == title);

                _logger.Information($"Returned all Books from database filtered by title : {title}");

                IEnumerable<BookDTO> resultDTO = _mapper.Map<IEnumerable<Books>, IEnumerable<BookDTO>>(result);
                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetFilteredByTitleAsync action: {ex.Message}");
                return InternalServerError();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IHttpActionResult> GetFilteredByPublisherAsync(String publisherName)
        {
            try
            {
                IEnumerable<Books> result = await _repo.GetFiltered(o => o.Publisher.Name == publisherName);

                _logger.Information($"Returned all Books from database filtered by the publisher's name : {publisherName}");

                IEnumerable<BookDTO> resultDTO = _mapper.Map<IEnumerable<Books>, IEnumerable<BookDTO>>(result);
                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetFilteredByPublisherAsync action: {ex.Message}");
                return InternalServerError();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IHttpActionResult> GetFilteredByAuthorAsync(String authorName)
        {
            try
            {
                IEnumerable<Books> result = await _repo.GetFiltered(o => o.Authors.Name == authorName);

                _logger.Information($"Returned all Books from database filtered by the author's name : {authorName}");

                IEnumerable<BookDTO> resultDTO = _mapper.Map<IEnumerable<Books>, IEnumerable<BookDTO>>(result);
                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong inside GetFilteredByAuthorAsync action: {ex.Message}");
                return InternalServerError();
            }
        }
    }
}
