



public class Plastic : Item
{
    #region Singleton
    private static Lazy<Plastic> _instance = new(() => new());
    
    public static Plastic Instance => _instance.Value;
    #endregion

    public override string Name => "Plastic";
    public override string UUID => "plastic";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => throw new NotImplementedException();
}