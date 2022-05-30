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
    [Route("register/{login}/{senha}")]
    public object? resgisterUser(string login, string senha)
    {
        User user = new User()
        {
            login = login,
            password = senha
        };
        var id = user.save();
        if (user.id == -1)
        {
            return null;
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
    [Route("verifica/{login}/{senha}")]
    public Object verificaUser(string login)
    {
        var user = Model.User.verificaUser(login);
        if(user != null && user.login != null)
        {
            return user.id;
        }
        else
        {
            return 0;
        }
    }

    [Route("login/{login}/{senha}")]
    public Object loginUser(string login, string senha)
    {
        var user = Model.User.loginUser(login, senha);
        if (user != null && user.login != null && user.password != null)
        {
            var userLogin = Model.User.loginUser(user.login, user.password);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (userLogin != null && user.login != null && user.password != null)
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
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }
}
