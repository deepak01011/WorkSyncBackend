# .NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects
#COPY *.sln .
COPY Src/WorkSync.Application/WorkSync.Application.csproj ./Src/WorkSync.Application/
COPY Src/WorkSync.Domain/WorkSync.Domain.csproj ./Src/WorkSync.Domain/
COPY Src/WorkSync.Domain.Core/WorkSync.Domain.Core.csproj ./Src/WorkSync.Domain.Core/
COPY Src/WorkSync.Infra.CrossCutting.Bus/WorkSync.Infra.CrossCutting.Bus.csproj ./Src/WorkSync.Infra.CrossCutting.Bus/
COPY Src/WorkSync.Infra.CrossCutting.Identity/WorkSync.Infra.CrossCutting.Identity.csproj ./Src/WorkSync.Infra.CrossCutting.Identity/
COPY Src/WorkSync.Infra.CrossCutting.IoC/WorkSync.Infra.CrossCutting.IoC.csproj ./Src/WorkSync.Infra.CrossCutting.IoC/
COPY Src/WorkSync.Infra.Data/WorkSync.Infra.Data.csproj ./Src/WorkSync.Infra.Data/
COPY Src/WorkSync.Services.Api/WorkSync.Services.Api.csproj ./Src/WorkSync.Services.Api/
COPY Directory.Build.props ./Src
COPY Directory.Packages.props ./Src

# .NET Core Restore
RUN dotnet restore ./Src/WorkSync.Services.Api/WorkSync.Services.Api.csproj

# Copy All Files
COPY Src ./Src

# .NET Core Build and Publish
RUN dotnet publish ./Src/WorkSync.Services.Api/WorkSync.Services.Api.csproj -c Release -o /publish

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./

# Expose ports
EXPOSE 80
EXPOSE 443

# Setup your variables before running.
ARG MyEnv
ENV ASPNETCORE_ENVIRONMENT $MyEnv

ENTRYPOINT ["dotnet", "WorkSync.Services.Api.dll"]
