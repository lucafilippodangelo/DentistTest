FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["LdDevWebApp/LdDevWebApp.csproj", "LdDevWebApp/"]
RUN dotnet restore "LdDevWebApp/LdDevWebApp.csproj"
COPY . .
WORKDIR "/src/LdDevWebApp"
RUN dotnet build "LdDevWebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LdDevWebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LdDevWebApp.dll"]