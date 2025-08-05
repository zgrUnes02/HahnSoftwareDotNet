## Setup and Installation

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)  
- SQL Server (or your preferred database)  
- [Entity Framework Core CLI tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) (optional but recommended)

### Steps

```bash
git clone https://github.com/zgrUnes02/HahnSoftwareDotNet.git
cd HahnSoftware
cd Infrastructure
dotnet ef database update
cd ../API
dotnet run
