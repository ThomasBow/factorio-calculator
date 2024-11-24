



public class ElectromagneticPlant : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<ElectromagneticPlant> _instance = new(() => new());
    
    public static ElectromagneticPlant Instance => _instance.Value;
    #endregion
    
    public override string Name => "Electromagnetic Plant";
    public override string UUID => "electromagneticPlant";  

    public override bool IsIntermediate => false; 

    public override float CraftingSpeed => 2.0f;
    public override int ModuleCount => 5;
    public override float Productivity => 0.5f;

    public override List<Recipe> Recipes => throw new NotImplementedException();

}