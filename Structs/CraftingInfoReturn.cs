



public class CraftingInfoReturn
{
    public Item Item;
    public CraftingEntityAndCount CraftingEntityAndCount;

    public CraftingInfoReturn(Item item, CraftingEntityAndCount craftingEntityAndCount)
    {
        Item = item;
        CraftingEntityAndCount = craftingEntityAndCount;
    }
}