

#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
#WORKDIR /app

# Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore

# Copy everything else and build
#COPY . ./
#RUN dotnet publish -c Release -o out

# Build runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:5.0
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "aspnetapp.dll"]

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app


# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# environment variables
ENV ASPNETCORE_URLS http://*:80

# similar to CMD
# bin/sh -c, treats anything that is typed after it as a shell command
ENTRYPOINT ["dotnet", "out/MVCVM.WebApp.dll"]


