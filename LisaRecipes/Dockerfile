#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LisaRecipes/LisaRecipes.csproj", "LisaRecipes/"]
COPY ["LisaRecipes.Configuration/LisaRecipes.Configuration.csproj", "LisaRecipes.Configuration/"]
COPY ["LisaRecipes.Application/LisaRecipes.Application.csproj", "LisaRecipes.Application/"]
COPY ["LisaRecipes.Contracts/LisaRecipes.Contracts.csproj", "LisaRecipes.Contracts/"]
COPY ["LisaRecipies.Domain/LisaRecipes.Domain.csproj", "LisaRecipies.Domain/"]
COPY ["LisaRecipes.PersistenceEF/LisaRecipes.PersistenceEF.csproj", "LisaRecipes.PersistenceEF/"]
RUN dotnet restore "LisaRecipes/LisaRecipes.csproj"
COPY . .
WORKDIR "/src/LisaRecipes"
RUN dotnet build "LisaRecipes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LisaRecipes.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LisaRecipes.dll"]