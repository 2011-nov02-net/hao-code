FROM mcr.microsoft.com/dotnet/sdk:5.0

WORKDIR /app



# Copy everything else and build
COPY . ./
 
RUN dotnet publish -o publish

# configure it with the command it will use to start containers.
# this runs at the start of "docker run"
CMD dotnet publish/MVCVM.WebApp.dll