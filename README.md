
# VantagePointTree

C# implementation of a vantage-point tree

## Details

The project is based on .NET Core 2.2 and can be easily run in Visual Studio Code.

The VantagePointTree class is generic and can accept any item type that implements `ITreeItem<T>` (for the `DistanceFrom` distance calculation method; see class `Point` in `Program.cs`).

Currently it is only possible to build the tree from a list of items and to search it; insertion and deletion are on my TODO list.

## References and inspirations

- https://en.wikipedia.org/wiki/Vantage-point_tree
- http://stevehanov.ca/blog/?id=130
- https://fribbels.github.io/vptree/writeup
- https://github.com/mcraiha/CSharp-vptree
