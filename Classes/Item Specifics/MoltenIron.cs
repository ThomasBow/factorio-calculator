



public class MoltenIron : Item
{
    #region Singleton
    private static Lazy<MoltenIron> _instance = new(() => new());
    
    public static MoltenIron Instance => _instance.Value;
    #endregion

    public override string Name => "Molten Iron";
    public override string UUID => "moltenIron";

    public override List<Recipe> Recipes =>
    [
        new(
            results: [new(Instance, 250), new(Stone.Instance, 10)], 
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
                new(IronOre.Instance, 50),
                new(Calcite.Instance, 1)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 32f
        ),
    ];
}