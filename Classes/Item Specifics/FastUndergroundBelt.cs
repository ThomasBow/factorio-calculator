



public class FastUndergroundBelt : Item
{
    #region Singleton
    private static Lazy<FastUndergroundBelt> _instance = new(() => new());
    
    public static FastUndergroundBelt Instance => _instance.Value;
    #endregion

    public override string Name => "Fast Underground Belt";
    public override string UUID => "fastUndergroundBelt";

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 2), 
            ingredients:
            [
                new(IronGearWheel.Instance, 40),
                new(UndergroundBelt.Instance, 2)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 2f
        ),
    ];
}