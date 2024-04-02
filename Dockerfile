FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./BackendOne.API/BackendOne.API.csproj" --disable-parallel
RUN dotnet publish "./BackendOne.API/BackendOne.API.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

ENV ASPNETCORE_URLS=http://+:4008

# ENV ASPNETCORE_URLS=http://+:4008 \
#     ConnectionStrings__Connection=mongodb://host.docker.internal:27018

WORKDIR /app
COPY --from=build /app ./
EXPOSE 4008
ENTRYPOINT ["dotnet", "BackendOne.API.dll"]

