namespace Dominio.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Nacionalidade { get; set; }
        public GeneroEnum Genero { get; set; }
        public int Idade { get; set; }
        public Endereco Endereco { get; set; }
    }
}