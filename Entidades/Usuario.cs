using System;
using System.Collections.Generic;

namespace Backend_PokeDeck.Entidades;

public partial class Usuario
{
    public int Id { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? IdIdioma { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? IdImagen { get; set; }

    public virtual ICollection<Baraja>? Barajas { get; set; } = new List<Baraja>();

    public virtual ICollection<Favorito>? Favoritos { get; set; } = new List<Favorito>();

    public virtual Idioma? IdIdiomaNavigation { get; set; }

    public virtual ImagenPerfil? IdImagenNavigation { get; set; }
}
