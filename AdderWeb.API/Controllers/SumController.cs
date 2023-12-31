﻿namespace AdderWeb.API.Controllers
{
    [Route("")]
    [ApiController]
    public class SumController : Controller
    {

        private readonly IRepository<Sum> sumService;

        public SumController(IRepository<Sum> sumService)
        {
            this.sumService = sumService;
        }

        [HttpPost("add")]
        public async Task<IResult> Create(Sum sum)
        {
            sum.Result = sum.First + sum.Second;
            var result = await sumService.AddAsync(sum);
            return Results.Json(result);
        }
    }
}
