# Use the official ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# 👇 Correct path if .csproj is at root level
COPY ["userprofileapp.csproj", "."]
RUN dotnet restore "userprofileapp.csproj"

COPY . .
RUN dotnet build "userprofileapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "userprofileapp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "userprofileapp.dll"]
