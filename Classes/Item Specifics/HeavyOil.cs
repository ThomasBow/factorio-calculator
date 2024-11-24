



public class HeavyOil : Item
{
    #region Singleton
    private static Lazy<HeavyOil> _instance = new(() => new());
    
    public static HeavyOil Instance => _instance.Value;
    #endregion

    public override string Name => "Heavy Oil";
    public override string UUID => "heavyOil";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes =>
    [
        new(
            results: [new(Instance, 65), new(LightOil.Instance, 20), new(PetroleumGas.Instance, 10)], 
            ingredients:
            [
                new(Coal.Instance, 10),
                new(Steam.Instance, 50)
            ],
            craftingMachine: OilRefinery.Instance,
            craftingTimeSeconds: 5f
        )
    ];
}