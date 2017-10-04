using CataForm.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CataForm
{
    public partial class AdicionaMarca : Form
    {
        public AdicionaMarca()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOk_ClickAsync(object sender, EventArgs e)
        {
            var task = EnviarRequestAsync();

            this.Close();
            //var result = task.WaitAndUnwrapException();
        }

        private async Task EnviarRequestAsync()
        {
            Marca marca = new Marca(txtNome.Text);

            string jsonMarca = JsonConvert.SerializeObject(marca);

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    "http://localhost:5000/api/marca",
                     new StringContent(jsonMarca, Encoding.UTF8, "application/json"));
            }
        }
    }
}
