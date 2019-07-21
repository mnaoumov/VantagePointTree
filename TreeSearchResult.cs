namespace LaXiS.VantagePointTree
{
    public class TreeSearchResult<T>
    {
        public T Item;
        public double Distance;

        public override string ToString()
        {
            return $"Item={{{Item}}} Distance={Distance}";
        }
    }
}