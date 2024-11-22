




public class IronOre : Ore
{
    #region Singleton
    private static Lazy<IronOre> _instance = new(() => new());
    public static IronOre Instance => _instance.Value;
    #endregion

    public override string Name => "Iron Ore";

    public override string UUID => "ironOre";

    private IronOre()
    {

    }

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 2),
            ingredients: [],
            craftingMachine: ElectricMiningDrill.Instance,
            craftingTimeSeconds: 1f
        ),
    ];
}