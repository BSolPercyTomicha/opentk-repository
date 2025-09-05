public class Parte
{
    public List<Cara> Caras { get; set; }

    public Parte()
    {
        Caras = new List<Cara>();
    }

    public void AgregarCara(Cara cara)
    {
        Caras.Add(cara);
    }
}