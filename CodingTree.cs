namespace WinFormsApp1
{
    internal class CodingTree
    {
        Node root;

        public Node current;

        public Dictionary<string, string> encodeMap;

        public CodingTree()
        {
            root = new Node();
        }

        public void build(string input)
        {
            FrequencyCounter counter = new FrequencyCounter(input);
            PriorityQueue<char, int> heap = new PriorityQueue<char, int>();
            Queue<char> queue = new Queue<char>();

            PriorityQueue<Node, int> forest = new PriorityQueue<Node, int>();

            for (int i = 0; i < input.Length; ++i)
            {
                char c = input[i];
                int occurences = counter.getFrequency(c);
                Node n = new Node(c.ToString(), occurences);

                if (!queue.Contains(c))
                {
                    heap.Enqueue(c, occurences);
                    queue.Enqueue(c);

                    forest.Enqueue(n, occurences);
                }
            }

            while (forest.Count > 1)
            {
                Node buf1 = forest.Dequeue();
                int occ1 = buf1.getFrequency();

                Node buf2 = forest.Dequeue();
                int occ2 = buf2.getFrequency();

                Node parent = new Node(buf1, buf2, occ1 + occ2);
                forest.Enqueue(parent, occ1 + occ2);
            }
            
            root = forest.Dequeue();
            current = root;
        }

        public bool onLeaf()
        {
            return current.getName() != null;
        }

        public string getLeaf()
        {
            string name = current.getName();
            current = root;
            return name;
        }

        public void goLeft()
        {
            if (current.getLeft != null)
            {
                current = current.getLeft();
            }
        }

        public void goRight()
        {
            if (current.getRight != null)
            {
                current = current.getRight();
            }
        }

        public void goRoot() 
        {
            current = root;
        }

        public void exploreNode(Node node, string input)
        {
            if (encodeMap == null)
            {
                encodeMap = new Dictionary<string, string> ();
            }

            if (node.getName() != null)
            {
                encodeMap.Add(node.getName(), input);
                return;
            }

            if (node.getLeft() != null)
            {
                exploreNode(node.getLeft(), input + "0");
            }

            if (node.getRight() != null)
            {
                exploreNode(node.getRight(), input + "1");
            }
        }
    }
}
