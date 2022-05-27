using System;
using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMServer.Controllers;
[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object resgisterGame([FromBody] Game game)
    {
        var id = game.save(game.user.id);
        return new
        {
            id = id,
            user = game.user,
            date = game.date,
            seed = game.seed,
            sala_X = game.sala_X,
            sala_Y = game.sala_Y
        };
    }
    
    [HttpPut]
    [Route("update")]
    public object updateGame([FromBody] Game game)
    {
        var result = game;

        result.update(game);
        return new { status = "sucess" };
    }
}
