using System;

namespace LaXiS.VantagePointTree
{
    public class TreeNode<T> where T : ITreeItem<T>
    {
        public T Item { get; set; }
        public double Radius { get; set; }
        public TreeNode<T> LeftNode { get; set; }
        public TreeNode<T> RightNode { get; set; }

        public void Dump(int step = 0)
        {
            Console.WriteLine($"{new String(' ', step * 2)}{Item} Radius:{Radius}");
            if (LeftNode != null)
                LeftNode.Dump(step + 1);
            if (RightNode != null)
                RightNode.Dump(step + 1);
        }
    }
}