FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
RUN apt-get update && \
    apt-get install -y python3 && \
    apt-get install -y python3-pip

RUN pip3 install --no-cache-dir boto3

COPY --from=build-env /App/out .
COPY basic.py .
COPY getsecret.py .
COPY start.py .
ENV web_version 2023.12.27.1234
ENTRYPOINT ["dotnet", "mydotnetapp.dll"]