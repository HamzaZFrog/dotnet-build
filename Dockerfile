# Use the official .NET SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the project file and restore the NuGet packages
COPY ["src/MyDotNetApp/MyDotNetApp.csproj", "src/MyDotNetApp/"]
RUN dotnet restore "src/MyDotNetApp/MyDotNetApp.csproj"

# Copy the remaining source files and build the application
COPY . .
WORKDIR /src/src/MyDotNetApp
RUN dotnet publish "MyDotNetApp.csproj" -c Release -o /app/publish

# Use a runtime image to run the executable
FROM mcr.microsoft.com/dotnet/runtime-deps:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Specify the entry point for the application
ENTRYPOINT ["./MyDotNetApp"]

