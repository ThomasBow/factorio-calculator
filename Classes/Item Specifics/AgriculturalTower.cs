



public class AgriculturalTower : CraftingEntity
{
    #region Singleton
    private static Lazy<AgriculturalTower> _instance = new(() => new());
    public static AgriculturalTower Instance => _instance.Value;
    #endregion

    public override string Name => "Agricultural Tower";
    public override string UUID => "agriculturalTower";

    public override bool IsIntermediate => false;

    public override float CraftingSpeed => 25f;

    public override List<Recipe> Recipes => 
    [
        
    ];
}