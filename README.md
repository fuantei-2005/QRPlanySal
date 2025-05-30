# QRPlanySal
Projekt składa się z strony zrobionej za pomocą React, API stworzonego w C# ASP .Net Core MVC, oraz bazy danych stworzonej w MySQL.
## Strona
Strona oferuje możliwość wybrania sali do sprawdzenia jej planu lekcji. Każda sala oferuje takie informacje:
- Wychowawca
- Dodatkowe informacje
- Lekcje, w tym;
  - Numer lekcji
  - Czas trwania
  - Przedmiot
  - Nauczyciel
  - Klasa
Po przejściu na podstronę /admin można zalogować się jako administrator. Po zalogowaniu jako administrator na stronię sali jest dodatkowo pokazywany przycisk do wydrukowania kodu QR.

## API
API jest stworzone w C# ASP .Net Core MVC, obsługuję każda metodę (GET, PUT, POST, DELETE) dla każdej z tabeli z bazy danych.

## Baza Danych
Baza danych jest stworzona w MySQL. Ma przykładowe dane aby testować funkcjonalność projektu.
Zawiera dane dla:
- Przedmiotów
- Klas
- Nauczycieli
- Lekcji
- Sal

# Prerequisites
- Visual Studio 2022
- NET 8.0
- Node.js
- MySQL

# Instalacja
1. Zimportuj Bazę Danych do twojego programu zarządzającego baz danych
2. Otwórz i zbuduj API w Visual Studio 2022 w konfiguracji Release
3. Włącz API
4. Pobierz wszystkie potrzebne paczki dla strony używając npm install
5. Włącz stronę 
