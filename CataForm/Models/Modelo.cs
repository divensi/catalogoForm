namespace CataForm.Models
{
    class Modelo
    {
        public long ModeloId { get; set; }
        public string Nome { get; set; }
        public long MarcaId { get; set; }

        public Modelo (string Nome, int MarcaId)
        {
            this.Nome = Nome;
            this.MarcaId = MarcaId;
        }
    }
}
