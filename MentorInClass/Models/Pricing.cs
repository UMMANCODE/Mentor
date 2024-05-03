using System.ComponentModel.DataAnnotations.Schema;

namespace MentorInClass.Models
{
    public class Pricing
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string BtnText { get; set; }
        public string BtnUrl { get; set; }
        public bool isFeatured { get; set; }
        public bool isAdvanced { get; set; }
        public List<PricingFeature>? Features { get; set; } = new();
        [NotMapped]
        public List<int>? FeatureIds { get; set; } = new();
    }
}
