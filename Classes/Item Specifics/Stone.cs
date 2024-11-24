



public class Stone : Ore
{
    #region Singleton
    private static Lazy<Stone> _instance = new(() => new());
    
    public static Stone Instance => _instance.Value;
    #endregion

    public override string Name => "Stone";
    public override string UUID => "stone";

    public override bool IsIntermediate => true;

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