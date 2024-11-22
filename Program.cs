



using System.Diagnostics;
using System.Reflection;
using System.Linq;

void Main(){
    try {
        List<Item> items = GetItemInstancesNotAbstract();    

        PrintItemList(items);

        Item chosenItem = GetChosenItem(items);

        int amountToCraft = GetAmountToCraft(chosenItem);

        int returnStructure = GetReturnStructure();

        if (returnStructure == 1){
        List<CraftingInfoReturn> infos = GetInfoAboutCrafting(chosenItem, amountToCraft);
        
        List<CraftingInfoReturn> summarizedList = GetSummerizedList(infos);
        
        PrintCraftingInfoReturnList(summarizedList);
        }
        else if (returnStructure == 2)
        {
            CraftingInfoTree tree = GetInfoAboutCraftingTree(chosenItem, amountToCraft);

            PrintCraftingTree(tree);
        }
    }
    catch (Exception e){
        Console.WriteLine(e.Message);
        StackTrace stackTrace = new(e, true);
        StackFrame frame = stackTrace.GetFrame(0); // Get the top frame
        int line = frame.GetFileLineNumber(); // Get the line number
        string file = frame.GetFileName();
        Console.WriteLine($"Error in file: {file} at line: {line}");
    }
    finally {
        Close();
    }
}

List<Item> GetItemInstancesNotAbstract()
{
    Assembly assembly = Assembly.GetExecutingAssembly();

    List<Type> types = assembly.GetTypes().ToList();

    List<Item> items = [];
    foreach (Type type in types)
    {
        if (type.IsSubclassOf(typeof(Item)) == false || type.IsAbstract)
        {
            continue;        
        }  

        PropertyInfo? instanceProperty = type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
        if (instanceProperty == null)
        {
            continue;
        }  

        object? @object = instanceProperty.GetValue(null);
        if (@object is Item item)
        {
            items.Add(item);
        }
    }

    items.Sort((a, b) => a.Name.CompareTo(b.Name));
    return items;
}

void PrintItemList(List<Item> items){
    Console.WriteLine("\n\n\n\n\nChoose an item to craft:");

    int i = 1;
    foreach (Item item in items)
    {    
        Console.WriteLine($"{i}: {item.Name}");
        i++;
    }
}

Item GetChosenItem(List<Item> items){
    string? input = Console.ReadLine();
    if (input == null)
    {
        throw new($"Invalid input ({input})");
    }

    Item chosenItem;
    if (int.TryParse(input, out int choice))
    {
        chosenItem = items[choice - 1];
    }
    else 
    {
        Item? foundItem = items.Find(item => item.Name == input);
        if (foundItem == null)
        {
            throw new($"Item ({input}) not found");
        }
        chosenItem = foundItem;
    }
    return chosenItem;
}

int GetAmountToCraft(Item chosenItem){
    Console.WriteLine($"\n\n\n\n\nHow many {chosenItem.Name} would you like to craft?");
    return GetInt();
}

int GetReturnStructure(){
    Console.WriteLine("\n\n\n\n\nChoose the return structure:");
    Console.WriteLine("1: List");
    Console.WriteLine("2: Tree");

    int choice = GetInt();

    if (choice != 1 && choice != 2)
    throw new($"Invalid choice ({choice})");

    return choice;
}

int GetInt(){
    string? input = Console.ReadLine();
    if (input == null)
    {
        throw new($"Invalid input ({input})");
    }

    if (int.TryParse(input, out int integer) == false)
    {
        throw new($"Invalid input ({input})");
    }
    return integer;
}

#region CraftingInfoReturn Method
List<ItemAndRecipe> cachedChosenRecipes = []; 
List<ItemAndCount> availableItems = [];

List<CraftingInfoReturn> GetInfoAboutCrafting(Item chosenItem, int amountToCraft){
    // GET RECIPE
    Recipe chosenRecipe = GetTheWantedRecipe(chosenItem);

    // GET CRAFTS NEEDED    
    CraftingEntity chosenCraftingMachine = chosenRecipe.CraftingMachine;

    float effectiveCraftingTime = chosenRecipe.CraftingTimeSeconds / chosenCraftingMachine.CraftingSpeed;

    float craftsPerSecond = 1 / effectiveCraftingTime;

    int itemsPerCraft = chosenRecipe.Results.First(result => result.Item == chosenItem).Count;
    float itemsPerSecond = itemsPerCraft * craftsPerSecond * (1 + chosenCraftingMachine.Productivity);

    int craftersNeeded = (int)MathF.Ceiling(amountToCraft / itemsPerSecond);

    // GET NEEDED INGREDIENTS
    List<CraftingInfoReturn> nestedInfo = [];
    foreach (ItemAndCount ingredient in chosenRecipe.Ingredients)
    { 
        Item ingredientItem = ingredient.Item;
        int ingredientCount = (int)MathF.Ceiling(ingredient.Count * craftsPerSecond);

        // RECURSIVE CALL FOR INGREDIENTS
        nestedInfo = [..nestedInfo, ..GetInfoAboutCrafting(ingredientItem, ingredientCount) ] ;
    }    

    List<CraftingInfoReturn> craftingInfo = [
        new(chosenItem, new(chosenRecipe.CraftingMachine, craftersNeeded)),
        ..nestedInfo
    ];

    return craftingInfo;
}

#endregion

#region CraftingTreeInfo Method

CraftingInfoTree GetInfoAboutCraftingTree(Item chosenItem, int amountToCraft)
{
    // GET RECIPE
    Recipe chosenRecipe = GetTheWantedRecipe(chosenItem);

    // GET CRAFTS NEEDED    
    CraftingEntity chosenCraftingMachine = chosenRecipe.CraftingMachine;

    float effectiveCraftingTime = chosenRecipe.CraftingTimeSeconds / chosenCraftingMachine.CraftingSpeed;

    float craftsPerSecond = 1 / effectiveCraftingTime;

    int itemsPerCraft = chosenRecipe.Results.First(result => result.Item == chosenItem).Count;
    float itemsPerSecond = itemsPerCraft * craftsPerSecond * (1 + chosenCraftingMachine.Productivity);

    int craftersNeeded = (int)MathF.Ceiling(amountToCraft / itemsPerSecond);

    // ROOT NODE FOR THE CURRENT ITEM
    CraftingInfoTree rootNode = new CraftingInfoTree(
        new CraftingInfoReturn(chosenItem, new CraftingEntityAndCount(chosenRecipe.CraftingMachine, craftersNeeded))
    );

    // GET NEEDED INGREDIENTS
    foreach (ItemAndCount ingredient in chosenRecipe.Ingredients)
    {
        Item ingredientItem = ingredient.Item;
        int ingredientCount = (int)MathF.Ceiling(ingredient.Count * craftsPerSecond);

        // RECURSIVE CALL FOR INGREDIENTS
        CraftingInfoTree childNode = GetInfoAboutCraftingTree(ingredientItem, ingredientCount);
        rootNode.Children.Add(childNode);
    }

    return rootNode;
}

#endregion

Recipe GetTheWantedRecipe(Item chosenItem)
{
    ItemAndRecipe? cached = cachedChosenRecipes.Find(itemAndRecipe => itemAndRecipe.Item == chosenItem);
    if (cached != null) return cached.Recipe;

    bool hasMultipleRecipes = chosenItem.Recipes.Count > 1;
    Recipe chosenRecipe = hasMultipleRecipes ? GetTheWantedRecipeInt(chosenItem) : chosenItem.Recipes[0];

    cachedChosenRecipes.Add( new(chosenItem, chosenRecipe) );
    return chosenRecipe;
}

Recipe GetTheWantedRecipeInt(Item chosenItem)
{
    PrintAvailableRecpies(chosenItem.Recipes);

    string? input = Console.ReadLine();

    if ( input == null )    
    throw new($"Invalid input ({input})");

    if ( int.TryParse(input, out int amountToCraft) == false )      
    throw new($"Invalid input ({input})");

    return chosenItem.Recipes[amountToCraft - 1];
}

void PrintAvailableRecpies(List<Recipe> recipes){
    Console.WriteLine("\n\n\n\n\nChoose a recipe to use for this item:");

    int i = 1;
    foreach (Recipe recipe in recipes)
    {
        Console.WriteLine($"{i}: \n{recipe}");
        i++;
    }
}

List<CraftingInfoReturn> GetSummerizedList(List<CraftingInfoReturn> infos)
{
    return infos
        .GroupBy(c => c.Item) // Group by Item
        .Select(g => new CraftingInfoReturn(
            g.Key, // The grouped Item
            new CraftingEntityAndCount(
                g.First().CraftingEntityAndCount.CraftingEntity, // Use the first machine (assuming one type per item)
                g.Sum(c => c.CraftingEntityAndCount.Count) // Sum the counts
            )
        ))
        .ToList();
}

void PrintCraftingInfoReturnList(List<CraftingInfoReturn> summarizedList)
{
    Console.WriteLine("\n\n\n\n\nCrafting info:");
    foreach (CraftingInfoReturn info in summarizedList)
    {
        Console.WriteLine($"{info.CraftingEntityAndCount.Count} {info.CraftingEntityAndCount.CraftingEntity.Name} crafting {info.Item.Name}");
    }
}

void PrintCraftingTree(CraftingInfoTree node, int level = 0)
{
    string indent = string.Concat(Enumerable.Repeat("- ", level * 2));
    Console.WriteLine($"{indent}{node.Info.CraftingEntityAndCount.Count} {node.Info.CraftingEntityAndCount.CraftingEntity.Name} crafting {node.Info.Item.Name}");
    foreach (var child in node.Children)
    {
        PrintCraftingTree(child, level + 1);
    }
}

void Close(){
    Console.WriteLine("Press any key to close...");
    Console.ReadKey();
}

Main();