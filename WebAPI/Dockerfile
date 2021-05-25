FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef

COPY . /app
WORKDIR /app

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

EXPOSE 80/tcp

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh


#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
#WORKDIR /app
#
#COPY *.csproj ./
#RUN dotnet restore
#
#COPY . ./
#RUN dotnet publish -c Release -o out
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0
#WORKDIR /app
#EXPOSE 80/tcp
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "WebAPI.dll"]

#RUN chmod +x ./entrypoint.sh
#CMD /bin/bash ./entrypoint.sh
