



public class ProductivityModule2 : Module
{
    #region Singleton
    private static Lazy<ProductivityModule2> _instance = new(() => new());
    
    public static ProductivityModule2 Instance => _instance.Value;
    #endregion

    public override string Name => "Productivity Module 2";
    public override string UUID => "productivityModule2";

    public override bool IsIntermediate => false; 

    public override float ProductivityModifier => 0.06f;
    public override float SpeedModifier => -0.1f;
    
    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1),
            ingredients: 
            [
                new(AdvancedCircuit.Instance, 5),
                new(ProcessingUnit.Instance, 5),
            ],
            craftingMachine: AssemblyMachine3.Instance,
            craftingTimeSeconds: 30f
        ),
    ];
}