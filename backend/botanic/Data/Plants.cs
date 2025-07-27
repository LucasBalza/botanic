using botanic.Models;

namespace botanic.Data
{
    public class Plants
    {
        public static List<Plant> plantsList = new List<Plant>()
        {
            new Plant()
            {
                Id = 1,
                Name = "Lavande",
                Description = "Plante aromatique méditerranéenne aux fleurs violettes très parfumées, utilisée en parfumerie et phytothérapie.",
                ImageUrl = "https://images.pexels.com/photos/1306711/pexels-photo-1306711.jpeg",
                ScientificName = "Lavandula angustifolia",
                Family = "Lamiacées",
                Genus = "Lavandula",
                Species = "angustifolia",
                CommonName = "Lavande officinale",
                CareInstructions = "Exposition plein soleil, sol calcaire et bien drainé. Arrosage modéré, tailler après floraison.",
                IsIndoor = false,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 2,
                Name = "Rosier",
                Description = "Arbuste ornemental aux fleurs magnifiques, symbole de l'amour et de la beauté dans de nombreuses cultures.",
                ImageUrl = "https://images.pexels.com/photos/33157252/pexels-photo-33157252.jpeg",
                ScientificName = "Rosa gallica",
                Family = "Rosacées",
                Genus = "Rosa",
                Species = "gallica",
                CommonName = "Rose de France",
                CareInstructions = "Exposition ensoleillée, sol riche et bien drainé. Taille annuelle, protection hivernale recommandée.",
                IsIndoor = false,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 3,
                Name = "Basilic",
                Description = "Herbe aromatique annuelle très populaire en cuisine méditerranéenne, aux feuilles vertes et parfumées.",
                ImageUrl = "https://images.pexels.com/photos/3816343/pexels-photo-3816343.jpeg",
                ScientificName = "Ocimum basilicum",
                Family = "Lamiacées",
                Genus = "Ocimum",
                Species = "basilicum",
                CommonName = "Basilic commun",
                CareInstructions = "Exposition ensoleillée, sol riche et humide. Arrosage régulier, pincer les fleurs pour favoriser les feuilles.",
                IsIndoor = true,
                IsOutdoor = true,
                IsPerennial = false,
                IsAnnual = true
            },
            new Plant()
            {
                Id = 4,
                Name = "Fougère",
                Description = "Plante primitive sans fleurs ni graines, se reproduisant par spores. Excellente pour les zones ombragées.",
                ImageUrl = "https://images.pexels.com/photos/2893181/pexels-photo-2893181.jpeg",
                ScientificName = "Polypodium vulgare",
                Family = "Polypodiacées",
                Genus = "Polypodium",
                Species = "vulgare",
                CommonName = "Polypode commun",
                CareInstructions = "Exposition ombragée, sol humide et acide. Arrosage fréquent, pas de taille nécessaire.",
                IsIndoor = true,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 5,
                Name = "Cactus",
                Description = "Plante succulente adaptée aux climats arides, stockant l'eau dans ses tiges charnues.",
                ImageUrl = "https://images.pexels.com/photos/1022921/pexels-photo-1022921.jpeg",
                ScientificName = "Cactaceae sp.",
                Family = "Cactacées",
                Genus = "Cactaceae",
                Species = "sp.",
                CommonName = "Cactus",
                CareInstructions = "Exposition très ensoleillée, sol sableux et drainant. Arrosage minimal, éviter l'humidité.",
                IsIndoor = true,
                IsOutdoor = false,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 6,
                Name = "Orchidée",
                Description = "Plante épiphyte aux fleurs spectaculaires, symbole d'élégance et de raffinement.",
                ImageUrl = "https://images.pexels.com/photos/918962/pexels-photo-918962.jpeg",
                ScientificName = "Phalaenopsis sp.",
                Family = "Orchidacées",
                Genus = "Phalaenopsis",
                Species = "sp.",
                CommonName = "Orchidée papillon",
                CareInstructions = "Exposition lumineuse sans soleil direct, substrat spécial orchidées. Arrosage par trempage, humidité élevée.",
                IsIndoor = true,
                IsOutdoor = false,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 7,
                Name = "Menthe",
                Description = "Plante aromatique vivace très rustique, utilisée en cuisine et phytothérapie pour ses propriétés digestives.",
                ImageUrl = "https://images.pexels.com/photos/1264000/pexels-photo-1264000.jpeg",
                ScientificName = "Mentha spicata",
                Family = "Lamiacées",
                Genus = "Mentha",
                Species = "spicata",
                CommonName = "Menthe verte",
                CareInstructions = "Exposition mi-ombre, sol humide et riche. Arrosage fréquent, contenir la propagation.",
                IsIndoor = true,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 8,
                Name = "Tulipe",
                Description = "Bulbe printanier aux fleurs colorées, symbole du printemps et de la renaissance.",
                ImageUrl = "https://images.pexels.com/photos/69776/tulips-bed-colorful-color-69776.jpeg",
                ScientificName = "Tulipa gesneriana",
                Family = "Liliacées",
                Genus = "Tulipa",
                Species = "gesneriana",
                CommonName = "Tulipe de jardin",
                CareInstructions = "Plantation automnale, exposition ensoleillée, sol bien drainé. Arrosage modéré au printemps.",
                IsIndoor = false,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 9,
                Name = "Bambou",
                Description = "Graminée géante à croissance rapide, utilisée en construction et décoration d'intérieur.",
                ImageUrl = "https://images.pexels.com/photos/405034/pexels-photo-405034.jpeg",
                ScientificName = "Bambusa vulgaris",
                Family = "Poacées",
                Genus = "Bambusa",
                Species = "vulgaris",
                CommonName = "Bambou commun",
                CareInstructions = "Exposition lumineuse, sol riche et humide. Arrosage fréquent, contenir la propagation.",
                IsIndoor = true,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 10,
                Name = "Palmier",
                Description = "Arbre tropical aux feuilles en éventail, symbole des régions chaudes et des vacances.",
                ImageUrl = "https://images.pexels.com/photos/33115827/pexels-photo-33115827.jpeg",
                ScientificName = "Phoenix canariensis",
                Family = "Arécacées",
                Genus = "Phoenix",
                Species = "canariensis",
                CommonName = "Palmier des Canaries",
                CareInstructions = "Exposition ensoleillée, sol riche et drainant. Arrosage modéré, protection hivernale.",
                IsIndoor = true,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 11,
                Name = "Thym",
                Description = "Plante aromatique méditerranéenne aux petites feuilles persistantes, très utilisée en cuisine provençale.",
                ImageUrl = "https://images.pexels.com/photos/4207793/pexels-photo-4207793.jpeg",
                ScientificName = "Thymus vulgaris",
                Family = "Lamiacées",
                Genus = "Thymus",
                Species = "vulgaris",
                CommonName = "Thym commun",
                CareInstructions = "Exposition plein soleil, sol calcaire et drainant. Arrosage minimal, tailler après floraison.",
                IsIndoor = true,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 12,
                Name = "Cyclamen",
                Description = "Plante bulbeuse aux fleurs délicates, parfaite pour égayer l'hiver avec ses couleurs vives.",
                ImageUrl = "https://images.pexels.com/photos/6508963/pexels-photo-6508963.jpeg",
                ScientificName = "Cyclamen persicum",
                Family = "Primulacées",
                Genus = "Cyclamen",
                Species = "persicum",
                CommonName = "Cyclamen de Perse",
                CareInstructions = "Exposition lumineuse sans soleil direct, sol léger et drainant. Arrosage par le dessous.",
                IsIndoor = true,
                IsOutdoor = false,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 13,
                Name = "Romarin",
                Description = "Arbrisseau méditerranéen aux feuilles persistantes très aromatiques, excellent pour les grillades.",
                ImageUrl = "https://images.pexels.com/photos/135168/pexels-photo-135168.jpeg",
                ScientificName = "Rosmarinus officinalis",
                Family = "Lamiacées",
                Genus = "Rosmarinus",
                Species = "officinalis",
                CommonName = "Romarin officinal",
                CareInstructions = "Exposition plein soleil, sol calcaire et drainant. Arrosage minimal, taille légère au printemps.",
                IsIndoor = true,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 14,
                Name = "Azalée",
                Description = "Arbuste ornemental aux fleurs spectaculaires au printemps, très apprécié pour sa floraison généreuse.",
                ImageUrl = "https://images.pexels.com/photos/1082162/pexels-photo-1082162.jpeg",
                ScientificName = "Rhododendron simsii",
                Family = "Éricacées",
                Genus = "Rhododendron",
                Species = "simsii",
                CommonName = "Azalée d'intérieur",
                CareInstructions = "Exposition lumineuse sans soleil direct, sol acide et humide. Arrosage régulier avec eau non calcaire.",
                IsIndoor = true,
                IsOutdoor = false,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 15,
                Name = "Sauge",
                Description = "Plante aromatique et médicinale aux feuilles veloutées, utilisée depuis l'Antiquité pour ses vertus.",
                ImageUrl = "https://images.pexels.com/photos/3020635/pexels-photo-3020635.jpeg",
                ScientificName = "Salvia officinalis",
                Family = "Lamiacées",
                Genus = "Salvia",
                Species = "officinalis",
                CommonName = "Sauge officinale",
                CareInstructions = "Exposition ensoleillée, sol calcaire et drainant. Arrosage modéré, tailler après floraison.",
                IsIndoor = true,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 16,
                Name = "Bégonia",
                Description = "Plante d'intérieur aux fleurs colorées et feuilles décoratives, parfaite pour les appartements.",
                ImageUrl = "https://images.pexels.com/photos/1054023/pexels-photo-1054023.jpeg",
                ScientificName = "Begonia semperflorens",
                Family = "Bégoniacées",
                Genus = "Begonia",
                Species = "semperflorens",
                CommonName = "Bégonia toujours fleuri",
                CareInstructions = "Exposition lumineuse sans soleil direct, sol riche et humide. Arrosage régulier, éviter l'eau sur les feuilles.",
                IsIndoor = true,
                IsOutdoor = false,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 17,
                Name = "Estragon",
                Description = "Plante aromatique aux feuilles fines et parfumées, indispensable dans la cuisine française.",
                ImageUrl = "https://images.pexels.com/photos/6156462/pexels-photo-6156462.jpeg",
                ScientificName = "Artemisia dracunculus",
                Family = "Astéracées",
                Genus = "Artemisia",
                Species = "dracunculus",
                CommonName = "Estragon français",
                CareInstructions = "Exposition ensoleillée, sol riche et bien drainé. Arrosage modéré, protéger du froid.",
                IsIndoor = true,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 18,
                Name = "Caoutchouc",
                Description = "Arbre d'intérieur très populaire aux grandes feuilles brillantes, excellent purificateur d'air.",
                ImageUrl = "https://images.pexels.com/photos/6801437/pexels-photo-6801437.jpeg",
                ScientificName = "Ficus benjamina",
                Family = "Moracées",
                Genus = "Ficus",
                Species = "benjamina",
                CommonName = "Ficus pleureur",
                CareInstructions = "Exposition lumineuse sans soleil direct, sol riche et drainant. Arrosage modéré, éviter les courants d'air.",
                IsIndoor = true,
                IsOutdoor = false,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 19,
                Name = "Ciboulette",
                Description = "Herbe aromatique vivace aux fines feuilles creuses, parfaite pour aromatiser les salades et fromages.",
                ImageUrl = "https://images.pexels.com/photos/1227662/pexels-photo-1227662.jpeg",
                ScientificName = "Allium schoenoprasum",
                Family = "Amaryllidacées",
                Genus = "Allium",
                Species = "schoenoprasum",
                CommonName = "Ciboulette commune",
                CareInstructions = "Exposition ensoleillée, sol riche et humide. Arrosage régulier, diviser tous les 3-4 ans.",
                IsIndoor = true,
                IsOutdoor = true,
                IsPerennial = true,
                IsAnnual = false
            },
            new Plant()
            {
                Id = 20,
                Name = "Yucca",
                Description = "Plante succulente aux feuilles rigides en forme d'épée, très résistante et décorative.",
                ImageUrl = "https://images.pexels.com/photos/7718261/pexels-photo-7718261.jpeg",
                ScientificName = "Yucca elephantipes",
                Family = "Agavacées",
                Genus = "Yucca",
                Species = "elephantipes",
                CommonName = "Yucca pied d'éléphant",
                CareInstructions = "Exposition lumineuse, sol drainant et sableux. Arrosage minimal, résistant à la sécheresse.",
                IsIndoor = true,
                IsOutdoor = false,
                IsPerennial = true,
                IsAnnual = false
            }
        };
    }
}
