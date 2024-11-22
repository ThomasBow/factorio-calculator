



public class SulfuricAcid : Item
{
    #region Singleton
    private static Lazy<SulfuricAcid> _instance = new(() => new());
    
    public static SulfuricAcid Instance => _instance.Value;
    #endregion

    public override string Name => "Sulfuric Acid";
    public override string UUID => "sulfuricAcid";

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 10), 
            ingredients: [],
            craftingMachine: Pumpjack.Instance,
            craftingTimeSeconds: 1f
        ),
    ];
}