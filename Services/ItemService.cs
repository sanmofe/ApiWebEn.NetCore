using back.Models;

namespace back.Services;

public static class ItemService{
    static List<InventoryItem> Items { get; }
    static int nextId = 3;
    static ItemService(){
        Items = new List<InventoryItem>
        {
            new InventoryItem { id = 1, name = "Pizza", quantity = 5, price = 10000},
            new InventoryItem { id = 2, name = "Burger", quantity = 10, price = 5000}
        };
    }

    public static List<InventoryItem> GetAll() => Items;

    public static InventoryItem? Get(int Id) => Items.FirstOrDefault(p => p.id == Id);

    public static void Add( InventoryItem item){
        item.id = nextId++;
        Items.Add(item);
    }

    public static void Delete(int id){
        var item = Get(id);
        if( item is null){
            return;
        }
        Items.Remove(item);
    }

    public static void Update(InventoryItem item){
       var index = Items.FindIndex(p => p.id == item.id);
        if(index == -1)
            return;

        Items[index] = item; 
    }
    
}