using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParserSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void parseButton_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            try
            {
                progressBar1.Value = 0;
                StringContent httpContent = new StringContent(urlBox.Text, Encoding.UTF8, "plain/text");
                progressBar1.Value = 10;
                HttpResponseMessage response = await client.PostAsync("http://localhost:8080/parse", httpContent);
                progressBar1.Value = 50;
                response.EnsureSuccessStatusCode();
                progressBar1.Value = 80;
                Console.WriteLine(response);
                progressBar1.Value = 100;
                refreshButton_Click(sender, e);
                
            }
            catch (HttpRequestException err)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", err.Message);
            }
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                receiptGrid.Rows.Clear();
                progressBar1.Value = 0;
                HttpResponseMessage response = await client.GetAsync("http://localhost:8080/receipts");
                progressBar1.Value = 50;
                response.EnsureSuccessStatusCode();
                progressBar1.Value = 60;
                //receiptsList.Items.Add(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine(response);
                var receipts = response.Content.ReadAsStringAsync().Result;
                progressBar1.Value = 70;
                List<Receipt> rList = JsonConvert.DeserializeObject<List<Receipt>>(receipts);
                //var receipts = JsonConvert.DeserializeObject<List<receipt>>(response.Content.ReadAsStringAsync().);
                progressBar1.Value = 80;
                rList.ForEach(delegate (Receipt r)
                {
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(r.date);
                    //receiptList.Items.Add(r.id + "      $" + r.total + "      $" + r.taxesPaid + "      " + dateTimeOffset.Date.ToString("MM/dd/yy"));
                    receiptGrid.Rows.Add(r.id, r.total, r.taxesPaid, dateTimeOffset.Date.ToString("MM/dd/yy"));
                });
                progressBar1.Value = 100;

            }
            catch (HttpRequestException err)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", err.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void receiptGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //String r = receiptList.SelectedItem.ToString();
            //List<String> result = r.Split(' ').ToList();
            String id = receiptGrid.SelectedCells[0].Value.ToString();
            //MessageBox.Show(id);
            Receipt receipt;
            try
            {
                progressBar1.Value = 0;
                HttpResponseMessage response = await client.GetAsync("http://localhost:8080/receipts/" + id);
                progressBar1.Value = 50;
                response.EnsureSuccessStatusCode();
                progressBar1.Value = 60;
                var content = response.Content.ReadAsStringAsync().Result;
                progressBar1.Value = 70;
                receipt = JsonConvert.DeserializeObject<Receipt>(content);
                progressBar1.Value = 80;
                receiptImage.Load(receipt.url);
                progressBar1.Value = 100;

            }
            catch (HttpRequestException err)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", err.Message);
            }
        }
    }

    public class Receipt
    {

        public int id;
        public double total;
        public double taxesPaid;
        public long date;
        public string url;


    }
}
