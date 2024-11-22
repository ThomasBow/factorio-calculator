



public class ElectricMiningDrill : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<ElectricMiningDrill> _instance = new(() => new());
    
    public static ElectricMiningDrill Instance => _instance.Value;
    #endregion

    public override string Name => "Electric Mining Drill";
    public override string UUID => "electricMiningDrill";
    public override List<Recipe> Recipes => 
    [
        
    ];

    public override int ModuleCount => 3;
    public override float CraftingSpeed => 1.0f;
}