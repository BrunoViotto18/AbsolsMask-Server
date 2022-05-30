namespace Model;

public class User
{
    public int id { get; set; }
    public string login { get; set; }
    public string password { get; set; }

    public int save()
    {
        var id = 0;

        using (var context = new Context())
        {
            var dados = context.User.FirstOrDefault(u => u.login == login);
            if(dados == null)
            {
                var user = new User
                {
                    login = this.login,
                    password = this.password,
                };
                context.User.Add(user);
                context.SaveChanges();
                id = user.id;
                return id;
            }
            else
            {
                return -1;
            }
        }
    }

    public static User? loginUser(string login, string password)
    {
        var usuario = new User();
        using (var context = new Context())
        {
            var user = context.User.FirstOrDefault(a => a.login == login &&  a.password == password);

            if (user != null)
            {
                usuario.login = user.login;
                usuario.password = user.password;
                usuario.id = user.id;
            }
        }

        return usuario;
    }

    public static User? verificaUser(string login)
    {
        var usuario = new User();
        using (var context = new Context())
        {
            var user = context.User.FirstOrDefault(a => a.login == login);

            if (user != null)
            {
                usuario.login = user.login;
                usuario.password = user.password;
                usuario.id = user.id;
            }
        }

        return usuario;
    }
}