



public class MoltenCopper : Item
{
    #region Singleton
    private static Lazy<MoltenCopper> _instance = new(() => new());
    
    public static MoltenCopper Instance => _instance.Value;
    #endregion

    public override string Name => "Molten Copper";
    public override string UUID => "moltenCopper";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes =>
    [
        new(
            results: [new(Instance, 250), new(Stone.Instance, 15)], 
            ingredients:
            [
                new(Calcite.Instance, 1),
                new(Lava.Instance, 500)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 16f
        ),
        new(
            result: new(Instance, 500), 
            ingredients:
            [
                new(CopperOre.Instance, 50),
                new(Calcite.Instance, 1)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 32f
        ),
    ];
}