







public class Biochamber : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<Biochamber> _instance = new(() => new());
    
    public static Biochamber Instance => _instance.Value;
    #endregion
    
    public override string Name => "Biochamber";
    public override string UUID => "biochamber"; 

    public override bool IsIntermediate => false;  

    public override float CraftingSpeed => 2.0f;
    public override int ModuleCount => 4;
    public override float Productivity => 0.5f;

    public override List<Recipe> Recipes => throw new NotImplementedException();
    
}