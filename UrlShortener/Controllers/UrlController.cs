using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NanoidDotNet;
using UrlShortener.Data;
using UrlShortener.Data;
using UrlShortener.Models;

namespace UrlShortener.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase {
        private readonly AppDbContext _appDbContext;

        public UrlController(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUrl([FromBody] string urlOriginal) {
            if (string.IsNullOrWhiteSpace(urlOriginal) ||
            !Uri.TryCreate(urlOriginal, UriKind.Absolute, out _)) {
                return BadRequest("A URL fornecida é inválida. Lembre-se de colocar http:// ou https://");
            }
            var _code = Nanoid.Generate(Nanoid.Alphabets.LettersAndDigits, 6);

            var urlModel = new Url {
                OriginalUrl = urlOriginal,
                Code = _code
            };
            _appDbContext.UrlShort.Add(urlModel);
            await _appDbContext.SaveChangesAsync();

            var urlEncurtada = $"{Request.Scheme}://{Request.Host}/api/Url/{_code}";

            return Ok(new {
                url_original = urlOriginal,
                url_encurtada = urlEncurtada,
                codigo = _code
            });
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> RedirectToUrl(string code) {
            var urlModel = await _appDbContext.UrlShort
                .FirstOrDefaultAsync(u => u.Code == code);

            if (urlModel == null) {
                return NotFound("URL não encontrada ou código inválido.");
            }

            return Redirect(urlModel.OriginalUrl);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Url>>> GetAllUrl() {
            var urls = await _appDbContext.UrlShort.ToListAsync();

            return Ok(urls);
        }
    }
}
