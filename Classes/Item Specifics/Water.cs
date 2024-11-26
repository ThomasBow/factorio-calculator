



public class Water : Item
{
    #region Singleton
    private static Lazy<Water> _instance = new(() => new());
    public static Water Instance => _instance.Value;
    #endregion

    public override string Name => "Water";
    public override string UUID => "water";

    public override bool IsIntermediate => false; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1200),
            ingredients: [],
            craftingMachine: OffshorePump.Instance,
            craftingTimeSeconds: 1f
        )
    ];
}