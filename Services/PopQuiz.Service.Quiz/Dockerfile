#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 4201

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ./Services/PopQuiz.Service.Quiz/PopQuiz.Service.Quiz.csproj Services/PopQuiz.Service.Quiz/
COPY ./Services/PopQuiz.Service.Quiz.Infrastructure/PopQuiz.Service.Quiz.Infrastructure.csproj Services/PopQuiz.Service.Quiz.Infrastructure/
COPY ./Services/PopQuiz.Service.Quiz.Domain/PopQuiz.Service.Quiz.Domain.csproj Services/PopQuiz.Service.Quiz.Domain/
COPY ./Services/PopQuiz.Service.Common/PopQuiz.Service.Common.csproj Services/PopQuiz.Service.Common/
COPY ./Services/PopQuiz.Service.Quiz.Application.Interfaces/PopQuiz.Service.Quiz.Application.Interfaces.csproj Services/PopQuiz.Service.Quiz.Application.Interfaces/
COPY ./Services/PopQuiz.Service.Common.Web/PopQuiz.Service.Common.Web.csproj Services/PopQuiz.Service.Common.Web/
COPY ./Services/PopQuiz.Service.Quiz.Persistence/PopQuiz.Service.Quiz.Persistence.csproj Services/PopQuiz.Service.Quiz.Persistence/
COPY ./Services/PopQuiz.Service.Quiz.Application/PopQuiz.Service.Quiz.Application.csproj Services/PopQuiz.Service.Quiz.Application/
RUN dotnet restore "Services/PopQuiz.Service.Quiz/PopQuiz.Service.Quiz.csproj"
COPY . .
WORKDIR "/src/Services/PopQuiz.Service.Quiz"
RUN dotnet build "PopQuiz.Service.Quiz.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PopQuiz.Service.Quiz.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PopQuiz.Service.Quiz.dll"]