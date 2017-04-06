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
            //Creating a new object of cache system and passing 2 parameters, Base path for the cache folder and the name of the cache folder.
            Cache cache = new Cache("C:\\Users\\Shahin\\Desktop", "Images");

            //DownloadFile function automatically checks that if the file is already cached or not,
            //If it's not cached before it will download the file and store it then return the Path of file
            string downloadedFilePath = cache.DownloadFile("https://www.tutorialspoint.com/green/images/logo.png", "7C36F81013CE9E0A169D43DAAF98BD21");
            MessageBox.Show(downloadedFilePath);
        }
    }
}
