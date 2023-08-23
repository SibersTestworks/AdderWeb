using AdderWeb.Domain.Contracts;
using AdderWeb.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdderWeb.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SumController : Controller
    {

        private readonly IRepository<Sum> sumService;

        public SumController(IRepository<Sum> sumService)
        {
            this.sumService = sumService;
        }

        [HttpPost("sum")]
        public async Task<IResult> Create(Sum sum)
        {
            sum.Result = sum.First + sum.Second;
            var result = await sumService.AddAsync(sum);
            return Results.Json(result);
        }
    }
}
