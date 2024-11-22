







public class CryogenicPlant : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<CryogenicPlant> _instance = new(() => new());
    
    public static CryogenicPlant Instance => _instance.Value;
    #endregion

    public override string Name => "Cryogenic Plant";
    public override string UUID => "cryogenicPlant";  

    public override int ModuleCount => 2;

    public override float CraftingSpeed => 8.0f;

    public override List<Recipe> Recipes => throw new NotImplementedException();

}