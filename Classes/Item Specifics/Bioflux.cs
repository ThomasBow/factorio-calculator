



public class Bioflux : Item
{
    #region Singleton
    private static Lazy<Bioflux> _instance = new(() => new());
    public static Bioflux Instance => _instance.Value;
    #endregion

    public override string Name => "Bioflux";
    public override string UUID => "bioflux";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            result: new(Instance, 1),
            ingredients: 
            [
                new(YumakoMash.Instance, 15),
                new(Jelly.Instance, 12)
            ],
            craftingMachine: Biochamber.Instance,
            craftingTimeSeconds: 17f
        )
    ];
}