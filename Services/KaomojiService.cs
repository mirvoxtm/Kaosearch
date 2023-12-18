using Kaosearch.Models;
using J3QQ4;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.RegularExpressions;
using System.Linq;

namespace Kaosearch.Services {
    public class KaomojiService {

        private readonly KaosearchContext _context;

        public KaomojiService(KaosearchContext context) {
            _context = context;
        }

        public List<Kaomoji> ListAll() {
            return _context.Kaomojis.ToList();
        }

        public Kaomoji GetById(int id) {
            return _context.Kaomojis.FirstOrDefault(x => x.Id == id);
        }

        public void SubmitKaomoji(Kaomoji kaomoji) {

            // Replace empty spaces with tag separators.
            kaomoji.Emojis = kaomoji.Emojis.Trim();
            kaomoji.Tags = kaomoji.Tags.Replace(' ', ',');
            kaomoji.Tags = kaomoji.Tags.Trim(); // Trimming possible empty spaces.

            // Trimming possible empty spaces on Emojis.
            kaomoji.Emojis = kaomoji.Emojis.Trim();
            kaomoji.Emojis = kaomoji.Emojis.Replace(' ', ',');
            kaomoji.Emojis = kaomoji.Emojis.Trim();

            _context.Add(kaomoji);
            _context.SaveChanges();
        }

    }
}
