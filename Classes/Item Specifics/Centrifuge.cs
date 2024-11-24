



public class Centrifuge : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<Centrifuge> _instance = new(() => new());
    
    public static Centrifuge Instance => _instance.Value;
    #endregion

    public override string Name => "Centrifuge";
    public override string UUID => "centrifuge";  

    public override bool IsIntermediate => false; 

    public override int ModuleCount => 2;

    public override float CraftingSpeed => 1.0f;

    public override List<Recipe> Recipes => throw new NotImplementedException();

}