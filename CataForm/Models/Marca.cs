namespace CataForm.Models
{
    class Marca
    {
        public long MarcaId { get; set; }
        public string Nome { get; set; }

        public Marca()
        {

        }

        public Marca(string Nome)
        {
            this.Nome = Nome;
        }
    }
}
