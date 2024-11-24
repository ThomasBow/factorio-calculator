


public class TransportBelt : Item
{
    #region Singleton
    private static Lazy<TransportBelt> _instance = new(() => new());
    
    public static TransportBelt Instance => _instance.Value;
    #endregion

    public override string Name => "Transport Belt";
    public override string UUID => "transportBelt";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(this, 2), 
            ingredients:
            [
                new(IronGearWheel.Instance, 1),
                new(IronPlate.Instance, 1)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 0.5f
        ),
    ];
}