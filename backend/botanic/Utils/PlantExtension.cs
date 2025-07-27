using botanic.Dtos;
using botanic.Models;

namespace botanic.Utils
{
    public static class PlantExtension
    {
        public static PlantDto ToDto(this Plant plant)
        {
            return new PlantDto
            {
                Id = plant.Id,
                Name = plant.Name,
                Description = plant.Description,
                ImageUrl = plant.ImageUrl,
                ScientificName = plant.ScientificName,
                Family = plant.Family,
                Genus = plant.Genus,
                Species = plant.Species,
                CommonName = plant.CommonName,
                CareInstructions = plant.CareInstructions,
                IsIndoor = plant.IsIndoor,
                IsOutdoor = plant.IsOutdoor,
                IsPerennial = plant.IsPerennial,
                IsAnnual = plant.IsAnnual
            };
        }

        public static Plant ToModel(this PlantDto dto)
        {
            return new Plant
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                ScientificName = dto.ScientificName,
                Family = dto.Family,
                Genus = dto.Genus,
                Species = dto.Species,
                CommonName = dto.CommonName,
                CareInstructions = dto.CareInstructions,
                IsIndoor = dto.IsIndoor,
                IsOutdoor = dto.IsOutdoor,
                IsPerennial = dto.IsPerennial,
                IsAnnual = dto.IsAnnual
            };
        }
    }
}
