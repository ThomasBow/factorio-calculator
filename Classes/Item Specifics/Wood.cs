



public class Wood : Item
{
    #region Singleton
    private static Lazy<Wood> _instance = new(() => new());
    
    public static Wood Instance => _instance.Value;
    #endregion

    public override string Name => "Wood";
    public override string UUID => "wood";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => new()
    {
        new(
            result: new(Instance, 1),
            ingredients: [],
            craftingMachine: AssemblyMachine.Instance,
            craftingTimeSeconds: 0f
        )
    };
}