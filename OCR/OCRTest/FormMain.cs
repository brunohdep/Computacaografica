using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCRTest
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                var img = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image = img;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var image = (Bitmap) pictureBox1.Image;
            var ocr = new tessnet2.Tesseract();
            ocr.Init(@"tessdata", "eng", false);
            ocr.SetVariable("tesseract_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVXWYZ-1234567890");
            var result = ocr.DoOCR(image, Rectangle.Empty);
            StringBuilder sb = new StringBuilder();
            foreach (tessnet2.Word word in result)
                sb.Append(word.Text + " ");
            textBox1.Text = sb.ToString();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
