using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipe.API.Application.Interfaces;

namespace Recipe.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(IUnitOfWork unitOfWork, ILogger<RecipeController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.Recipes.GetAllAsync();
            _logger.LogInformation(result.ToString());
            return Ok(result);
        }
    }
}