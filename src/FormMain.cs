using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using TextHiderDotNet.src;

namespace TextHiderDotNet
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        bool compress;

        int sig_bits;


        public FormMain()
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
            string write;

            if (comboBox1.SelectedIndex == 1 && textBox1.Text != "")
            {
                write = File.ReadAllText(textBox1.Text);
            }
            else
            {
                write = textBox1.Text;
            }

            write += "\0";

            double textSize = write.Length;
            byte sizeUnit = 0;

            while (textSize >= 1024)
            {
                textSize /= 1024;
                ++sizeUnit;
            }

            label8.Text = "" + (((double)(int)(textSize * 100)) / 100) + (DataUnits)sizeUnit;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Title = "Select Input Image";
            openFile.InitialDirectory = @"C:\\";
            openFile.Filter = "Image File (*.png, *.jpeg, *.jpg, *.gif, *.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|PNG (*.png)|*.png|JPEG (*.jpeg, *.jpg)|*.jpeg;*.jpg|GIF (*.gif)|*.gif|BMP (*.bmp)|*.bmp";
            openFile.FilterIndex = 1;

            openFile.ShowDialog();


            textBox2.Text = openFile.FileName;

            pictureBox1.ImageLocation = openFile.FileName;
            /*
            int width_ratio = pictureBox1.Image.Width / pictureBox1.Width;
            int height_ratio = pictureBox1.Image.Height / pictureBox1.Height;

            int img_ratio = (width_ratio > height_ratio) ? width_ratio : height_ratio;

            pictureBox1.Image = ResizeImage(pictureBox1.Image, new Size(pictureBox1.Image.Width * width_ratio, pictureBox1.Image.Height * height_ratio));*/


            update_img_size();
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
            if (textBox2.Text.Length <= 0)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Please select an image to write to! >:(");
                return;
            }

            string write;

            if (comboBox1.SelectedIndex == 1)
            {
                write = File.ReadAllText(textBox1.Text);
            }
            else
            {
                write = textBox1.Text;
            }

            write += "\0";

            byte[] data;

            List<byte> tempData = new List<byte>();

            if (compress)
            {
                Compressor compressor = new Compressor(write);

                data = compressor.compress(write);
            }
            else
            {
                data = Encoding.UTF8.GetBytes(write);
            }

            Image outputImg = ImageWriter.write(textBox2.Text, data, sig_bits, false);

            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Title = "Save Image";
            saveFile.InitialDirectory = @"C:\\";
            saveFile.Filter = "PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp";
            saveFile.FilterIndex = 1;
            saveFile.OverwritePrompt = true;

            saveFile.ShowDialog();

            FileStream fs = (FileStream)saveFile.OpenFile();

            switch (saveFile.FilterIndex)
            {
                case 1:
                    outputImg.Save(fs, ImageFormat.Png);
                    break;

                default:
                case 2:
                    outputImg.Save(fs, ImageFormat.Bmp);
                    break;
            }

            //outputImg.Save(fs, ImageFormat.Png);

            fs.Dispose();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sig_bits = trackBar1.Value;

            label4.Text = sig_bits.ToString() + " bit";
            if (sig_bits > 1)
            {
                label4.Text += "s";
            }

            update_img_size();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Title = "Save Text as File";
            saveFile.InitialDirectory = @"C:\\";
            saveFile.Filter = "Text File (*.txt)|*.txt";
            saveFile.FilterIndex = 1;
            saveFile.OverwritePrompt = true;

            saveFile.ShowDialog();

            if (saveFile.FileName.Length <= 0)
            {
                return;
            }

            FileStream fs = (FileStream)saveFile.OpenFile();

            StreamWriter outputWriter = new StreamWriter(fs);

            outputWriter.Write(textBox4.Text);

            fs.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Title = "Select Input Image";
            openFile.InitialDirectory = @"C:\\";
            openFile.Filter = "PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp";
            openFile.FilterIndex = 1;

            openFile.ShowDialog();


            textBox3.Text = openFile.FileName;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length <= 0)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Please select an image to read. :)");
                return;
            }

            string decoded = ImageReader.read(textBox3.Text);

            textBox4.Text = decoded;


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private enum DataUnits
        {
            B,
            KB,
            MB,
            GB,
            TB,
        }

        private void update_img_size()
        {
            const int currentChannels = 3;

            if (pictureBox1.ImageLocation == null || pictureBox1.ImageLocation == "")
            {
                return;
            }
            Bitmap img = new Bitmap(pictureBox1.ImageLocation);

            long pixelRoom = (img.Width * img.Height * currentChannels) - (currentChannels * 2);

            long imgRoomInt = (pixelRoom * sig_bits) / 8;

            double imgRoom = imgRoomInt;
            byte sizeUnit = 0;

            while (imgRoom >= 1024)
            {
                imgRoom /= 1024;
                ++sizeUnit;
            }

            label9.Text = "" + (((double)(int)(imgRoom * 100)) / 100) + (DataUnits)sizeUnit;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}