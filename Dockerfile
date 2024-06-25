# Use the official .NET SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the project file and restore the NuGet packages
COPY ["./HelloMsBuild/Hello.csproj", "."]
RUN dotnet restore "Hello.csproj"

# Copy the remaining source files and build the application
COPY . .

# Clean the obj directory to avoid duplicate attribute issues
RUN dotnet clean "Hello.csproj"

RUN mkdir -p /app/publish
RUN dotnet publish "Hello.csproj" -c Release -r win-x64 --self-contained=true -o /app/publish

# Use a runtime image to run the executable
FROM mcr.microsoft.com/dotnet/runtime-deps:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Specify the entry point for the application
ENTRYPOINT ["./HelloWorld.exe"]
