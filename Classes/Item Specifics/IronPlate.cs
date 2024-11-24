



public class IronPlate : Item 
{
    #region Singleton
    private static Lazy<IronPlate> _instance = new(() => new());
    
    public static IronPlate Instance => _instance.Value;
    #endregion

    public override string Name => "Iron Plate";
    public override string UUID => "ironPlate";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 2), 
            ingredients:
            [
                new(MoltenIron.Instance, 20)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 3.2f
        ),
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(IronOre.Instance, 1)
            ],
            craftingMachine: ElectricFurnace.Instance,
            craftingTimeSeconds: 3.2f
        ),
    ];

    private IronPlate()
    { 

    }
}