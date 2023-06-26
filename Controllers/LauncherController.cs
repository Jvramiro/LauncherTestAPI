using LauncherTestAPI.Data;
using LauncherTestAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LauncherTestAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LauncherController : ControllerBase {

        private readonly LauncherContext _context;
        private readonly HttpClient _httpClient;
        private const int pagingSize = 10;
        public LauncherController(LauncherContext context, HttpClient httpClient) {
            _context = context;
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok("REST Back-end Challenge 20201209 Running");
        }

        [HttpGet("launchers")]
        public IActionResult GetLaunchers([FromQuery] int page) {

            int correctPage = page - 1;
            var launchers = _context.GetAllLaunchers().Skip(correctPage*pagingSize).Take(pagingSize).ToList();

            if(launchers == null || launchers.Count == 0) {
                return NotFound("Available users not found");
            }

            return Ok(launchers);
        }

        [HttpGet("{launchId}")]
        public IActionResult GetLauncher(int launchId) {
            
            var launcher = _context.GetLauncherById(launchId);

            if(launcher == null) {
                return NotFound($"Id {launchId} not found");
            }

            return Ok(launcher);

        }

        [HttpPut("{launchId}")]
        public IActionResult UpdateLauncher(int launchId, [FromBody] Launcher updatedLauncher) {
            var launcher = _context.GetLauncherById(launchId);

            if (launcher == null) {
                return NotFound($"Id {launchId} not found");
            }

            if(!ModelState.IsValid) {
                return BadRequest("Incorrect or Invalid Body request");
            }

            _context.UpdateLauncher(launcher);

            return Ok($"Launcher with Id {launchId} updated successfull");

        }

        [HttpDelete("{launchId}")]
        public IActionResult DeleteLauncher(int launchId) {
            var launcher = _context.GetLauncherById(launchId);

            if (launcher == null) {
                return NotFound($"Id {launchId} not found");
            }

            _context.DeleteLauncher(launchId);
            return Ok($"Launcher with Id {launchId} removed successfully");
        }

    }
}
