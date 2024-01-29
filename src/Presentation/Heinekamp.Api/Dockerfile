FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["Presentation/Heinekamp.Api/Heinekamp.Api.csproj", "Presentation/Heinekamp.Api/"]
COPY ["Core/Heinekamp.Application/Heinekamp.Application.csproj", "Core/Heinekamp.Application/"]
COPY ["Core/Heinekamp.Domain/Heinekamp.Domain.csproj", "Core/Heinekamp.Domain/"]
COPY ["Infrastructure/Heinekamp.Shared/Heinekamp.Shared.csproj", "Infrastructure/Heinekamp.Shared/"]
COPY ["Infrastructure/Heinekamp.Persistence.EntityFramework/Heinekamp.Persistence.EntityFramework.csproj", "Infrastructure/Heinekamp.Persistence.EntityFramework/"]

RUN dotnet restore "Presentation/Heinekamp.Api/Heinekamp.Api.csproj"

COPY . .

WORKDIR "/src/Presentation/Heinekamp.Api"
RUN dotnet build "Heinekamp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Heinekamp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Heinekamp.Api.dll"]