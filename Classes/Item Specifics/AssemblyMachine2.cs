



public class AssemblyMachine2 : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<AssemblyMachine2> _instance = new(() => new());
    
    public static AssemblyMachine2 Instance => _instance.Value;
    #endregion

    public override string Name => "Assembly Machine 2";
    public override string UUID => "AssemblyMachine2";  

    public override float CraftingSpeed => 0.75f;
    public override int ModuleCount => 4;

    public override List<Recipe> Recipes => throw new NotImplementedException();

}