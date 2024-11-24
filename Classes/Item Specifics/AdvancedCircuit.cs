



public class AdvancedCircuit : Item
{
    #region Singleton
    private static Lazy<AdvancedCircuit> _instance = new(() => new());
    
    public static AdvancedCircuit Instance => _instance.Value;
    #endregion

    public override string Name => "Advanced Circuit";
    public override string UUID => "advancedCircuit";

    public override bool IsIntermediate => true;

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(CopperCable.Instance, 4),
                new(ElectronicCircuit.Instance, 2),
                new(Plastic.Instance, 2)
            ],
            craftingMachine: AssemblyMachine3.Instance,
            craftingTimeSeconds: 6f
        ),
    ];
}