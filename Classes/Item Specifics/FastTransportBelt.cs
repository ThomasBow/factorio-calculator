


public class FastTransportBelt : Item
{
    #region Singleton
    private static Lazy<FastTransportBelt> _instance = new(() => new());
    
    public static FastTransportBelt Instance => _instance.Value;
    #endregion

    public override string Name => "Fast Transport Belt";
    public override string UUID => "fastTransportBelt";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(this, 1), 
            ingredients:
            [
                new(IronGearWheel.Instance, 5),
                new(TransportBelt.Instance, 1)  
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 0.5f
        ),
    ];
}