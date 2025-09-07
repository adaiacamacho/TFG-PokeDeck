using System;
using System.Collections.Generic;

namespace Backend_PokeDeck.Entidades;

public partial class Idioma
{
    public int Id { get; set; }

    public string NomIdioma { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
