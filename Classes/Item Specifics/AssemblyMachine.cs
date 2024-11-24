



public class AssemblyMachine : CraftingEntity
{
    #region Singleton
    private static Lazy<AssemblyMachine> _instance = new(() => new());
    
    public static AssemblyMachine Instance => _instance.Value;
    #endregion

    public override string Name => "Assembly Machine";
    public override string UUID => "assemblyMachine"; 

    public override bool IsIntermediate => false; 

    public override float CraftingSpeed => .5f;

    public override List<Recipe> Recipes => throw new NotImplementedException();

}