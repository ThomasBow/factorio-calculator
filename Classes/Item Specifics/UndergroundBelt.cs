



public class UndergroundBelt : Item
{
    #region Singleton
    private static Lazy<UndergroundBelt> _instance = new(() => new());
    
    public static UndergroundBelt Instance => _instance.Value;
    #endregion

    public override string Name => "Underground Belt";
    public override string UUID => "undergroundBelt";

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 2), 
            ingredients:
            [
                new(TransportBelt.Instance, 5),
                new(IronPlate.Instance, 10)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 1f
        ),
    ];
}