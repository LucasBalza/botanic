namespace botanic.Dtos
{
    /// <summary>
    /// DTO pour l'affichage public des informations utilisateur
    /// </summary>
    public class UserDisplayDto
    {
        /// <summary>
        /// Nom d'utilisateur unique
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Rôle de l'utilisateur dans l'application
        /// </summary>
        public string Role { get; set; }
    }
}