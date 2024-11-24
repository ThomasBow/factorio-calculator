



public class ChemicalPlant : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<ChemicalPlant> _instance = new(() => new());
    
    public static ChemicalPlant Instance => _instance.Value;
    #endregion

    public override string Name => "Chemical Plant";
    public override string UUID => "chemicalPlant";  

    public override bool IsIntermediate => false; 

    public override int ModuleCount => 3;

    public override float CraftingSpeed => 1.0f;

    public override List<Recipe> Recipes => throw new NotImplementedException();

}