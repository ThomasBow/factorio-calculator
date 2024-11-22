



public class OilRefinery : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<OilRefinery> _instance = new(() => new());
    
    public static OilRefinery Instance => _instance.Value;
    #endregion

    public override string Name => "Oil Refinary";
    public override string UUID => "oilRefinary";  

    public override int ModuleCount => 3;

    public override float CraftingSpeed => 1.0f;

    public override List<Recipe> Recipes => throw new NotImplementedException();

}