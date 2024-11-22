



public class Coal : Ore
{
    #region Singleton
    private static Lazy<Coal> _instance = new(() => new());
    
    public static Coal Instance => _instance.Value;
    #endregion

    public override string Name => "Coal";
    public override string UUID => "coal";

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 1), 
            ingredients: [],
            craftingMachine: BigMiningDrill.Instance,
            craftingTimeSeconds: 1f
        ),
    ];
}