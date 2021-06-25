using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace ParserSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void parseButton_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            try {
                StringContent httpContent = new StringContent(urlBox.Text, Encoding.UTF8, "plain/text") ;
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

        private async void getAllButton_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                receiptsList.Items.Clear();

                HttpResponseMessage response = await client.GetAsync("http://localhost:8080/receipts");
                response.EnsureSuccessStatusCode();
                //receiptsList.Items.Add(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine(response);
                var receipts = response.Content.ReadAsStringAsync().Result;
                List<receipt> rList = JsonConvert.DeserializeObject<List<receipt>>(receipts);
                //var receipts = JsonConvert.DeserializeObject<List<receipt>>(response.Content.ReadAsStringAsync().);
                
                rList.ForEach(delegate (receipt r)
                {
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(r.date);
                    receiptsList.Items.Add(r.id + "      $" + r.total + "      $" + r.taxesPaid + "      " + dateTimeOffset.Date.ToString("MM/dd/yy"));
                });

            }
            catch (HttpRequestException err)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", err.Message);
            }
        }

        private void receiptsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class receipt {

        public int id;
        public double total;
        public double taxesPaid;
        public long date;
         
    
    
    }
}
