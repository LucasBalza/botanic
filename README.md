# 🌿 Botanic - Application Complète

Une application complète de gestion de plantes botaniques avec **backend .NET API** et **frontend Angular**.

## 📋 Description du projet

Botanic est une application web moderne qui permet de :

- **Consulter** une base de données de plantes avec leurs informations botaniques
- **Ajouter, modifier, supprimer** des plantes (avec authentification)
- **Interface moderne** avec design personnalisé en tons naturels
- **Authentification JWT** pour sécuriser les opérations sensibles

### 🌱 Fonctionnalités principales

#### Backend (.NET API)

- **20 plantes** pré-chargées avec informations complètes
- **Authentification JWT** pour sécuriser les endpoints sensibles
- **Documentation Swagger** complète avec exemples
- **Base de données en mémoire** pour le développement
- **API RESTful** avec codes de statut HTTP appropriés
- **CORS configuré** pour le frontend Angular

#### Frontend (Angular)

- **Interface moderne** avec design personnalisé
- **Authentification** avec gestion des tokens JWT
- **Liste des plantes** avec cartes visuelles
- **Détails des plantes** avec informations complètes
- **Ajout de plantes** avec formulaire complet
- **Design responsive** pour tous les écrans
- **Tons naturels** (verts) pour l'interface

## 🛠️ Technologies utilisées

### Backend

- **.NET 8.0** - Framework principal
- **ASP.NET Core** - Framework web
- **Entity Framework Core** - ORM pour la base de données
- **JWT Bearer** - Authentification
- **Swagger/OpenAPI** - Documentation de l'API
- **C#** - Langage de programmation

### Frontend

- **Angular 17** - Framework frontend
- **TypeScript** - Langage de programmation
- **RxJS** - Programmation réactive
- **HttpClient** - Communication avec l'API
- **Reactive Forms** - Gestion des formulaires
- **CSS personnalisé** - Design moderne et responsive
- **Font Awesome** - Icônes

## 📁 Structure du projet

```
botanic/
├── backend/                    # Backend .NET API
│   └── botanic/
│       ├── Controllers/        # Contrôleurs de l'API
│       │   ├── PlantController.cs
│       │   ├── UserController.cs
│       │   └── LoginController.cs
│       ├── Data/               # Couche d'accès aux données
│       │   ├── BotanicDbContext.cs
│       │   ├── Plants.cs       # Données de test des plantes
│       │   └── Users.cs        # Données de test des utilisateurs
│       ├── Dtos/               # Objets de transfert de données
│       │   ├── PlantDto.cs
│       │   ├── UserDto.cs
│       │   └── UserDisplayDto.cs
│       ├── Models/             # Modèles de données
│       │   ├── Plant.cs
│       │   └── User.cs
│       ├── Utils/              # Utilitaires
│       │   └── PlantExtension.cs
│       ├── Program.cs          # Point d'entrée de l'application
│       ├── appsettings.json    # Configuration
│       └── botanic.csproj      # Fichier projet
├── frontend/                   # Frontend Angular
    ├── src/
    │   ├── app/
    │   │   ├── components/     # Composants Angular
    │   │   │   ├── login/
    │   │   │   ├── plant-list/
    │   │   │   ├── plant-detail/
    │   │   │   └── plant-add/
    │   │   ├── services/       # Services Angular
    │   │   │   ├── auth.service.ts
    │   │   │   ├── plant.service.ts
    │   │   │   └── user.service.ts
    │   │   ├── models/         # Modèles TypeScript
    │   │   │   ├── plant.ts
    │   │   │   └── user.ts
    │   │   ├── app.module.ts   # Module principal
    │   │   ├── app-routing.module.ts
    │   │   └── app.component.ts
    │   ├── assets/             # Ressources statiques
    │   ├── styles.css          # Styles globaux
    │   └── index.html          # Page HTML principale
    ├── angular.json            # Configuration Angular
    ├── package.json            # Dépendances npm
    └── tsconfig.json           # Configuration TypeScript
```

## 🚀 Instructions d'installation et d'exécution

### Prérequis

#### Pour le Backend

- **Visual Studio 2022** (Community, Professional ou Enterprise)
- **.NET 8.0 SDK** (inclus avec Visual Studio 2022)
- **Git** (pour cloner le projet)

#### Pour le Frontend

- **Node.js** (version 18 ou supérieure)
- **npm** (inclus avec Node.js)
- **Angular CLI** (sera installé automatiquement)

### Étapes d'installation

#### 1. Cloner le projet

```bash
git clone [URL_DU_REPO]
cd botanic
```

#### 2. Installation du Backend

##### Option A : Visual Studio 2022 (Recommandé)

1. **Ouvrir Visual Studio 2022**
2. Cliquer sur **"Ouvrir un projet ou une solution"**
3. Naviguer vers le dossier `backend/botanic`
4. Sélectionner le fichier `botanic.sln`
5. Cliquer sur **"Ouvrir"**
6. **Restaurer les packages NuGet**

   - Clic droit sur la solution `botanic` dans l'Explorateur de solutions
   - Sélectionner **"Restaurer les packages NuGet"**
   - Attendre que la restauration soit terminée
7. **Compiler le projet**

   - Menu **Générer** → **Générer la solution** (ou `Ctrl+Shift+B`)
   - Vérifier qu'il n'y a pas d'erreurs de compilation

##### Option B : Ligne de commande

```bash
cd backend/botanic
dotnet restore
dotnet build
```

#### 3. Installation du Frontend

```bash
cd frontend
npm install
```

#### 4. Lancer l'application

##### Lancer le Backend

**Avec Visual Studio :**

1. Appuyer sur **F5** ou cliquer sur le bouton **"Démarrer"** (triangle vert)
2. L'application va se lancer et ouvrir automatiquement Swagger dans le navigateur

**Avec la ligne de commande :**

```bash
cd backend/botanic
dotnet run
```

Le backend sera accessible sur :

- **API** : `http://localhost:5229`
- **Swagger** : `http://localhost:5229/swagger`

##### Lancer le Frontend

```bash
cd frontend
ng serve
```

Le frontend sera accessible sur :

- **Application** : `http://localhost:4200`

## 🌐 Utilisation de l'application

### 1. Accès à l'application

1. **Ouvrir votre navigateur**
2. **Aller sur** `http://localhost:4200`
3. **Vous serez redirigé** vers la page de connexion

### 2. Se connecter

**Identifiants de test :**

- **Nom d'utilisateur** : `lucas`
- **Mot de passe** : `password`

### 3. Utiliser l'application

#### 📋 Liste des plantes

- **Voir toutes les plantes** avec leurs informations
- **Cliquer sur une plante** pour voir les détails
- **Bouton "Ajouter une plante"** pour créer une nouvelle plante

#### 🔍 Détails d'une plante

- **Informations complètes** de la plante
- **Image de la plante** (si disponible)
- **Propriétés** (intérieur/extérieur, vivace/annuelle)
- **Boutons d'action** pour modifier/supprimer

#### ➕ Ajouter une plante

- **Formulaire complet** avec tous les champs
- **Validation en temps réel**
- **Seul le nom est obligatoire**
- **Tous les autres champs sont optionnels**

## 🔧 Configuration

### Backend Configuration

#### Fichier appsettings.json

```json
{
  "Jwt": {
    "Key": "tgsQcZNPgD20mNbJmcF9hDIPuLPkyOa0",
    "Issuer": "http://localhost:5229",
    "Audience": "http://localhost:5229"
  }
}
```

#### CORS Configuration

Le backend est configuré pour accepter les requêtes du frontend Angular :

- **Origine autorisée** : `http://localhost:4200`
- **Credentials** : Autorisés

### Frontend Configuration

#### API URL

Le frontend est configuré pour communiquer avec le backend sur :

- **URL de l'API** : `http://localhost:5229`

#### Authentification

- **Token JWT** stocké dans le localStorage
- **Expiration automatique** après 15 minutes
- **Redirection automatique** vers la page de connexion

## 🌱 Données de test incluses

### Plantes disponibles (20 plantes françaises)

- **Lavande** - Plante aromatique méditerranéenne
- **Rosier** - Arbuste ornemental
- **Basilic** - Herbe aromatique annuelle
- **Fougère** - Plante primitive
- **Cactus** - Plante succulente
- **Orchidée** - Plante épiphyte
- **Menthe** - Plante aromatique vivace
- **Tulipe** - Bulbe printanier
- **Bambou** - Graminée géante
- **Palmier** - Arbre tropical
- **Thym** - Plante aromatique méditerranéenne
- **Cyclamen** - Plante bulbeuse
- **Romarin** - Arbrisseau méditerranéen
- **Azalée** - Arbuste ornemental
- **Sauge** - Plante aromatique et médicinale
- **Bégonia** - Plante d'intérieur
- **Estragon** - Plante aromatique
- **Ficus** - Arbre d'intérieur
- **Ciboulette** - Herbe aromatique vivace
- **Yucca** - Plante succulente

### Utilisateurs de test

- **Username** : `lucas`
- **Password** : `password`
- **Role** : `Administrator`


## 📚 Documentation technique

### Architecture

#### Backend

- **Pattern MVC** : Modèle-Vue-Contrôleur
- **Repository Pattern** : Accès aux données via Entity Framework
- **DTO Pattern** : Objets de transfert pour l'API
- **JWT Authentication** : Authentification par token

#### Frontend

- **Component-based architecture** : Composants Angular réutilisables
- **Service pattern** : Services pour la logique métier
- **Reactive forms** : Formulaires réactifs avec validation
- **HTTP Interceptors** : Gestion automatique des tokens

### Sécurité

- **JWT Bearer** : Authentification sécurisée
- **CORS** : Configuration pour les origines autorisées
- **Validation** : Validation des données d'entrée
- **Séparation des rôles** : Endpoints publics et protégés

### Performance

- **Base de données en mémoire** : Accès rapide aux données
- **Async/Await** : Opérations asynchrones
- **Lazy loading** : Chargement à la demande
- **Optimized bundles** : Bundles optimisés par Angular
