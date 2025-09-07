using System;
using System.Collections.Generic;

namespace Backend_PokeDeck.Entidades;

public partial class ImagenPerfil
{
    public int Id { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
