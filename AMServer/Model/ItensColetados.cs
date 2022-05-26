namespace Model;

public class ItensColetados
{
    public int id { get; set; }
    public Game game { get; set; }
    public Itens itens { get; set; }

    public int save(int gameid, int itemid)
    {
        var id = 0;

        using (var context = new Context())
        {
            var game = context.Game.FirstOrDefault(i => i.id == gameid);
            var itens = context.Itens.FirstOrDefault(i => i.id == itemid);
            if(game == null || itens == null)
            {
                return -1;
            }
            var itensColetados = new ItensColetados
            {
                game = game,
                itens = itens
            };
            context.ItensColetados.Add(itensColetados);
            context.Entry(itensColetados.game).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(itensColetados.itens).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();
            id = itensColetados.id;
            return id;
        }
    }
}