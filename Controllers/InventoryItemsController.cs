using Microsoft.AspNetCore.Mvc;
using back.Models;
using back.Services;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryItemsController: ControllerBase{

    [HttpGet]
    public ActionResult<List<InventoryItem>> GetAll() =>
        ItemService.GetAll();
    
    [HttpGet("{id}")]
    public ActionResult<InventoryItem> Get(int id){
        var item = ItemService.Get(id);
        if(item == null){
            return NotFound();
        }

        return item;
    }    
    
    [HttpPost]
    public IActionResult Create(InventoryItem item){
        ItemService.Add(item);
        return CreatedAtAction(nameof(Create), new { id = item.id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, InventoryItem item){
        if (id != item.id)
            return BadRequest();
           
        var existingItem = ItemService.Get(id);
        if(existingItem is null)
            return NotFound();
   
        ItemService.Update(item);           
   
    return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var item = ItemService.Get(id);
        if(item is null)
            return NotFound();
        
        ItemService.Delete(id);
        return NoContent();
    }


}