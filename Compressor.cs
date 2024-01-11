using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace TextHiderDotNet
{
    internal class Compressor
    {
        string compressed;

        string original;

        Dictionary<string, string> img_key;

        CodingTree tree;


        public Compressor(string input) 
        {
            original = input;
            tree = new CodingTree();
            tree.build(input);

            img_key = tree.encodeMap;
        }

        public byte[] compress(string input)
        {
            ArrayList encoded_string = new ArrayList();


            int bitIDX = 0;
            byte inputByte = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                string key = img_key[input[i].ToString()];
                for (int j = 0; j < key.Length; ++j)
                {
                    int bitVal = input[i] == '0' ? 0 : 1;

                    // Mask input int with the input bit shifted right by bitval
                    inputByte = (byte)(inputByte | (bitVal << bitIDX));

                    ++bitIDX;
                    if (bitIDX > 7)
                    {
                        bitIDX = 0;
                        encoded_string.Add(inputByte);
                    }
                }
            }

            byte[] bytes = new byte[encoded_string.Count];

            for (int i = 0; i < encoded_string.Count; ++i)
            {
                bytes[i] = (byte) encoded_string[i];
            }

            return bytes;
        }
    }
}
