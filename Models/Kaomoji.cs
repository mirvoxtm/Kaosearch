namespace Kaosearch.Models {
    public class Kaomoji {
        public int Id { get; set; }
        public string Kao { get; set; }
        public string Tags { get; set; }
        public string Emojis { get; set; }

        public Kaomoji() {
        }

        public Kaomoji(string kao, string tags, string emojis) {
            this.Kao = kao;
            this.Tags = tags;
            this.Emojis = emojis;
        }
    }
}
