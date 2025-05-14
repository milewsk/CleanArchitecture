# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj files and restore dependencies
COPY ["src/Web/CleanArchitecture.Web.csproj", "src/Web/"]
COPY ["src/Application/CleanArchitecture.Application.csproj", "src/Application/"]
COPY ["src/Domain/CleanArchitecture.Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/CleanArchitecture.Infrastructure.csproj", "src/Infrastructure/"]

RUN dotnet restore "src/Web/CleanArchitecture.Web.csproj"

# Copy rest of procject
COPY . .
WORKDIR "/app/src/CleanArchitecture.Web"
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.Web.dll"]