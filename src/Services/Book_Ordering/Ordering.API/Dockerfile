#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Book_Ordering/Ordering.API/Ordering.API.csproj", "Services/Book_Ordering/Ordering.API/"]
COPY ["Services/Book_Ordering/Ordering.Application/Ordering.Application.csproj", "Services/Book_Ordering/Ordering.Application/"]
COPY ["Services/Book_Ordering/Ordering.Domain/Ordering.Domain.csproj", "Services/Book_Ordering/Ordering.Domain/"]
COPY ["Services/Book_Ordering/Ordering.Infrastucture/Ordering.Infrastucture.csproj", "Services/Book_Ordering/Ordering.Infrastucture/"]
RUN dotnet restore "Services/Book_Ordering/Ordering.API/Ordering.API.csproj"
COPY . .
WORKDIR "/src/Services/Book_Ordering/Ordering.API"
RUN dotnet build "Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]