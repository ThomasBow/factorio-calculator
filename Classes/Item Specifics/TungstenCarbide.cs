
public class TungstenCarbide : Item
{
    #region Singleton
    private static Lazy<TungstenCarbide> _instance = new(() => new());
    
    public static TungstenCarbide Instance => _instance.Value;
    #endregion

    public override string Name => "Tungsten Carbide";
    public override string UUID => "tungstenCarbide";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(Carbon.Instance, 1),
                new(TungstenOre.Instance, 2),
                new(SulfuricAcid.Instance, 10)
            ],
            craftingMachine: AssemblyMachine3.Instance,
            craftingTimeSeconds: 1f
        ),
    ];
}