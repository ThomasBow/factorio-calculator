


public class CraftingInfoTree
{
    public CraftingInfoReturn Info { get; set; }
    public List<CraftingInfoTree> Children { get; set; }

    public CraftingInfoTree(CraftingInfoReturn info)
    {
        Info = info;
        Children = [];
    }
}