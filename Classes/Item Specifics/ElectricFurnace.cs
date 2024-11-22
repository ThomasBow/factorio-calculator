



public class ElectricFurnace : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<ElectricFurnace> _instance = new(() => new());
    
    public static ElectricFurnace Instance => _instance.Value;
    #endregion

    public override string Name => "Electric Furnace";
    public override string UUID => "electricFurnace";
    public override List<Recipe> Recipes => 
    [
        
    ];

    public override int ModuleCount => 2;
    public override float CraftingSpeed => 2f;
}