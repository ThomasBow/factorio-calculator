



public class PetroleumGas : Item
{
    #region Singleton
    private static Lazy<PetroleumGas> _instance = new(() => new());
    
    public static PetroleumGas Instance => _instance.Value;
    #endregion

    public override string Name => "Petroleum Gas";
    public override string UUID => "petroleumGas";

    public override bool IsIntermediate => true;

    public override List<Recipe> Recipes =>
    [
        new(
            results: [new(Instance, 90), new(LightOil.Instance, 20), new(PetroleumGas.Instance, 10)], 
            ingredients:
            [
                new(HeavyOil.Instance, 25),
                new(Coal.Instance, 10),
                new(Steam.Instance, 50)
            ],
            craftingMachine: OilRefinery.Instance,
            craftingTimeSeconds: 5f
        )
    ];
}