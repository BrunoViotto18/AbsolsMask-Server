using Microsoft.EntityFrameworkCore;

namespace Model;

public class Game
{
    public int id { get; set; }
    public DateTime date { get; set; }
    public int seed { get; set; }
    public User user { get; set; }
    public int sala_X { get; set; }
    public int sala_Y { get; set; }
    public int porta { get; set; }

    public int save(int userid)
    {
        var id = 0;

        using (var context = new Context())
        {
            var user = context.User.FirstOrDefault(u => u.id == userid);
            var game = new Game()
            {
                date = this.date,
                seed = this.seed,
                sala_X = this.sala_X,
                sala_Y = this.sala_Y,
                porta = this.porta,
                user = user,
            };
            context.Game.Add(game);
            context.SaveChanges();
            id = game.id;
            return id;
        }
    }
    public void update(Game obj)
    {
        using (var context = new Context())
        {
            var game = context.Game.FirstOrDefault(i => i.id == obj.id);

            if (game != null)
            {
                game.porta = obj.porta;
                game.sala_X = obj.sala_X;
                game.sala_Y = obj.sala_Y;
                context.SaveChanges();
            }
           
        }
    }
}