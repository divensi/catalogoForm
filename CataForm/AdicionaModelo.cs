using CataForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CataForm
{
    public partial class AdicionaModelo : Form
    {
        public AdicionaModelo()
        {
            InitializeComponent();

            using (var webClient = new System.Net.WebClient())
            {
                var jsonMarcas = webClient.DownloadString("http://localhost:5000/api/marca");
                List<Marca> marcas = JsonConvert.DeserializeObject<List<Marca>>(jsonMarcas);

                Dictionary<long, string> marcasItem = new Dictionary<long, string>();

                foreach (var marca in marcas)
                {
                    marcasItem.Add(marca.MarcaId, marca.Nome);
                }

                CbbMarcas.DataSource = new BindingSource(marcasItem, null);

                CbbMarcas.DisplayMember = "Value";
                CbbMarcas.ValueMember = "Key";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            var task = EnviarRequestAsync();

            this.Close();
        }

        private async Task EnviarRequestAsync()
        {
            int valorCbb = (int) ((KeyValuePair<long, string>)CbbMarcas.SelectedItem).Key;
            Modelo modelo = new Modelo(txtNome.Text, valorCbb);

            string jsonModelo = JsonConvert.SerializeObject(modelo);

            Console.WriteLine(jsonModelo);

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    "http://localhost:5000/api/modelo",
                     new StringContent(jsonModelo, Encoding.UTF8, "application/json"));
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
