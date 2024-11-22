


public abstract class CraftingEntity : Item
{   
    public abstract float CraftingSpeed { get; }

    public virtual float Productivity => 0f;
}