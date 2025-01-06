namespace Devvo.Common.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Anel: Entity
{
    public string Nome { get; set; }
    public string Poder { get; set; }
    public string Portador { get; set; }
    public string ForjadoPor { get; set; }
    public string Imagem { get; set; }

    public Anel(string nome, string poder, string portador, string forjadoPor, string imagem)
    {
        this.Nome = nome;
        this.Poder = poder;
        this.Portador = portador;
        this.ForjadoPor = forjadoPor;
        this.Imagem = imagem;
    }
}