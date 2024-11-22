



public class AssemblyMachine3 : CraftingEntityWithModules
{
    #region Singleton
    private static Lazy<AssemblyMachine3> _instance = new(() => new());
    
    public static AssemblyMachine3 Instance => _instance.Value;
    #endregion

    public override string Name => "Assembly Machine 3";
    public override string UUID => "assemblyMachine3";  

    public override int ModuleCount => 4;

    public override float CraftingSpeed => 1.2f;

    public override List<Recipe> Recipes => throw new NotImplementedException();

}

 