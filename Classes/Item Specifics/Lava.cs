



public class Lava : Item
{
    #region Singleton
    private static Lazy<Lava> _instance = new(() => new());
    
    public static Lava Instance => _instance.Value;
    #endregion

    public override string Name => "Lava";
    public override string UUID => "lava";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 1), 
            ingredients: [],
            craftingMachine: OffshorePump.Instance,
            craftingTimeSeconds: 1f
        ),
    ];
}