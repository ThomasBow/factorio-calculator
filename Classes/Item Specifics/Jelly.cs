



public class Jelly : Item
{
    #region Singleton
    private static Lazy<Jelly> _instance = new(() => new());
    public static Jelly Instance => _instance.Value;
    #endregion

    public override string Name => "Jelly";
    public override string UUID => "jelly";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            results: 
            [
                new(Instance, 4),
                new(JellynutSeed.Instance, 0.02f)
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