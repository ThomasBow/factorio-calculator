



public class ProcessingUnit : Item
{
    #region Singleton
    private static Lazy<ProcessingUnit> _instance = new(() => new());
    
    public static ProcessingUnit Instance => _instance.Value;
    #endregion

    public override string Name => "Processing Unit";
    public override string UUID => "processingUnit";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [        
        new(
            result: new(Instance, 1),
            ingredients: 
            [
                new(ElectronicCircuit.Instance, 20),
                new(AdvancedCircuit.Instance, 2),
                new(SulfuricAcid.Instance, 5)
            ],
            craftingMachine: AssemblyMachine3.Instance,
            craftingTimeSeconds: 10f
        ),
    ];
}