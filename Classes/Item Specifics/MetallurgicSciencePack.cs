
public class MetallurgicSciencePack : Item
{
    #region Singleton
    private static Lazy<MetallurgicSciencePack> _instance = new(() => new());
    
    public static MetallurgicSciencePack Instance => _instance.Value;
    #endregion

    public override string Name => "Metallurgic Science Pack";
    public override string UUID => "metallurgicSciencePack";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(TungstenCarbide.Instance, 3),
                new(TungstenPlate.Instance, 2),
                new(MoltenCopper.Instance, 200)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 1f
        ),
    ];
}