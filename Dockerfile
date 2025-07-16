# Используем официальный образ SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Создаём рабочую директорию
WORKDIR /app

# Копируем файлы проекта и solution
COPY . ./

# Восстанавливаем зависимости
RUN dotnet restore Deeplom.sln

# Собираем проект
RUN dotnet build Deeplom.sln -c Release --no-restore

# (опционально) Публикуем как self-contained приложение
RUN dotnet publish Deeplom.sln -c Release -o /app/publish --no-build

# Используем рантайм-образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app

# Копируем опубликованное приложение из предыдущего stage
COPY --from=build /app/publish .

# Открываем порт (если нужно)
EXPOSE 80

# Запуск (замени на свою точку входа, если нужно)
ENTRYPOINT ["dotnet", "Deeplom.dll"]
