public class Objeto
{
    public List<Parte> Partes { get; set; }

    public Objeto()
    {
        Partes = new List<Parte>();
    }

    public void AgregarParte(Parte parte)
    {
        Partes.Add(parte);
    }
}