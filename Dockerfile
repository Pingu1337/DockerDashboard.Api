FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build-env
WORKDIR /App

COPY . ./

RUN dotnet restore

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview
WORKDIR /app
COPY --from=build-env /App/out .

# Install docker CLI
RUN apt-get update && \
    apt-get install -y \
    docker.io \
    curl
    

# Install docker-compose CLI
RUN curl -sSL https://github.com/docker/compose/releases/latest/download/docker-compose-$(uname -s)-$(uname -m) -o /usr/local/bin/docker-compose \
    && chmod +x /usr/local/bin/docker-compose

EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000


ENTRYPOINT ["dotnet", "Host.dll"]

