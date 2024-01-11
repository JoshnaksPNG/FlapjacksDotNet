namespace WinFormsApp1
{
    internal class FrequencyCounter
    {
        private Dictionary<char, int> _map;

        public FrequencyCounter()
        {
            _map = new Dictionary<char, int>();
        }

        public FrequencyCounter(String input)
        {
            _map = new Dictionary<char, int>();
            this.add(input);
        }

        void add(String input)
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
