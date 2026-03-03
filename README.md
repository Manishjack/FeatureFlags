Clone the repo and open in Visual Studio 2022.
.NET 8 SDK installed.
Restore dependencies
Apply EF Core migrations (creates SQLite DB)
Unit Tests (Domain & Application logic)
Integration Tests (API + DB)

Assumptions & Tradeoffs:-
Database: SQLite chosen for simplicity; in production, swap for SQL Server/Postgres.
Overrides: User > Group > Region > Global precedence.
Performance: No caching yet; direct DB lookups.
Error handling: Basic validation (duplicate keys, missing flags).
Tests: Unit tests cover core logic; integration tests spin up API with in-memory DB.

Next Steps (with more time):-
Add caching layer (e.g., Redis) for faster evaluations.
Implement admin UI for managing flags.
Add role-based security for flag mutations.
Extend overrides to support time-based rules (e.g., enable feature until a date).
Improve logging & monitoring for production readiness.
