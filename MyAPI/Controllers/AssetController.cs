using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyAPI.Data;
using MyAPI.Model;

namespace MyAPI.Controllers
{
    [ApiController] //from mayur PC and ofc pc
    [Route("api/[controller]")]
    public class AssetController : Controller
    {
        private readonly AppDbContextcs appDb;

        public AssetController(AppDbContextcs appDb)
        {
            this.appDb = appDb;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetData()
        {
            return await appDb.Assets.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Asset>> GetDataById(int Id)
        {
            var assetData = await appDb.Assets.Where(x => x.AssetId == Id).FirstOrDefaultAsync();
            if (assetData == null) 
                return NotFound();
            return assetData;
        }

        [HttpPost]
        public async Task<ActionResult<Asset>> AddData(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            appDb.Assets.Add(asset);
            await appDb.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("id")]
        public async Task<ActionResult> UpdateData(int id, Asset asset)
        {
            if (asset == null)
                return BadRequest();

            var existingData = await appDb.Assets.FindAsync(id);
            if (existingData == null)
                return NotFound($"id {id} not found");

            existingData.ItemName = asset.ItemName;
            appDb.SaveChanges();
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = appDb.Assets.Find(id);
            if(data == null)
                return(NotFound($"id {id} not found"));

            appDb.Assets.Remove(data);
            appDb.SaveChanges();
            return Ok();
        }
    }
}
