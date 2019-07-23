namespace LaXiS.VantagePointTree
{
    public class TreeSearchResult<T>
    {
        public T Item { get; set; }
        public double Distance { get; set; }

        public TreeSearchResult(T item, double distance)
        {
            Item = item;
            Distance = distance;
        }

        public override string ToString()
        {
            return $"Item={{{Item}}} Distance={Distance}";
        }
    }
}