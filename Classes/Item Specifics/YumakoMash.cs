



public class YumakoMash : Item
{
    #region Singleton
    private static Lazy<YumakoMash> _instance = new(() => new());
    public static YumakoMash Instance => _instance.Value;
    #endregion

    public override string Name => "Yumako Mash";
    public override string UUID => "yumakoMash";

    public override bool IsIntermediate => true; 

    public override List<Recipe> Recipes => 
    [
        new(
            results: 
            [
                new(Instance, 1),
                new(YumakoSeed.Instance, 0.02f)
            ],
            ingredients: 
            [
                new(Yumako.Instance, 1),
                new(Nutrient.Instance, 0.25f)
            ],
            craftingMachine: Biochamber.Instance,
            craftingTimeSeconds: 1f
        )
    ];
}