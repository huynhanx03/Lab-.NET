using DataAccess.Mappings;
using DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTOs;
public class SilverJewelryRequest : IMapFrom<SilverJewelry>
{
    public string SilverJewelryId { get; set; } = null!;

    public string SilverJewelryName { get; set; } = null!;

    public string SilverJewelryDescription { get; set; }

    public decimal MetalWeight { get; set; }

    [Range(0, 100000000, ErrorMessage = "Price >= 0")]
    public decimal Price { get; set; }

    [Range(1900, 100000000, ErrorMessage = "ProductionYear >= 1900")]
    public int ProductionYear { get; set; }

    public string CategoryId { get; set; }
}
