using System.Drawing.Drawing2D;
using System.Text;
using TextHiderDotNet.src;

namespace TextHiderDotNet
{
    public partial class Form1 : Form
    {
        bool compress;

        int sig_bits;


        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Visible = true;
                button1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
                button1.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("String Input");
            comboBox1.Items.Add("File Input");

            textBox1.Visible = false;
            button1.Visible = false;
            compress = false;
            sig_bits = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Title = "Select Text";
            openFile.InitialDirectory = @"C:\\";
            openFile.Filter = "Text File (*.txt)|*.txt";
            openFile.FilterIndex = 1;

            openFile.ShowDialog();


            textBox1.Text = openFile.FileName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Title = "Select Input Image";
            openFile.InitialDirectory = @"C:\\";
            openFile.Filter = "Image File (*.png, *.jpeg, *.jpg)|*.png|*.jpeg|*.jpg";
            openFile.FilterIndex = 1;

            openFile.ShowDialog();


            textBox2.Text = openFile.FileName;

            pictureBox1.ImageLocation = openFile.FileName;
            /*
            int width_ratio = pictureBox1.Image.Width / pictureBox1.Width;
            int height_ratio = pictureBox1.Image.Height / pictureBox1.Height;

            int img_ratio = (width_ratio > height_ratio) ? width_ratio : height_ratio;

            pictureBox1.Image = ResizeImage(pictureBox1.Image, new Size(pictureBox1.Image.Width * width_ratio, pictureBox1.Image.Height * height_ratio));*/



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        Image ResizeImage(Image imgToResize, Size size)
        {
            // Get the image current width
            int sourceWidth = imgToResize.Width;
            // Get the image current height
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            // Calculate width and height with new desired size
            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);
            nPercent = Math.Min(nPercentW, nPercentH);
            // New Width and Height
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            compress = checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string write;

            if (comboBox1.SelectedIndex == 1)
            {
                write = File.ReadAllText(comboBox1.Text);
            }
            else
            {
                write = comboBox1.Text;
            }

            byte[] data;

            if (compress)
            {
                Compressor compressor = new Compressor(write);

                data = compressor.compress(write);
            }
            else 
            {
                data = Encoding.UTF8.GetBytes(write);
            }

            Image inputImg = Image.FromFile(textBox2.Text);

            ImageWriter writer = new ImageWriter();

            Image outputImg = writer.write(inputImg, data, sig_bits);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sig_bits = trackBar1.Value;

            label4.Text = sig_bits.ToString() + " bit";
            if (sig_bits > 1)
            {
                label4.Text += "s";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}