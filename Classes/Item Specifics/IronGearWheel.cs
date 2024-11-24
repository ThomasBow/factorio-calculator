


public class IronGearWheel : Item
{
    #region Singleton
    private static Lazy<IronGearWheel> _instance = new(() => new());
    
    public static IronGearWheel Instance => _instance.Value;
    #endregion

    public override string Name => "Iron Gear Wheel";
    public override string UUID => "ironGearWheel";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(MoltenIron.Instance, 10)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 1f
        ),
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(IronPlate.Instance, 2)
            ],
            craftingMachine: AssemblyMachine3.Instance,
            craftingTimeSeconds: 0.5f
        ),
    ];
}