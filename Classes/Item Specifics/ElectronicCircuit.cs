



public class ElectronicCircuit : Item
{
    #region Singleton
    private static Lazy<ElectronicCircuit> _instance = new(() => new());
    
    public static ElectronicCircuit Instance => _instance.Value;
    #endregion

    public override string Name => "Electronic Circuit";
    public override string UUID => "electronicCircuit";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(CopperCable.Instance, 3),
                new(IronPlate.Instance, 1)
            ],
            craftingMachine: AssemblyMachine.Instance,
            craftingTimeSeconds: 1f
        ),
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(CopperCable.Instance, 3),
                new(IronPlate.Instance, 1)
            ],
            craftingMachine: AssemblyMachine2.Instance,
            craftingTimeSeconds: 1f
        ),
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(CopperCable.Instance, 3),
                new(IronPlate.Instance, 1)
            ],
            craftingMachine: AssemblyMachine3.Instance,
            craftingTimeSeconds: 1f
        ),
    ];
}