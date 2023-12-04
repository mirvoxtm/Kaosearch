using Kaosearch.Models;

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
            _context.Kaomojis.Add(kaomoji);
            _context.SaveChanges();
        }

    }
}
