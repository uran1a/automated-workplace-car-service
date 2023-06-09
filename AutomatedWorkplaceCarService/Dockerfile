#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AutomatedWorkplaceCarService/AutomatedWorkplaceCarService.csproj", "AutomatedWorkplaceCarService/"]
COPY ["AutomatedWorkplaceCarService.Services/AutomatedWorkplaceCarService.Services.csproj", "AutomatedWorkplaceCarService.Services/"]
COPY ["AutomatedWorkplaceCarService.Models/AutomatedWorkplaceCarService.Models.csproj", "AutomatedWorkplaceCarService.Models/"]
RUN dotnet restore "AutomatedWorkplaceCarService/AutomatedWorkplaceCarService.csproj"
COPY . .
WORKDIR "/src/AutomatedWorkplaceCarService"
RUN dotnet build "AutomatedWorkplaceCarService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutomatedWorkplaceCarService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutomatedWorkplaceCarService.dll"]
