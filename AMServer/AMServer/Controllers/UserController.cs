using System;
using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMServer.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object resgisterUser([FromBody] User user)
    {
        var id = user.save();
        if (user.id == -1)
        {
            return "usuario ja cadastrado";
        }
        else
        {
            return new
            {
                id = id,
                name = user.login,
                passwd = user.password,
            };
        }
    }

    [HttpGet]
    [Route("login")]
    public Object loginUser([FromBody] User user)
    {
        if (user != null && user.login != null && user.password != null)
        {
            var userLogin = Model.User.loginUser(user.login, user.password);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (userLogin != null)
            {
                return new
                {
                    id = userLogin.id,
                    login = userLogin.login,
                    password = userLogin.password
                };
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }
        else
        {
            return BadRequest("Invalid credentials");
        }
    }
}
