using System;
using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMServer.Controllers;
[ApiController]
[Route("[controller]")]
public class SalaController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object resgisterSala([FromBody] Sala sala)
    {
        var id = sala.save();
        return new
        {
            id = id,
            portaEntrada = sala.portaEntrada,
            sala_X = sala.sala_X,
            sala_Y = sala.sala_Y,
        };
    }

    [HttpPut]
    [Route("update")]
    public object updateSala([FromBody] Sala sala)
    {
        var result = sala;

        result.update(sala);
        return new { status = "sucess" };
    }

}
