using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.Errors;
using Talabat.Repository.Data;

namespace Talabat.API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreDbContext _context;

        public BuggyController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            var product = _context.Products.Find(100);
            if (product == null)
                return NotFound(new ApiResponse(404));

            return Ok(product);
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public IActionResult GetBadRequestValidationError(int id)
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("servererror")]
        public IActionResult GetServerError()
        {
            var product = _context.Products.Find(100);
            var producttoReturn = product.ToString();
            return Ok(producttoReturn);
        }
    }
}
