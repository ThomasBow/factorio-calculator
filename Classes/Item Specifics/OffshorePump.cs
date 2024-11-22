




public class OffshorePump : CraftingEntity
{
    #region Singleton
    private static Lazy<OffshorePump> _instance = new(() => new());
    
    public static OffshorePump Instance => _instance.Value;
    #endregion

    public override string Name => "Offshore Pump";
    public override string UUID => "offshorePump";

    public override float CraftingSpeed => 1200.0f;

    public override List<Recipe> Recipes => throw new NotImplementedException();
}