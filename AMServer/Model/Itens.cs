namespace Model;

public class Itens
{
    public int id { get; set; }
    public string name { get; set; }

    public int save()
    {
        var id = 0;

        using (var context = new Context())
        {
            var itens = new Itens
            {
                name = this.name,
            };
            context.Itens.Add(itens);
            context.SaveChanges();
            id = itens.id;
            return id;
        }
    }
}