using botanic.Models;
using botanic.Data;
using botanic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace botanic.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des utilisateurs et l'authentification
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BotanicDbContext _context;

        public UserController(BotanicDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère la liste de tous les utilisateurs avec leurs informations publiques (nom d'utilisateur et rôle)
        /// </summary>
        /// <returns>Liste des utilisateurs avec leurs noms d'utilisateur et rôles</returns>
        /// <response code="200">Liste des utilisateurs récupérée avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        /// <example>
        /// GET /api/User
        /// 
        /// Réponse :
        /// [
        ///   {
        ///     "username": "lucas",
        ///     "role": "Administrator"
        ///   }
        /// ]
        /// </example>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    Username = u.Username,
                    Role = u.Role
                })
                .ToListAsync();
            
            return Ok(users);
        }

        /// <summary>
        /// Endpoint réservé aux administrateurs pour vérifier leur statut
        /// </summary>
        /// <returns>Message de bienvenue personnalisé pour l'administrateur connecté</returns>
        /// <response code="200">Accès autorisé - Message de bienvenue retourné</response>
        /// <response code="401">Non autorisé - Token JWT requis</response>
        /// <response code="403">Accès interdit - Rôle administrateur requis</response>
        /// <example>
        /// GET /api/User/Admins
        /// Authorization: Bearer {token}
        /// 
        /// Réponse :
        /// "Hi lucas, you are an Administrator"
        /// </example>
        [HttpGet("Admins")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.Username}, you are an {currentUser.Role}");
        }

        /// <summary>
        /// Récupère les informations de l'utilisateur connecté à partir du token JWT
        /// </summary>
        /// <returns>Objet User contenant les informations de l'utilisateur authentifié</returns>
        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new User
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
