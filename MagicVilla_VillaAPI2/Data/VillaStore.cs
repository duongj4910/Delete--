using MagicVilla_VillaAPI2.Models.Dto;

namespace MagicVilla_VillaAPI2.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
                new VillaDTO {Id = 1, Name = "Pool View", Sqft = 100, Occupancy = 4},
                new VillaDTO {Id = 2, Name = "Ocean View",Sqft = 100, Occupancy = 4}
            };
    }
}
