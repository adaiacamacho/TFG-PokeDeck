using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_PokeDeck.Entidades;

public partial class Carta
{
    public string Id { get; set; } = null!;

    public int IdBaraja { get; set; }

    //[NotMapped]
    //public virtual Baraja? IdBarajaNavigation { get; set; }
}
