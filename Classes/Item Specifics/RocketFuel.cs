



public class RocketFuel : Item
{
    #region Singleton
    private static Lazy<RocketFuel> _instance = new(() => new());
    public static RocketFuel Instance => _instance.Value;
    #endregion

    public override string Name => "Rocket Fuel";
    public override string UUID => "rocketFuel";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1),
            ingredients: 
            [
                new(LightOil.Instance, 10),
                new(SolidFuel.Instance, 10)
            ],
            craftingMachine: AssemblyMachine3.Instance,
            craftingTimeSeconds: 1f
        ),
    ];
}