



public class CopperCable : Item
{
    #region Singleton
    private static Lazy<CopperCable> _instance = new(() => new());
    
    public static CopperCable Instance => _instance.Value;
    #endregion

    public override string Name => "Copper Cable";
    public override string UUID => "copperCable";

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(this, 2), 
            ingredients:
            [
                new(CopperPlate.Instance, 1)
            ],
            craftingMachine: AssemblyMachine3.Instance,
            craftingTimeSeconds: 0.5f
        ),
    ];
}