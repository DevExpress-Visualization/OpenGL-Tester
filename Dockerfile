# Set build enviroument
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
# Copy the .csproj file and restore the project's dependencies
COPY *.csproj ./
RUN dotnet restore
# Copy project files and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Set runtime enviroument
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS runtime
WORKDIR /app

# Install the latest version of the libgdiplus library to use System.Drawing in the application
RUN apt update
RUN apt install -y libgdiplus libc6 libc6-dev
RUN apt install -y fontconfig libharfbuzz0b libfreetype6

# (Optional step) Install the ttf-mscorefonts-installer package to use Microsoft TrueType core fonts in the application
# RUN echo "deb http://deb.debian.org/debian stretch contrib" >> /etc/apt/sources.list
# RUN apt-get update
# RUN apt-get install -y ttf-mscorefonts-installer  

# Install OpenGL libraries
RUN apt install -y libglu1-mesa libosmesa6

COPY --from=build-env /app/out .
# Define the entry point for the application
ENTRYPOINT ["dotnet", "OpenGLTester.dll"]
