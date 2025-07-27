using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using botanic.Data;
using botanic.Dtos;
using botanic.Models;

namespace botanic.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des plantes botaniques
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly BotanicDbContext _context;

        public PlantController(BotanicDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère la liste complète de toutes les plantes disponibles
        /// </summary>
        /// <returns>Liste de toutes les plantes avec leurs informations détaillées</returns>
        /// <response code="200">Liste des plantes récupérée avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        /// <example>
        /// GET /api/Plant
        /// 
        /// Réponse :
        /// [
        ///   {
        ///     "id": 1,
        ///     "name": "Lavande",
        ///     "description": "Plante aromatique méditerranéenne...",
        ///     "scientificName": "Lavandula angustifolia",
        ///     "family": "Lamiacées"
        ///   }
        /// ]
        /// </example>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Plant>>> GetPlants()
        {
            return await _context.Plants.ToListAsync();
        }

        /// <summary>
        /// Récupère une plante spécifique par son identifiant unique
        /// </summary>
        /// <param name="id">Identifiant unique de la plante à récupérer</param>
        /// <returns>Informations détaillées de la plante demandée</returns>
        /// <response code="200">Plante trouvée et retournée avec succès</response>
        /// <response code="404">Plante non trouvée avec l'identifiant fourni</response>
        /// <response code="500">Erreur interne du serveur</response>
        /// <example>
        /// GET /api/Plant/1
        /// 
        /// Réponse :
        /// {
        ///   "id": 1,
        ///   "name": "Lavande",
        ///   "description": "Plante aromatique méditerranéenne...",
        ///   "scientificName": "Lavandula angustifolia",
        ///   "family": "Lamiacées",
        ///   "isIndoor": false,
        ///   "isOutdoor": true
        /// }
        /// </example>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Plant>> GetPlant(int id)
        {
            var plant = await _context.Plants.FindAsync(id);

            if (plant == null)
            {
                return NotFound();
            }

            return plant;
        }

        /// <summary>
        /// Met à jour les informations d'une plante existante
        /// </summary>
        /// <param name="id">Identifiant unique de la plante à modifier</param>
        /// <param name="plantDto">Nouvelles informations de la plante</param>
        /// <returns>Aucun contenu en cas de succès</returns>
        /// <response code="204">Plante mise à jour avec succès</response>
        /// <response code="400">Données de la plante invalides</response>
        /// <response code="401">Non autorisé - Token JWT requis</response>
        /// <response code="404">Plante non trouvée avec l'identifiant fourni</response>
        /// <response code="500">Erreur interne du serveur</response>
        /// <example>
        /// PUT /api/Plant/1
        /// Authorization: Bearer {token}
        /// Content-Type: application/json
        /// 
        /// {
        ///   "name": "Lavande modifiée",
        ///   "description": "Nouvelle description de la lavande",
        ///   "scientificName": "Lavandula angustifolia",
        ///   "family": "Lamiacées",
        ///   "isIndoor": false,
        ///   "isOutdoor": true
        /// }
        /// </example>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutPlant(int id, PlantDto plantDto)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de la plante
            plant.Name = plantDto.Name;
            plant.Description = plantDto.Description;
            plant.ImageUrl = plantDto.ImageUrl;
            plant.ScientificName = plantDto.ScientificName;
            plant.Family = plantDto.Family;
            plant.Genus = plantDto.Genus;
            plant.Species = plantDto.Species;
            plant.CommonName = plantDto.CommonName;
            plant.CareInstructions = plantDto.CareInstructions;
            plant.IsIndoor = plantDto.IsIndoor;
            plant.IsOutdoor = plantDto.IsOutdoor;
            plant.IsPerennial = plantDto.IsPerennial;
            plant.IsAnnual = plantDto.IsAnnual;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Crée une nouvelle plante dans la base de données
        /// </summary>
        /// <param name="plantDto">Informations de la nouvelle plante à créer</param>
        /// <returns>La plante créée avec son identifiant généré</returns>
        /// <response code="201">Plante créée avec succès</response>
        /// <response code="400">Données de la plante invalides</response>
        /// <response code="401">Non autorisé - Token JWT requis</response>
        /// <response code="500">Erreur interne du serveur</response>
        /// <example>
        /// POST /api/Plant
        /// Authorization: Bearer {token}
        /// Content-Type: application/json
        /// 
        /// {
        ///   "name": "Nouvelle Plante",
        ///   "description": "Description de la nouvelle plante",
        ///   "scientificName": "Nova Planta",
        ///   "family": "Nouvelle Famille",
        ///   "isIndoor": true,
        ///   "isOutdoor": false
        /// }
        /// 
        /// Réponse :
        /// {
        ///   "id": 21,
        ///   "name": "Nouvelle Plante",
        ///   "description": "Description de la nouvelle plante",
        ///   "scientificName": "Nova Planta",
        ///   "family": "Nouvelle Famille"
        /// }
        /// </example>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Plant>> PostPlant(PlantDto plantDto)
        {
            var plant = new Plant
            {
                Name = plantDto.Name,
                Description = plantDto.Description,
                ImageUrl = plantDto.ImageUrl,
                ScientificName = plantDto.ScientificName,
                Family = plantDto.Family,
                Genus = plantDto.Genus,
                Species = plantDto.Species,
                CommonName = plantDto.CommonName,
                CareInstructions = plantDto.CareInstructions,
                IsIndoor = plantDto.IsIndoor,
                IsOutdoor = plantDto.IsOutdoor,
                IsPerennial = plantDto.IsPerennial,
                IsAnnual = plantDto.IsAnnual
            };

            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlant", new { id = plant.Id }, plant);
        }

        /// <summary>
        /// Supprime définitivement une plante de la base de données
        /// </summary>
        /// <param name="id">Identifiant unique de la plante à supprimer</param>
        /// <returns>Aucun contenu en cas de succès</returns>
        /// <response code="204">Plante supprimée avec succès</response>
        /// <response code="401">Non autorisé - Token JWT requis</response>
        /// <response code="404">Plante non trouvée avec l'identifiant fourni</response>
        /// <response code="500">Erreur interne du serveur</response>
        /// <example>
        /// DELETE /api/Plant/1
        /// Authorization: Bearer {token}
        /// 
        /// Réponse : 204 No Content
        /// </example>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePlant(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantExists(int id)
        {
            return _context.Plants.Any(e => e.Id == id);
        }
    }
}
