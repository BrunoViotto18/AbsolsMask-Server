using Microsoft.EntityFrameworkCore;

namespace Model;

public class Sala
{
    public int id { get; set; }
    public int portaEntrada { get; set; }
    public int sala_X { get; set; }
    public int sala_Y { get; set; }

    public int save()
    {
        var id = 0;

        using (var context = new Context())
        {
            var sala = new Sala
            {
                portaEntrada = this.portaEntrada,
                sala_X = this.sala_X,
                sala_Y = this.sala_Y,
            };
            context.Sala.Add(sala);
            context.SaveChanges();
            id = sala.id;
            return id;
        }
    }
    public void update(Sala obj)
    {
        using (var context = new Context())
        {
            var sala = context.Sala.FirstOrDefault(i => i.id == obj.id);

            if (sala != null)
            {
                context.Entry(sala).State = EntityState.Modified;
                sala.sala_X = obj.sala_X;
                sala.sala_Y = obj.sala_Y;
                sala.portaEntrada = obj.portaEntrada;
            }
            context.SaveChanges();
        }
    }

}
