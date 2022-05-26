using System;
using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMServer.Controllers;
[ApiController]
[Route("[controller]")]
public class ItensColetadosController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object resgisterItensColetados([FromBody] ItensColetados itenscoletados)
    {
        var id = itenscoletados.save(itenscoletados.game.id, itenscoletados.itens.id);
        return new
        {
            id = id,
            game = itenscoletados.game,
            itens = itenscoletados.itens,
        };
    }
}
