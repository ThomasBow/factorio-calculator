




public class WoodenChest : Item
{
    #region Singleton
    private static Lazy<WoodenChest> _instance = new(() => new());
    
    public static WoodenChest Instance => _instance.Value;
    #endregion

    public override string Name => "Wooden Chest";
    public override string UUID => "woodenChest";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => [
        new(
            result: new(Instance, 1),
            ingredient: new(Wood.Instance, 2),
            craftingMachine: AssemblyMachine.Instance,
            craftingTimeSeconds: 0.5f
        ),
        new(
            result: new(Instance, 1),
            ingredient: new(Wood.Instance, 2),
            craftingMachine: AssemblyMachine2.Instance,
            craftingTimeSeconds: 0.5f
        ),
        new(
            result: new(Instance, 1),
            ingredient: new(Wood.Instance, 2),
            craftingMachine: AssemblyMachine3.Instance,
            craftingTimeSeconds: 0.5f
        ),
    ];
}