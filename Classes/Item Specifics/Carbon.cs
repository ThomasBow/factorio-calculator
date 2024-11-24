
public class Carbon : Item
{
    #region Singleton
    private static Lazy<Carbon> _instance = new(() => new());
    
    public static Carbon Instance => _instance.Value;
    #endregion

    public override string Name => "Carbon";
    public override string UUID => "carbon";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(Coal.Instance, 2),
                new(SulfuricAcid.Instance, 20)
            ],
            craftingMachine: ChemicalPlant.Instance,
            craftingTimeSeconds: 1f
        ),
    ];
}