



public class Jellystem : Item
{
    #region Singleton
    private static Lazy<Jellystem> _instance = new(() => new());
    public static Jellystem Instance => _instance.Value;
    #endregion

    public override string Name => "Jellystem";
    public override string UUID => "jellystem";

    public override bool IsIntermediate => false; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1),
            ingredients: 
            [
                new(JellynutSeed.Instance, 1)
            ],
            craftingMachine: AgriculturalTower.Instance,
            craftingTimeSeconds: 25f
        )
    ];
}