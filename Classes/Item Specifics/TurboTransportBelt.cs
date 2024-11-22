



public class TurboTransportBelt : Item
{
    #region Singleton
    private static Lazy<TurboTransportBelt> _instance = new(() => new());
    
    public static TurboTransportBelt Instance => _instance.Value;
    #endregion

    public override string Name => "Turbo Transport Belt";
    public override string UUID => "turboTransportBelt";

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(TungstenPlate.Instance, 5),
                new(ExpressTransportBelt.Instance, 1),
                new(Lubricant.Instance, 20)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 0.5f
        ),
    ];
}