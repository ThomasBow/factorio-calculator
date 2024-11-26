



public class Jellynut : Item
{
    #region Singleton
    private static Lazy<Jellynut> _instance = new(() => new());
    public static Jellynut Instance => _instance.Value;
    #endregion

    public override string Name => "Jellynut";
    public override string UUID => "jellynut";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 50),
            ingredients: 
            [
                new(Jellystem.Instance, 1)
            ],
            craftingMachine: AgriculturalTower.Instance,
            craftingTimeSeconds: 1f
        )
    ];
}