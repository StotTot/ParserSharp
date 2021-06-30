using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                StringContent httpContent = new StringContent(urlBox.Text, Encoding.UTF8, "plain/text");
                HttpResponseMessage response = await client.PostAsync("http://localhost:8080/parse", httpContent);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(response);
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
                receiptList.Items.Clear();

                HttpResponseMessage response = await client.GetAsync("http://localhost:8080/receipts");
                response.EnsureSuccessStatusCode();
                //receiptsList.Items.Add(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine(response);
                var receipts = response.Content.ReadAsStringAsync().Result;
                List<Receipt> rList = JsonConvert.DeserializeObject<List<Receipt>>(receipts);
                //var receipts = JsonConvert.DeserializeObject<List<receipt>>(response.Content.ReadAsStringAsync().);

                rList.ForEach(delegate (Receipt r)
                {
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(r.date);
                    receiptList.Items.Add(r.id + "      $" + r.total + "      $" + r.taxesPaid + "      " + dateTimeOffset.Date.ToString("MM/dd/yy"));
                });

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

        private async void receiptList_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            String r = receiptList.SelectedItem.ToString();
            List<String> result = r.Split(' ').ToList();
            String id = result[0];
            Receipt receipt;
            try 
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8080/receipts/" + id);
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                receipt = JsonConvert.DeserializeObject<Receipt>(content);
                receiptImage.Load(receipt.url);
            
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
