# Docker file is used by the ""docker build" command to create a container image. This file does not have an extension
# Create the Docker file inside the directory containing the .csproj

# multistage buildshelps to make the image building process more efficient by drastically reducing the 
# final image size. Whydo you need multistage docker file? 

# build stage, the purpose of this stage is to compile the application
# you will have in this stage the build tools, you will copy the source code here, 
# and compile the application
# after is copied to run stage, the build stage remains untagged and can be deleted later

# mcr = Microsoft Container Registry; is a syndicate (working in common interest) of Docker which 
# hosts publicly accessible containers
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Changes the current directory inside of the container to App
WORKDIR /app

# Copy csproj and restore as distinc layer (so copy tells docker to copy the specified file from your computer
# to a folder in the container)
COPY *.csproj ./

# restore as distinct layer (restores the dependencies and tools of a project)
RUN dotnet restore

# Copy everything else and build
COPY . ./

RUN dotnet publish -c Release -o out

# run stage , the purpose is to package the application with the runtime
# run stage will launch an entirely new image build process which is independent of the first stage
# run stage will start with the base image that you created at first stage (COPY — from=build /src/output )
# run stage contains: runtime
# and the copied application form build stage
# and the base operating ssytem

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app

COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "PriceAggregator.Api.dll"]
