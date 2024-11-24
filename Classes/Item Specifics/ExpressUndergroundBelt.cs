



public class ExpressUndergroundBelt : Item
{
    #region Singleton
    private static Lazy<ExpressUndergroundBelt> _instance = new(() => new());
    
    public static ExpressUndergroundBelt Instance => _instance.Value;
    #endregion

    public override string Name => "Express Underground Belt";
    public override string UUID => "expressUndergroundBelt";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 2), 
            ingredients:
            [
                new(IronGearWheel.Instance, 80),
                new(FastUndergroundBelt.Instance, 2),
                new(Lubricant.Instance, 40)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 2f
        ),
    ];
}