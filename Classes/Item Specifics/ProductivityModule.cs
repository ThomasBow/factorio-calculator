



public class ProductivityModule : Module
{
    #region Singleton
    private static Lazy<ProductivityModule> _instance = new(() => new());
    
    public static ProductivityModule Instance => _instance.Value;
    #endregion

    public override string Name => "Productivity Module";
    public override string UUID => "productivityModule";

    public override bool IsIntermediate => false; 

    public override float ProductivityModifier => 0.04f;
    public override float SpeedModifier => -0.05f;

    public override List<Recipe> Recipes => 
    [    
        new(
            result: new(Instance, 1),
            ingredients: 
            [
                new(AdvancedCircuit.Instance, 5),
                new(ElectronicCircuit.Instance, 5),
            ],
            craftingMachine: AssemblyMachine3.Instance,
            craftingTimeSeconds: 15f
        ),
    ];
}