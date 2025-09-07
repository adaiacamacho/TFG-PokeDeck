using System;
using System.Collections.Generic;

namespace Backend_PokeDeck.Entidades;

public partial class Favorito
{
    public string Id { get; set; } = null!;

    public int IdUser { get; set; }

    public virtual Usuario? IdUserNavigation { get; set; } = null!;
}
