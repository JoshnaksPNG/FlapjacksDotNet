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
        public static byte[] read(string path, out bool isRaw)
        {
            List<byte> readBytes = new List<byte>();

            Bitmap bitmap = new Bitmap(path);

            bool is_compressed = read_pixel_bit(bitmap, 0, 1, 0, Color_Channel.Red);

            isRaw = read_pixel_bit(bitmap, 0, 1, 0, Color_Channel.Green);

            bool hasReadSize = false;
            ulong readDataSize = ulong.MaxValue;


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
            byte added_byte = 0;

            for(; pixY < bitmap.Height && (ulong)readBytes.LongCount() < readDataSize; ++pixY) 
            {
                for (; pixX < bitmap.Width && (ulong)readBytes.LongCount() < readDataSize; ++pixX)
                {
                    for (byte ch = 0; ch < 3; ++ch)
                    {
                        for (byte i = 0; i < sig_bits && (ulong)readBytes.LongCount() < readDataSize; ++i)
                        {
                            if (read_pixel_bit(bitmap, i, pixX, pixY, (Color_Channel) ch))
                            {
                                added_byte = (byte)(added_byte | (1 << bitptr));
                            }

                            ++bitptr;

                            if (bitptr == 8)
                            {
                                bitptr = 0;

                                
                                readBytes.Add(added_byte);

                                if (!hasReadSize && readBytes.Count == 8)
                                {
                                    byte[] size_bytes = new byte[8];

                                    for (int l = 0; l < 8; ++l)
                                    {
                                        size_bytes[l] = readBytes[l];
                                    }

                                    readDataSize = dataSize(size_bytes);

                                    hasReadSize = true;

                                    readBytes.Clear();
                                }
                                

                                added_byte = 0;
                            }
                        }
                    }
                }

                pixX = 0;
            }

            return readBytes.ToArray();
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

        public static ulong dataSize(byte[] sizeBytes)
        {
            ulong size = 0;

            for (int i = 7; i >= 0; --i) 
            {
                short bidx = 7;

                while (bidx >= 0) 
                {
                    byte mask = (byte)(1 <<  bidx);

                    byte readVal = sizeBytes[i];

                    if ((readVal & mask) != 0)
                    {
                        ulong writeMask = ((ulong)1) << (i * 8 + bidx);

                        size = size | writeMask;
                    }

                    --bidx;
                }
            }

            return size;
        }

        public static string strFromByteArray(byte[] bytes)
        {
            string output = "";

            foreach (byte b in bytes) 
            {
                output += (char)b;
            }

            return output;
        }


    }
}
