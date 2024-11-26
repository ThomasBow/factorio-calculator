



public class JellynutSeed : Item
{
    #region Singleton
    private static Lazy<JellynutSeed> _instance = new(() => new());
    public static JellynutSeed Instance => _instance.Value;
    #endregion

    public override string Name => "Jellynut Seed";
    public override string UUID => "jellynutSeed";

    public override bool IsIntermediate => false; 

    public override List<Recipe> Recipes => 
    [
        new(
            results: 
            [
                new(Jelly.Instance, 4),
                new(Instance, 0.02f)
            ],
            ingredients: 
            [
                new(Jellynut.Instance, 1)
            ],
            craftingMachine: Biochamber.Instance,
            craftingTimeSeconds: 1f
        )
    ];
}