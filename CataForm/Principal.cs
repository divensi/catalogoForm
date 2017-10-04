using CataForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CataForm
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var webClient = new System.Net.WebClient())
            {

                var jsonMarcas = webClient.DownloadString("http://localhost:5000/api/marca");
                var jsonModelos = webClient.DownloadString("http://localhost:5000/api/modelo");

                TrvCarros.Nodes.Clear();

                List<Modelo> marcas = JsonConvert.DeserializeObject<List<Modelo>>(jsonMarcas);
                List<Modelo> modelos = JsonConvert.DeserializeObject<List<Modelo>>(jsonModelos);

                foreach (var marca in marcas)
                {
                    TrvCarros.Nodes.Add(Convert.ToString(marca.MarcaId), marca.Nome);

                    foreach (var modelo in modelos)
                    {
                        if (modelo.MarcaId == marca.MarcaId)
                        {
                            TrvCarros.Nodes[Convert.ToString(marca.MarcaId)].Nodes.Add(modelo.Nome);
                        }
                    }

                }
            }
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdicionaMarca adicionador = new AdicionaMarca();
            adicionador.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void adicionarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdicionaModelo adicionador = new AdicionaModelo();
            adicionador.Show();

        }

        private void TrvCarros_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show(TrvCarros.SelectedNode.Text);
        }
    }
}
