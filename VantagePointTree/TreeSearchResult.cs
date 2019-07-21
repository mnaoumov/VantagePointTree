namespace LaXiS.VantagePointTree
{
    public class TreeSearchResult<T>
    {
        public T Item;
        public double Distance;

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