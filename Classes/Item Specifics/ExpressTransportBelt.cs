



public class ExpressTransportBelt : Item
{
    #region Singleton
    private static Lazy<ExpressTransportBelt> _instance = new(() => new());
    
    public static ExpressTransportBelt Instance => _instance.Value;
    #endregion

    public override string Name => "Express Transport Belt";
    public override string UUID => "expressTransportBelt";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 1), 
            ingredients: 
            [
                new(IronGearWheel.Instance, 10), 
                new(FastTransportBelt.Instance, 1),
                new(Lubricant.Instance, 20),
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 0.5f
        ),
    ];
}