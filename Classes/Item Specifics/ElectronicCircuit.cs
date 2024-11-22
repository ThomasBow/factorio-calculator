



public class ElectronicCircuit : Item
{
    #region Singleton
    private static Lazy<ElectronicCircuit> _instance = new(() => new());
    
    public static ElectronicCircuit Instance => _instance.Value;
    #endregion

    public override string Name => "Electronic Circuit";
    public override string UUID => "electronicCircuit";

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(CopperCable.Instance, 3),
                new(IronPlate.Instance, 1)
            ],
            craftingMachine: new AssemblyMachine(),
            craftingTimeSeconds: 1f
        ),
    ];

    private ElectronicCircuit()
    { 

    }
}