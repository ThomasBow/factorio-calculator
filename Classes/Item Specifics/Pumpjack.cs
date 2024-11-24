



public class Pumpjack : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<Pumpjack> _instance = new(() => new());
    
    public static Pumpjack Instance => _instance.Value;
    #endregion

    public override string Name => "Pumpjack";
    public override string UUID => "pumpjack";

    public override bool IsIntermediate => false; 

    public override float CraftingSpeed => 1.0f;
    public override int ModuleCount => 2;
    
    public override List<Recipe> Recipes => throw new NotImplementedException();
}