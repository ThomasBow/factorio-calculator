


using System.Text;

public class Recipe 
{
    public readonly List<ItemAndCount> Ingredients;
    
    public readonly CraftingEntity CraftingMachine;

    public readonly List<ItemAndCount> Results;

    public readonly float CraftingTimeSeconds; 

    public Recipe(List<ItemAndCount> results, List<ItemAndCount> ingredients, CraftingEntity craftingMachine, float craftingTimeSeconds) 
    {
        Results = results;
        Ingredients = ingredients;
        CraftingMachine = craftingMachine;
        CraftingTimeSeconds = craftingTimeSeconds;
    }

    public Recipe(ItemAndCount result, List<ItemAndCount> ingredients, CraftingEntity craftingMachine, float craftingTimeSeconds) 
    {
        Results = [ result ];
        Ingredients = ingredients;
        CraftingMachine = craftingMachine;
        CraftingTimeSeconds = craftingTimeSeconds;
    }

    public Recipe(List<ItemAndCount> results, ItemAndCount ingredient, CraftingEntity craftingMachine, float craftingTimeSeconds) 
    {
        Results = results;
        Ingredients = [ ingredient ];
        CraftingMachine = craftingMachine;
        CraftingTimeSeconds = craftingTimeSeconds;
    }

    public Recipe(ItemAndCount result, ItemAndCount ingredient, CraftingEntity craftingMachine, float craftingTimeSeconds) 
    {
        Results = [ result ];
        Ingredients = [ ingredient ];
        CraftingMachine = craftingMachine;
        CraftingTimeSeconds = craftingTimeSeconds;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append("Make: ");

        bool first = true;
        foreach (ItemAndCount itemAndCount in Results)
        {
            if (first) first = false;
            else stringBuilder.Append(", ");

            stringBuilder.Append(itemAndCount.Count);
            stringBuilder.Append(' ');
            stringBuilder.Append(itemAndCount.Item.Name);        
        }

        stringBuilder.AppendLine();
        stringBuilder.Append("From: ");

        first = true;
        foreach (ItemAndCount itemAndCount in Ingredients)
        {
            if (first) first = false;
            else stringBuilder.Append(", ");

            stringBuilder.Append(itemAndCount.Count);
            stringBuilder.Append(' ');
            stringBuilder.Append(itemAndCount.Item.Name);
        }

        stringBuilder.AppendLine();
        stringBuilder.Append("In: ");
        stringBuilder.Append(CraftingMachine.Name);

        return stringBuilder.ToString();
    }
}