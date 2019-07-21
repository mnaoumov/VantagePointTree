using System;
using System.Collections.Generic;

namespace LaXiS.VantagePointTree
{
    public class VantagePointTree<T> where T : ITreeItem<T>
    {
        private TreeNode<T> _rootNode;
        private Random _random;

        public VantagePointTree()
        {
            _random = new Random();
        }

        public VantagePointTree(List<T> items) : this()
        {
            Build(items);
        }

        public void Build(List<T> items)
        {
            _rootNode = _buildRecursive(items);
            // _rootNode.Dump();
        }

        private TreeNode<T> _buildRecursive(List<T> items)
        {
            if (items.Count == 0)
                return null;

            TreeNode<T> node = new TreeNode<T>();

            if (items.Count == 1)
            {
                node.Item = items[0];
            }
            else
            {
                // Swap the first element with a random other element
                int randomIndex = _random.Next(1, items.Count);
                items.Swap(0, randomIndex);

                // Save current node item and copy list without this item
                node.Item = items[0];
                items = items.GetRange(1, items.Count - 1);

                // Get median item from list (sort by distance from current node, split at median item)
                // TODO optimizable (see selection algorithm)
                items.Sort(new TreeItemComparer<T>(node.Item));
                int medianIndex = items.Count / 2 - 1;
                if (medianIndex < 0) medianIndex = 0;
                node.Radius = node.Item.DistanceFrom(items[medianIndex]);

                node.LeftNode = _buildRecursive(items.GetRange(0, medianIndex + 1));
                node.RightNode = _buildRecursive(items.GetRange(medianIndex + 1, items.Count - medianIndex - 1));
            }

            return node;
        }

        public List<TreeSearchResult<T>> Search(T target, int k)
        {
            var results = new List<TreeSearchResult<T>>();
            double tau = double.MaxValue;

            _searchRecursive(target, k, _rootNode, ref tau, results);

            return results;
        }

        // k = number of nearest neighbors to search for
        // tau = longest distance in current results, must be initialized to double.MaxValue and passed as a reference
        private void _searchRecursive(T target, int k, TreeNode<T> node, ref double tau, List<TreeSearchResult<T>> results)
        {
            if (node == null)
                return;

            double distance = target.DistanceFrom(node.Item);

            // If distance to current node is shorter than longest distance currently in results
            if (distance < tau)
            {
                // Remove result with longest distance if results 
                if (results.Count == k)
                    results.RemoveAt(results.Count - 1);

                results.Add(new TreeSearchResult<T> { Item = node.Item, Distance = distance });

                if (results.Count == k)
                {
                    // Sort results by ascending distance and update longest distance in results (tau)
                    results.Sort((a, b) => Comparer<double>.Default.Compare(a.Distance, b.Distance));
                    tau = results[results.Count - 1].Distance;
                }
            }

            if (distance < node.Radius)
            {
                if (distance - tau < node.Radius)
                    _searchRecursive(target, k, node.LeftNode, ref tau, results);
                if (distance + tau >= node.Radius)
                    _searchRecursive(target, k, node.RightNode, ref tau, results);
            }
            else
            {
                if (distance + tau >= node.Radius)
                    _searchRecursive(target, k, node.RightNode, ref tau, results);
                if (distance - tau < node.Radius)
                    _searchRecursive(target, k, node.LeftNode, ref tau, results);
            }
        }
    }
}