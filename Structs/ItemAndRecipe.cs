


public class ItemAndRecipe
{
    public Item Item { get; }
    public Recipe Recipe { get; }

    public ItemAndRecipe(Item item, Recipe recipe)
    {
        Item = item;
        Recipe = recipe;
    }
}