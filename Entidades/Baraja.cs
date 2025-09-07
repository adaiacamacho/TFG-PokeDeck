using System;
using System.Collections.Generic;

namespace Backend_PokeDeck.Entidades;

public partial class Baraja
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public DateOnly FechaCreacion { get; set; }

    public string Nombre { get; set; } = null!;

    //public virtual ICollection<Carta> Carta { get; set; } = new List<Carta>();

    public virtual Usuario? IdUserNavigation { get; set; } = null!;
}
