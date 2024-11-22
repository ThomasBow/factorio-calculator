



public class CopperOre : Item
{
    #region Singleton
    private static Lazy<CopperOre> _instance = new(() => new());
    
    public static CopperOre Instance => _instance.Value;
    #endregion

    public override string Name => "Copper Ore";
    public override string UUID => "copperOre";
    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1), 
            ingredients: [],
            craftingMachine: ElectricMiningDrill.Instance,
            craftingTimeSeconds: 2f
        ),
    ];

    
}