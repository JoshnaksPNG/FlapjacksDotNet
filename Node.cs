using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Node
    {
        Node right;
        Node left;
        string name;
        int frequency;

        // Constructors
        public Node()
        {

        }

        public Node(Node left, Node right)
        {
            this.right = right;
            this.left = left;
        }

        public Node(Node left, Node right, string name, int frequency) : this(left, right)
        {
            this.name = name;
            this.frequency = frequency;
        }

        public Node(string name, int frequency)
        {
            this.name = name;
            this.frequency = frequency;
        }

        public Node(Node left, Node right, int frequency)
        {
            this.left = left;
            this.right = right;
            this.frequency = frequency;
        }

        // Setters
        public void setRight(Node n)
        {
            right = n;
        }

        public void setLeft(Node n)
        {
            left = n;
        }

        public void setChildren(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        // Getters
        public Node getRight()
        {
            return right;
        }

        public Node getLeft()
        {
            return left;
        }

        public string getName()
        {
            return name;
        }

        public int getFrequency()
        {
            return frequency;
        }
    }
}
