



public class SolidFuel : Item
{
    #region Singleton
    private static Lazy<SolidFuel> _instance = new(() => new());
    public static SolidFuel Instance => _instance.Value;
    #endregion

    public override string Name => "Solid Fuel";
    public override string UUID => "solidFuel";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1),
            ingredients: 
            [
                new(PetroleumGas.Instance, 1)
            ],
            craftingMachine: ChemicalPlant.Instance,
            craftingTimeSeconds: 1f
        ),
        new(
            result: new(Instance, 1),
            ingredients: 
            [
                new(LightOil.Instance, 1)
            ],
            craftingMachine: ChemicalPlant.Instance,
            craftingTimeSeconds: 1f
        ),
        new(
            result: new(Instance, 1),
            ingredients: 
            [
                new(HeavyOil.Instance, 1)
            ],
            craftingMachine: ChemicalPlant.Instance,
            craftingTimeSeconds: 1f
        ),
    ];
}