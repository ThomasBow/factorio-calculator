



public class CopperPlate : Item
{
    #region Singleton
    private static Lazy<CopperCable> _instance = new(() => new());
    
    public static CopperCable Instance => _instance.Value;
    #endregion

    public override string Name => "Copper Plate";
    public override string UUID => "copperPlate";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(this, 2), 
            ingredients:
            [
                new(CopperOre.Instance, 4),
            ],
            craftingMachine: new AssemblyMachine3(),
            craftingTimeSeconds: 6f
        ),
    ];

    private CopperPlate()
    {
        
    }
}