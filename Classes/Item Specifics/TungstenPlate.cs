



public class TungstenPlate : Item
{
    #region Singleton
    private static Lazy<TungstenPlate> _instance = new(() => new());
    
    public static TungstenPlate Instance => _instance.Value;
    #endregion

    public override string Name => "Tungsten Plate";
    public override string UUID => "tungstenPlate";

    public override List<Recipe> Recipes =>
    [
        new(
            result: new(Instance, 1), 
            ingredients:
            [
                new(TungstenOre.Instance, 4),
                new(MoltenIron.Instance, 10)
            ],
            craftingMachine: Foundry.Instance,
            craftingTimeSeconds: 10f
        ),
    ];
}