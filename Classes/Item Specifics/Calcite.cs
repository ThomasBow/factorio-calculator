


public class Calcite : Ore
{
    #region Singleton
    private static Lazy<Calcite> _instance = new(() => new());
    
    public static Calcite Instance => _instance.Value;
    #endregion

    public override string Name => "Calcite";
    public override string UUID => "calcite";

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