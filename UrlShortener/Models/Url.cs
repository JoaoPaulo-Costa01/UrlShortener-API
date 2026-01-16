using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Models {
    public class Url {
        public int Id { get; set; }

        public string OriginalUrl { get; set; }

        public string Code { get; set; }
    }
}
