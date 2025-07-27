using botanic.Data;
using botanic.Dtos;
using botanic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace botanic.Controllers
{
    /// <summary>
    /// Contrôleur pour l'authentification et la gestion des tokens JWT
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly BotanicDbContext _context;

        public LoginController(IConfiguration config, BotanicDbContext context)
        {
            _config = config;
            _context = context;
        }

        /// <summary>
        /// Authentifie un utilisateur et génère un token JWT pour l'accès aux ressources protégées
        /// </summary>
        /// <param name="userLogin">Informations de connexion (nom d'utilisateur et mot de passe)</param>
        /// <returns>Token JWT valide pour l'authentification</returns>
        /// <response code="200">Authentification réussie - Token JWT retourné</response>
        /// <response code="400">Données de connexion invalides</response>
        /// <response code="404">Utilisateur non trouvé avec les identifiants fournis</response>
        /// <response code="500">Erreur interne du serveur</response>
        /// <example>
        /// POST /api/Login
        /// Content-Type: application/json
        /// 
        /// {
        ///   "username": "lucas",
        ///   "password": "password"
        /// }
        /// 
        /// Réponse :
        /// "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJsdWNhcyIsImVtYWlsIjoibHVjYXMuYWRtaW5AZW1haWwuY29tIiwicm9sZSI6IkFkbWluaXN0cmF0b3IiLCJleHAiOjE2MzQ1Njc4OTB9.signature"
        /// </example>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UserDto userLogin)
        {
            var user = await AuthenticateAsync(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        /// <summary>
        /// Génère un token JWT pour l'utilisateur authentifié
        /// </summary>
        /// <param name="user">Utilisateur pour lequel générer le token</param>
        /// <returns>Token JWT signé avec les claims de l'utilisateur</returns>
        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Authentifie un utilisateur en vérifiant ses identifiants dans la base de données
        /// </summary>
        /// <param name="userLogin">Informations de connexion à vérifier</param>
        /// <returns>Utilisateur authentifié ou null si échec</returns>
        private async Task<User> AuthenticateAsync(UserDto userLogin)
        {
            var currentUser = await _context.Users
                .FirstOrDefaultAsync(o =>
                        o.Username.ToLower() == userLogin.Username.ToLower()
                        && o.Password == userLogin.Password
                        );

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
    }
}
