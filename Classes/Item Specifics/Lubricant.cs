



public class Lubricant : Item
{
    #region Singleton
    private static Lazy<Lubricant> _instance = new(() => new());
    
    public static Lubricant Instance => _instance.Value;
    #endregion

    public override string Name => "Lubricant";
    public override string UUID => "lubricant";

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 10), 
            ingredient: new(HeavyOil.Instance, 10),
            craftingMachine: ChemicalPlant.Instance,
            craftingTimeSeconds: 1f
        )
    ];
}