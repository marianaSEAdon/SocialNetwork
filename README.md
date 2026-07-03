## Social Network 

### 🌐 Project Description

Web-based social network developed with ASP.NET Core MVC, Onion Architecture, and Entity Framework Core. 
It includes user authentication, profile management, posts, nested comments, a friendship system, and a responsive user interface.

---

## 🏛️ Architecture & Patterns

This project was developed following **Onion Architecture**, applying a clear separation of concerns across all layers.

### Key Features

- Repository Pattern with Generic Repositories
- Generic Services
- Entity Framework Core (Code First)
- ASP.NET Core Identity for authentication and authorization
- AutoMapper for entity, DTO, and ViewModel mapping
- DTOs for data transfer
- ViewModels with server-side validation
- Shared Layer for email services
- Responsive UI built with Bootstrap

---

## 🛠️ Technologies

- ASP.NET Core MVC (.NET 9)
- C#
- Entity Framework Core (Code First)
- SQL Server
- ASP.NET Core Identity
- AutoMapper
- Bootstrap 5
- Email Service (Shared Layer)

---

## 📂 Project Structure 
```text
SocialNetwork
├── .github
│   └── workflows
│
├── SocialNetwork                     # Presentation Layer
│   ├── Controllers
│   ├── Helpers
│   ├── ViewComponents
│   ├── Views
│   │   ├── Battleship
│   │   ├── FriendRequest
│   │   ├── Home
│   │   ├── Login
│   │   ├── Shared
│   │   │   └── Components
│   │   │       └── NotificationPendingCount
│   │   └── User
│   └── wwwroot
│       ├── css
│       ├── Images
│       ├── ImagesUsers
│       ├── js
│       └── lib
│
├── SocialNetwork.Core.Application    # Application Layer
│   ├── Base
│   ├── Dtos
│   │   ├── Board
│   │   ├── Comment
│   │   ├── Coordinate
│   │   ├── Email
│   │   ├── FriendRequest
│   │   ├── GameSession
│   │   ├── Move
│   │   ├── Post
│   │   ├── Reaction
│   │   ├── Ship
│   │   └── User
│   ├── Interfaces
│   ├── Mappings
│   │   ├── DtosAndViewModels
│   │   └── EntitiesAndDtos
│   ├── Services
│   └── ViewModels
│       ├── Board
│       ├── Comment
│       ├── Coordinate
│       ├── FriendRequest
│       ├── GameSession
│       ├── Move
│       ├── Post
│       ├── Reaction
│       ├── Ship
│       └── User
│
├── SocialNetwork.Core.Domain         # Domain Layer
│   ├── Base
│   │   └── Enums
│   ├── Entities
│   ├── Interfaces
│   └── Settings
│
├── SocialNetwork.Infrastructure.Identity
│   ├── Contexts
│   ├── Entities
│   ├── Migrations
│   └── Services
│
├── SocialNetwork.Infrastructure.Persistence
│   ├── Base
│   ├── Contexts
│   ├── EntityConfigurations
│   ├── Migrations
│   └── Repositories
│
└── SocialNetwork.Infrastructure.Shared
    └── Services
```

---

## 🚀 Getting Started

### 1. Clone the repository
```bash
git clone https://github.com/marianaSEAdon/SocialNetwork.git
```

### 2. Navigate to the project folder
```bash
cd SocialNetwork
```

### 3. Open the solution
Open `SocialNetwork.sln` with Visual Studio.
