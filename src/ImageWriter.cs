using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextHiderDotNet
{
    internal class ImageWriter
    {
        /*public Image write(Image image, byte[] data, int sig_bits)
        {
            Image writtenImg = image;

            return writtenImg;
        }*/

        public static Bitmap write(string path, byte[] data, int sig_bits, bool compressed, bool isRawFile)
        {
            Bitmap bitmap = new Bitmap(path);

            // 8 byte size of data being written to file
            byte[] dataSize = byteSize((ulong)data.LongLength);

            // Scope To Manage Trash
            { 
                int writen_sig_bits = sig_bits - 1;

                bool[] sig_vals = new bool[3];

                for (int i = 0; i < 3; ++i)
                {
                    int mask = 1 << i;
                    int masked = writen_sig_bits & mask;

                    sig_vals[i] = masked != 0;
                }

                Write_pixel_bit(bitmap, 0, sig_vals[0], 0, 0, Color_Channel.Red);
                Write_pixel_bit(bitmap, 0, sig_vals[1], 0, 0, Color_Channel.Green);
                Write_pixel_bit(bitmap, 0, sig_vals[2], 0, 0, Color_Channel.Blue);

                
                Write_pixel_bit(bitmap, 0, compressed, 1, 0, Color_Channel.Red);
                Write_pixel_bit(bitmap, 0, isRawFile, 1, 0, Color_Channel.Green);
                Write_pixel_bit(bitmap, 0, compressed, 1, 0, Color_Channel.Blue);
                
            }

            int pixX = 2;
            int pixY = 0;
            int dataptr = 0;

            byte[] dataWithSize = new byte[data.LongLength + dataSize.Length];
            dataSize.CopyTo(dataWithSize, 0);
            data.CopyTo(dataWithSize, dataSize.Length);

            BitArray bitData = new BitArray(dataWithSize);

            for (; pixY < bitmap.Height && dataptr < bitData.Length; ++pixY)
            {
                for (; pixX < bitmap.Width && dataptr < bitData.Length; ++pixX)
                {
                    for (byte ch = 0; ch < 3 && dataptr < bitData.Length; ++ch)
                    {
                        for (byte i = 0; i < sig_bits ; ++i)
                        {
                            // Pixel stuff
                            Write_pixel_bit(bitmap, i, bitData.Get(dataptr), pixX, pixY, (Color_Channel) ch);

                            ++dataptr;
                        }
                    }
                }

                pixX = 0;
            }

            

            return bitmap;
        }

        private static void write_pixel_bit(Bitmap bmp, byte[] indecies, bool[] values, int x, int y, Color_Channel channel)
        {
            Color color = bmp.GetPixel(x, y);

            byte color_val;

            switch (channel)
            {
                default:
                case Color_Channel.Red:
                    color_val = color.R;
                    break;

                case Color_Channel.Green:
                    color_val = color.G;
                    break;

                case Color_Channel.Blue:
                    color_val = color.B;
                    break;
            }
                

            for (int i = 0; i < indecies.Length; ++i)
            {
                byte mask = (byte) (1 << indecies[i]);

                byte val = (byte) (values[i] ? 255: 0);

                color_val = (byte) (color_val ^ ((color_val ^ val) & mask));
            }

            Color written_color;

            switch (channel)
            {
                default:
                case Color_Channel.Red:
                    written_color = Color.FromArgb(color_val, color.G, color.B);
                    break;

                case Color_Channel.Green:
                    written_color = Color.FromArgb(color.R, color_val, color.B); ;
                    break;

                case Color_Channel.Blue:
                    written_color = Color.FromArgb(color.R, color.G, color_val); ;
                    break;
            }

            bmp.SetPixel(x, y, written_color);
        }

        private static void Write_pixel_bit(Bitmap bmp, byte index, bool value, int x, int y, Color_Channel channel)
        {
            Color color = bmp.GetPixel(x, y);

            byte color_val;

            switch (channel)
            {
                default:
                case Color_Channel.Red:
                    color_val = color.R;
                    break;

                case Color_Channel.Green:
                    color_val = color.G;
                    break;

                case Color_Channel.Blue:
                    color_val = color.B;
                    break;
            }


            byte mask = (byte)(1 << index);

            byte val = (byte)(value ? 255 : 0);

            color_val = (byte)(color_val ^ ((color_val ^ val) & mask));

            Color written_color;


            switch (channel)
            {
                default:
                case Color_Channel.Red:
                    written_color = Color.FromArgb(color_val, color.G, color.B);
                    break;

                case Color_Channel.Green:
                    written_color = Color.FromArgb(color.R, color_val, color.B); ;
                    break;

                case Color_Channel.Blue:
                    written_color = Color.FromArgb(color.R, color.G, color_val); ;
                    break;
            }

            bmp.SetPixel(x, y, written_color);
        }

        public static byte[] byteSize(ulong dataSize)
        {
            
            ulong size = dataSize;

            byte[] bytes = new byte[8];

            short idx = 63;

            byte arrayidx = (byte)(idx / 8);
            byte byteidx = (byte)(idx % 8);

            while (idx >= 0)
            {
                byte writeVal = bytes[arrayidx];

                byte mask = (byte)(1 << byteidx);

                ulong significance = (ulong) Math.Pow(2, idx);

                bool shouldWrite = size >= significance;

                byte val = (byte)(shouldWrite ? 255 : 0);

                bytes[arrayidx] = (byte)(writeVal ^ ((writeVal ^ val) & mask));

                --idx;
                arrayidx = (byte)(idx / 8);
                byteidx = (byte)(idx % 8);

                if(shouldWrite) 
                {
                    size -= significance;
                } 
            }

            return bytes;
        }

        public enum Color_Channel
        {
            Red,
            Green,
            Blue,
        }
    }
}
