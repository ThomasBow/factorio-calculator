



public class Foundry : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<Foundry> _instance = new(() => new());
    
    public static Foundry Instance => _instance.Value;
    #endregion
    
    public override string Name => "Foundry";
    public override string UUID => "foundry";  

    public override int ModuleCount => 4;
    public override float CraftingSpeed => 4.0f;
    public override float Productivity => 0.5f;

    public override List<Recipe> Recipes => throw new NotImplementedException();

}