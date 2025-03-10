# DIO Media API

This project provides a RESTful API for managing media content, including **Movies** and **Series**, along with **Genres**.

## 📌 Features
- CRUD operations for **Genres**
- CRUD operations for **Media** (Movies & Series)
- Filtering media by type (Movie or Serie)
- Soft deletion support for Medias

---

## 🚀 API Endpoints

### 🎭 **Genre Endpoints**
#### 📌 Get All Genres
```http
GET /api/genre
```
#### 📌 Get Genre by ID
```http
GET /api/genre/{id}
```
#### 📌 Add a New Genre
```http
POST /api/genre
```
**Request Body:**
```json
{
  "name": "Action"
}
```
#### 📌 Update an Existing Genre
```http
PUT /api/genre/{id}
```
#### 📌 Delete a Genre
```http
DELETE /api/genre/{id}
```

---

### 🎬 **Media Endpoints**
#### 📌 Get All Media
```http
GET /api/media
```
#### 📌 Get Media by ID
```http
GET /api/media/{id}
```
#### 📌 Get All Movies
```http
GET /api/media/movie
```
#### 📌 Get All Series
```http
GET /api/media/serie
```
#### 📌 Add a New Movie
```http
POST /api/media/movie
```
**Request Body:**
```json
{
  "title": "Inception",
  "genreId": 1,
  "year": 2010,
  "description": "A mind-bending thriller",
  "director": "Christopher Nolan",
  "durationMinutes": 148
}
```
#### 📌 Add a New Serie
```http
POST /api/media/serie
```
**Request Body:**
```json
{
  "title": "Breaking Bad",
  "genreId": 2,
  "year": 2008,
  "description": "A high school teacher turns to crime",
  "seasonNumber": 5,
  "episodeNumber": 62
}
```
#### 📌 Update a Movie
```http
PUT /api/media/movie/{id}
```
#### 📌 Update a Serie
```http
PUT /api/media/serie/{id}
```
#### 📌 Delete Media
```http
DELETE /api/media/{id}
```

---

## 🛠️ **Technologies Used**
- **ASP.NET Core** - Web API framework
- **Entity Framework Core** - ORM for database operations
- **SQLite** - Database storage
- **C#** - Main programming language

---

## 📝 **Setup & Running the Project**
### 1️⃣ Clone the repository
```sh
git clone https://github.com/linhares06/dio-bootcamp-media.git
cd dio-bootcamp-media
```
### 2️⃣ Install dependencies
```sh
dotnet restore
```
### 3️⃣ Run the application
```sh
dotnet run
```

