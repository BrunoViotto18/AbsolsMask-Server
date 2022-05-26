using System;
using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMServer.Controllers;
[ApiController]
[Route("[controller]")]
public class ItensController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object resgisterSala([FromBody] Itens itens)
    {
        var id = itens.save();
        return new
        {
            id = id,
            name = itens.name,
        };
    }
}
