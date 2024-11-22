



public abstract class CraftingEntityWithModules : CraftingEntity
{
    public abstract int ModuleCount { get; }
    public Module[]? Modules { get; set; }

    public void InsertModules(Module[] modules) 
    {
        if (modules.Length > ModuleCount)
        {
            throw new ArgumentException($"{this} can only have {ModuleCount} modules");
        }

        Modules = modules;
    } 
}