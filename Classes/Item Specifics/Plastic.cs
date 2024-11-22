



public class Plastic : Item
{
    #region Singleton
    private static Lazy<Plastic> _instance = new(() => new());
    
    public static Plastic Instance => _instance.Value;
    #endregion

    public override string Name { get; } = "Plastic";
    public override string UUID { get; } = "plastic";

    public override List<Recipe> Recipes => throw new NotImplementedException();

    public Plastic() : base() 
    { 

    }
}