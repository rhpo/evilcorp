# EvilCorp Secure Chat Application

## Build & Run
```bash
dotnet build
dotnet run --project EvilCorp
```

## Features
- SQLite database with Caesar cipher (key 13) password hashing
- Three pre-seeded users: mehdi/234, anis/54321, ramy/#esst#
- Inter-process communication via Named Pipes
- Multiple encryption algorithms: Caesar, Affine, Hill
- Dark blue UI theme with Inter font
- Secure message storage with encryption metadata

## Security
- Parameterized SQL queries prevent SQL injection
- Caesar cipher password hashing
- Named pipes for secure IPC
- Input validation for encryption keys
- No plain-text password storage
