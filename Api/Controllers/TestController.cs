using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [Authorize]
    [HttpGet("test1")]
    public async Task<IResult> Test1()
    {
        await Task.CompletedTask;
        return Results.Ok(new { result = "test 1 ok" });
    }

    [HttpGet("test2")]
    public async Task<IResult> Test2()
    {
        await Task.CompletedTask;
        return Results.Ok(new { result = "test 2 ok" });
    }
}
