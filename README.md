# EvilCorp - Secure Chat (Educational)

This is a small Windows Forms educational project demonstrating basic cryptography primitives and a local messaging UI. It is intended for learning and demonstration in a controlled environment.

Features
- Login and simple user management (stored in `evilcorp.db`).
- Chat UI with selectable encryption algorithms (Caesar, Affine, Hill).
- Encrypt / Decrypt tester to try algorithms and keys.
- Dashboard with Profile, Send Messages, Encrypt/Decrypt, and Attack (demo-only) sections.
- Password storage migrated to SHA-256 hashing with a migration utility (see `DatabaseManager.MigratePlaintextPasswordsToHash`).

Security & Ethics
- This project is educational. Real offensive functionality (brute-force/dictionary/MITM) is disabled or removed.
- Passwords are stored as SHA-256 hashes in the database. For real applications use a slow KDF (PBKDF2/Argon2/Bcrypt) with per-user salts.

Run locally
1. Install .NET SDK (recommended .NET 8).
2. Open a terminal in the repository root.
3. Restore and build:
   - `dotnet nuget locals --clear all`
   - `dotnet restore`
   - `dotnet build`
4. Run:
   - `dotnet run --project EvilCorp`

Repository notes
- Main code is in the `EvilCorp/` folder. Designer files define the Windows Forms UI.
- Database file `evilcorp.db` is created in the repo root on first run.

If you encounter package restore errors, try clearing local NuGet caches and ensure internet connectivity. If a package fails to restore, I can update the project to use a different provider or help fix the specific restore error.

License
- Educational/demo only. Do not use the code to perform malicious actions.

Contact
- This project was modified by an automated assistant (GitHub Copilot) per user requests.
