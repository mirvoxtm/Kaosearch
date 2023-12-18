using Kaosearch.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace Kaosearch.Models {
    public class Kaomoji {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kaomoji is required")] [StringLength(20, MinimumLength = 3)] public string Kao { get; set; }
        [Required(ErrorMessage = "Tags are required")] public string Tags { get; set; }
        [Required(ErrorMessage = "Emojis are required")]  [EmojiOnly(ErrorMessage = "This field must only contain emojis")] [StringLength(20, MinimumLength = 1)] public string Emojis { get; set; }

        public Kaomoji() {
        }

        public Kaomoji(string kao, string tags, string emojis) {
            this.Kao = kao;
            this.Tags = tags;
            this.Emojis = emojis;
        }
    }
}
