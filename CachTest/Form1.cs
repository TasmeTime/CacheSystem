using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheSystem;
using System.Windows.Forms;

namespace CachTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cache c = new Cache("C:\\Users\\Shahin\\Desktop", "TEST_CACHE");
            Console.WriteLine(c.DownloadFile("https://www.tutorialspoint.com/green/images/logo.png", "7C36F81013CE9E0A169D43DAAF98BD21"));
            Console.WriteLine(c.GetMD5(c.isFileCached("7C36F81013CE9E0A169D43DAAF98BD21")));
        }
    }
}
