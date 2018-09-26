FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 58226
EXPOSE 44370

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["InventoryAPI/InventoryAPI.csproj", "InventoryAPI/"]
RUN dotnet restore "InventoryAPI/InventoryAPI.csproj"
COPY . .
WORKDIR "/src/InventoryAPI"
RUN dotnet build "InventoryAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "InventoryAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "InventoryAPI.dll"]