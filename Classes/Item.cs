


public abstract class Item
{
    public abstract string Name { get; }
    public abstract string UUID { get; }

    public abstract bool IsIntermediate { get; }

    public abstract List<Recipe> Recipes { get; }

    public override string ToString()
    {
        return Name;
    }
}