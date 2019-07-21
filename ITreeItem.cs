namespace LaXiS.VantagePointTree
{
    public interface ITreeItem<T>
    {
        double DistanceFrom(T p);
    }
}