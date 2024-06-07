using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static TextHiderDotNet.ImageWriter;

namespace TextHiderDotNet.src
{
    internal class ImageReader
    {
        public static string read(string path)
        {
            string read_string = "";

            Bitmap bitmap = new Bitmap(path);

            bool is_compressed = read_pixel_bit(bitmap, 0, 1, 0, Color_Channel.Red);

            byte sig_bits = 0;

            for(int cnl = 0; cnl < 3; ++cnl) 
            {
                if (read_pixel_bit(bitmap, 0, 0, 0, (Color_Channel)cnl))
                {
                    sig_bits = (byte)(sig_bits | (1 << cnl));
                }
            }

            sig_bits += 1;

            bool found_null = false;

            int pixX = 2;
            int pixY = 0;

            byte bitptr = 0;
            byte added_char = 0;

            for(; pixY < bitmap.Height && !found_null; ++pixY) 
            {
                for (; pixX < bitmap.Width && !found_null; ++pixX)
                {
                    for (byte ch = 0; ch < 3; ++ch)
                    {
                        for (byte i = 0; i < sig_bits && !found_null; ++i)
                        {
                            if (read_pixel_bit(bitmap, i, pixX, pixY, (Color_Channel) ch))
                            {
                                added_char = (byte)(added_char | (1 << bitptr));
                            }

                            ++bitptr;

                            if (bitptr == 8)
                            {
                                bitptr = 0;

                                if (added_char == 0)
                                {
                                    found_null = true;
                                }
                                else
                                {
                                    read_string += (char)added_char;
                                }

                                added_char = 0;
                            }
                        }
                    }
                }

                pixX = 0;
            }

            return read_string;
        }

        public static bool read_pixel_bit(Bitmap bmp, byte index, int x, int y, ImageWriter.Color_Channel channel) 
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

            byte val = (byte) (color_val & mask);

            return val != 0;
        } 
    }
}
