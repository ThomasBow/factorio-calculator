



public class Steam : Item
{
    #region Singleton
    private static Lazy<Steam> _instance = new(() => new());
    
    public static Steam Instance => _instance.Value;
    #endregion

    public override string Name => "Steam";
    public override string UUID => "steam";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 10000), 
            ingredients: 
            [
                new(Calcite.Instance, 1),
                new(SulfuricAcid.Instance, 1000),
            ],
            craftingMachine: ChemicalPlant.Instance,
            craftingTimeSeconds: 5f
        )
    ];
}