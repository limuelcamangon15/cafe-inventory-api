# 1. Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# 2. Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# 3. Copy the rest of the code and publish
COPY . ./
RUN dotnet publish -c Release -o out

# 4. Use the runtime image for smaller container
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# 5. Set environment variable for ASP.NET Core to listen on all ports
ENV ASPNETCORE_URLS=http://+:5000

# 6. Expose the port
EXPOSE 5000

# 7. Start the app
ENTRYPOINT ["dotnet", "CafeInventoryApi.dll"]
