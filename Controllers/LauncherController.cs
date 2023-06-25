using LauncherTestAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LauncherTestAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LauncherController : ControllerBase {

        private readonly HttpClient _httpClient;
        public LauncherController(IHttpClientFactory httpClientFactory) {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok("REST Back-end Challenge 20201209 Running");
        }

        [HttpGet("launchers")]
        public IActionResult GetLaunchers([FromQuery] int page) {
            List<Launcher> launchers = new List<Launcher>();
            return Ok(launchers);
        }

        [HttpGet("{launchId}")]
        public IActionResult GetLauncher(Guid launchId) {
            return Ok(new Launcher());
        }

        [HttpPut("{launchId}")]
        public IActionResult UpdateLauncher(Guid launchId, [FromBody] Launcher updatedLauncher) {
            return Ok();
        }

        [HttpDelete("{launchId}")]
        public IActionResult DeleteLauncher(Guid launchId) {
            return Ok();
        }

    }
}
