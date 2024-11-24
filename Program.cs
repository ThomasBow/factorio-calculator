



using System.Diagnostics;
using System.Reflection;

Module? moduleToUse = null;

void Main(){
    try {
        List<Item> items = GetInstancesNotAbstract<Item>();  
        items.Sort((a, b) => a.Name.CompareTo(b.Name));  

        List<Module> modules = GetInstancesNotAbstract<Module>();

        PrintItemList(items);

        Item chosenItem = GetChosenItem(items);

        int amountToCraft = GetAmountToCraft(chosenItem);

        int returnStructure = GetReturnStructure();

        GetModulesIfUsed(modules);

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
        StackFrame? frame = stackTrace.GetFrame(0); // Get the top frame
        int? line = frame?.GetFileLineNumber(); // Get the line number
        string? file = frame?.GetFileName();
        Console.WriteLine($"Error in file: {file} at line: {line}");
    }
    finally {
        Close();
    }
}

List<InstanceType> GetInstancesNotAbstract<InstanceType>()
{
    Assembly assembly = Assembly.GetExecutingAssembly();

    List<Type> types = assembly.GetTypes().ToList();

    List<InstanceType> instanceTypes = [];
    foreach (Type type in types)
    {
        if (type.IsSubclassOf(typeof(InstanceType)) == false || type.IsAbstract)
        {
            continue;        
        }  

        PropertyInfo? instanceProperty = type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
        if (instanceProperty == null)
        {
            continue;
        }  

        object? @object = instanceProperty.GetValue(null);
        if (@object is InstanceType instanceType)
        {
            instanceTypes.Add(instanceType);
        }
    }    
    return instanceTypes;
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

void GetModulesIfUsed(List<Module> modules)
{
    Console.WriteLine("\n\n\n\n\nWould you like to use modules? (y/n)");
    string? input = Console.ReadLine();

    if (input == null)
    throw new($"Invalid input ({input})");

    if (input == "y")
    {
        GetModule(modules);
    }
    else if (input != "n") 
    throw new($"Invalid input ({input})");
}

void GetModule(List<Module> modules)
{
    Console.WriteLine("\n\n\n\n\nChoose a module to use:");
    
    int i = 1;
    foreach (Module module in modules)
    {
        Console.WriteLine($"{i}: {module.Name}");
        i++;
    }

    string? input = Console.ReadLine();
    if (input == null)
    throw new($"Invalid input ({input})");

    if (int.TryParse(input, out int choice) == false)
    throw new($"Invalid input ({input})");

    if (choice < 1 || choice > modules.Count)
    throw new($"Invalid choice ({choice})");

    moduleToUse = modules[choice - 1];
}

#region CraftingInfoReturn Method
List<ItemAndRecipe> cachedChosenRecipes = []; 

List<CraftingInfoReturn> GetInfoAboutCrafting(Item chosenItem, int amountToCraft){
    // GET RECIPE
    Recipe chosenRecipe = GetTheWantedRecipe(chosenItem);

    // GET CRAFTS NEEDED    
    CraftingEntity chosenCraftingMachine = chosenRecipe.CraftingMachine;

    (float craftsPerSecond, float itemsPerSecond) = CalculatePerSecond(chosenItem, chosenRecipe, chosenCraftingMachine);

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

    (float craftsPerSecond, float itemsPerSecond) = CalculatePerSecond(chosenItem, chosenRecipe, chosenCraftingMachine);

    int craftersNeeded = (int)MathF.Ceiling(amountToCraft / itemsPerSecond);

    // ROOT NODE FOR THE CURRENT ITEM
    CraftingInfoTree rootNode = new(
        new(chosenItem, new(chosenRecipe.CraftingMachine, craftersNeeded))
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

(float craftsPerSecond, float itemsPerSecond) CalculatePerSecond(Item chosenItem, Recipe chosenRecipe, CraftingEntity chosenCraftingMachine)
{
    (float moduleSpeedModifier, float moduleProductivityModifier) = CalculateModuleSpeedAndProductivityForRecipe(chosenRecipe);

    float effectiveChosenCraftingMachineSpeed = chosenCraftingMachine.CraftingSpeed * (1 + moduleSpeedModifier);

    float effectiveCraftingTime = chosenRecipe.CraftingTimeSeconds / effectiveChosenCraftingMachineSpeed;

    float craftsPerSecond = 1 / effectiveCraftingTime;

    int itemsPerCraft = chosenRecipe.Results.First(result => result.Item == chosenItem).Count;

    float itemsPerSecond = itemsPerCraft * craftsPerSecond * (1 + chosenCraftingMachine.Productivity + moduleProductivityModifier);

    return (craftsPerSecond, itemsPerSecond);
}

(float moduleSpeedModifier, float moduleProductivityModifier) CalculateModuleSpeedAndProductivityForRecipe(Recipe chosenRecipe)
{
    float moduleSpeedModifier = CalculateModuleSpeedForRecipe(chosenRecipe);
    float moduleProductivityModifier = CalculateModuleProductivityForRecipe(chosenRecipe);

    return (moduleSpeedModifier, moduleProductivityModifier);
}

float CalculateModuleSpeedForRecipe(Recipe chosenRecipe)
{
    if (moduleToUse == null)
    {
        return 0f;
    }

    CraftingEntity craftingEntity = chosenRecipe.CraftingMachine;
    if (craftingEntity is not CraftingEntityWithModules entityWithModules)
    {
        return 0f;
    }

    float totalSpeed = entityWithModules.ModuleCount * moduleToUse.SpeedModifier;
    return totalSpeed;
}

float CalculateModuleProductivityForRecipe(Recipe recipe)
{
    if (moduleToUse == null)
    {
        return 0f;
    }

    CraftingEntity craftingEntity = recipe.CraftingMachine;
    if (craftingEntity is not CraftingEntityWithModules entityWithModules)
    {
        return 0f;
    }

    float totalProductivity = entityWithModules.ModuleCount * moduleToUse.ProductivityModifier;
    return totalProductivity;
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