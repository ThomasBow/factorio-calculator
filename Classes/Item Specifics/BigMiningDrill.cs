


public class BigMiningDrill : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<BigMiningDrill> _instance = new(() => new());
    
    public static BigMiningDrill Instance => _instance.Value;
    #endregion

    public override string Name => "Big Mining Drill";
    public override string UUID => "bigMiningDrill";
    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(IronPlate.Instance, 10),
                //new(IronGearWheel.Instance, 5),
                //new(ElectricMotor.Instance, 3),
                new(AdvancedCircuit.Instance, 2)
            ],
            craftingMachine: new AssemblyMachine3(),
            craftingTimeSeconds: 10f
        ),        
    ];

    public override int ModuleCount => 4;
    public override float CraftingSpeed => 2.5f;

    public override float Productivity => 0.5f;
}