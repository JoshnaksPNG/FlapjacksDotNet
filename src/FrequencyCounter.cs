namespace TextHiderDotNet.src
{
    internal class FrequencyCounter
    {
        private Dictionary<char, int> _map;

        public FrequencyCounter()
        {
            _map = new Dictionary<char, int>();
        }

        public FrequencyCounter(string input)
        {
            _map = new Dictionary<char, int>();
            add(input);
        }

        void add(string input)
        {
            for (int i = 0; i < input.Length; ++i)
            {
                char c = input[i];

                if (!_map.ContainsKey(c))
                {
                    _map[c] = 1;
                }
                else
                {
                    ++_map[c];
                }
            }
        }

        public void clear()
        {
            _map.Clear();
        }

        public int getFrequency(char c)
        {
            // If map has key
            if (_map.ContainsKey(c))
            {
                return _map[c];
            }

            // Else
            return -1;
        }
    }
}
