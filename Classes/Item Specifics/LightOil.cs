



public class LightOil : Item
{
    #region Singleton
    private static Lazy<LightOil> _instance = new(() => new());
    
    public static LightOil Instance => _instance.Value;
    #endregion

    public override string Name => "Light Oil";
    public override string UUID => "lightOil";

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 1), 
            ingredients: [],
            craftingMachine: OilRefinery.Instance,
            craftingTimeSeconds: 5f
        ),
    ];
}