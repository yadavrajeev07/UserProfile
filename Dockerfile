# Use the official image from Microsoft for the runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
<<<<<<< HEAD:DockerFile

# Use SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["userprofileapp/userprofileapp.csproj", "userprofileapp/"]
RUN dotnet restore "userprofileapp/userprofileapp.csproj"
COPY . .
WORKDIR "/src/userprofileapp"
RUN dotnet build "userprofileapp.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "userprofileapp.csproj" -c Release -o /app/publish

# Copy build output to the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
=======
>>>>>>> 1d235de8d1b71deaa46aff6a472d82a05c676bce:Dockerfile
ENTRYPOINT ["dotnet", "userprofileapp.dll"]
