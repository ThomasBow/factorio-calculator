



public class TungstenOre : Ore
{
    #region Singleton
    private static Lazy<TungstenOre> _instance = new(() => new());
    
    public static TungstenOre Instance => _instance.Value;
    #endregion

    public override string Name => "Tungsten Ore";
    public override string UUID => "tungstenOre";

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 1), 
            ingredients: [],
            craftingMachine: BigMiningDrill.Instance,
            craftingTimeSeconds: 5f
        ),
    ];
}