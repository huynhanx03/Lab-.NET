using AutoMapper;
using DataAccess.Mappings;
using DataAccess.Models;

namespace DataAccess.DTOs;
public class SilverJewelryResponse : IMapFrom<SilverJewelry>
{
    public string SilverJewelryId { get; set; } = null!;

    public string SilverJewelryName { get; set; } = null!;

    public string? SilverJewelryDescription { get; set; }

    public decimal? MetalWeight { get; set; }

    public decimal? Price { get; set; }

    public int? ProductionYear { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<SilverJewelry, SilverJewelryResponse>()
            .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category!.CategoryName));
    }
}
