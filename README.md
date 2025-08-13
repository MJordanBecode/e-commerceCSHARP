# E-Commerce C# / Angular Project

## Description

Ce projet est une application e-commerce full-stack utilisant **C# .NET 9** pour le backend et **Angular 20** pour le frontend.\
Le backend expose des API REST via **ASP.NET Core Web API** et utilise **Entity Framework Core** avec **PostgreSQL** pour la gestion des données.\
Le frontend est développé avec **Angular**, et consomme les API pour afficher et gérer les produits, utilisateurs et commandes.

De plus, **SignalR** sera utilisé pour des fonctionnalités en temps réel, telles que les notifications ou les mises à jour dynamiques du panier.\
Les paiements seront gérés via **Stripe** pour une intégration sécurisée et fiable.

---

## Technologies utilisées

### Frontend (Angular)

- **Angular 20** (Core, Forms, Router, Animations, CDK)
- **@ngx-translate/core & @ngx-translate/http-loader** : support multi-langues
- **ngx-logger** : logging côté client
- **ngx-mask** : gestion des masques sur les formulaires
- **ngx-pagination** : pagination des listes
- **ngx-toastr** : notifications toast
- **rxjs** : gestion des flux réactifs
- **TypeScript 5** & **zone.js**
- **Dompurify** : protection contre les XSS
- **Karma / Jasmine** : tests unitaires

### Backend (C# .NET)

- **.NET 9**
- **ASP.NET Core Web API**
- **Entity Framework Core** avec **PostgreSQL** (`Npgsql.EntityFrameworkCore.PostgreSQL`)
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore** : gestion des utilisateurs et rôles
- **Microsoft.AspNetCore.OpenApi** : génération de documentation API via Swagger
- **Bogus** : génération de données factices pour tests
- **SignalR** : communication temps réel (notifications, updates live)
- **Stripe** : gestion des paiements

---

## Fonctionnalités prévues

- Gestion des utilisateurs (inscription, connexion, rôles)
- Gestion des produits (CRUD)
- Gestion des commandes et panier
- Internationalisation (multi-langues)
- Notifications et mises à jour en temps réel via SignalR
- Paiements sécurisés avec Stripe
- API documentée avec Swagger pour faciliter les tests

---

## Installation

### Frontend

```bash
cd Frontend
npm install
ng serve
```

Le frontend sera disponible sur `http://localhost:4200`.

### Backend

```bash
cd Backend
dotnet restore
# Installer SignalR
dotnet add package Microsoft.AspNetCore.SignalR
# Installer Stripe
dotnet add package Stripe.net
# Installer Npgsql pour PostgreSQL si ce n'est pas déjà fait
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

dotnet ef database update
dotnet run
```

Le backend sera disponible sur `https://localhost:5001`.

---

## SignalR

1. Ajouter le package NuGet `Microsoft.AspNetCore.SignalR`.
2. Créer un Hub :

```csharp
public class NotificationHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
```

3. Configurer le Hub dans `Program.cs` ou `Startup.cs` :

```csharp
app.MapHub<NotificationHub>("/notificationHub");
```

4. Côté Angular, installer le client SignalR : `npm install @microsoft/signalr` et se connecter au Hub.

---

## Tests

- Tests unitaires Angular : `ng test`
- Tests backend avec EF Core et .NET Test : `dotnet test`

---

## Notes

- Utilisation de **EF Core migrations** pour gérer les évolutions de la base de données.
- SignalR permet de pousser des données en temps réel aux clients connectés.
- Stripe intégré pour les paiements sécurisés.
- Swagger intégré pour tester facilement les endpoints API.

---

## Auteur

- **Jordan** – Développeur full-stack

