



public class TurboUndergroundBelt : Item
{
    #region Singleton
    private static Lazy<TurboUndergroundBelt> _instance = new(() => new());
    
    public static TurboUndergroundBelt Instance => _instance.Value;
    #endregion

    public override string Name => "Turbo Underground Belt";
    public override string UUID => "turboUndergroundBelt";

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 2), 
            ingredients:
            [
                new(TungstenPlate.Instance, 40),
                new(ExpressUndergroundBelt.Instance, 2),
                new(Lubricant.Instance, 40)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 2f
        ),
    ];
}