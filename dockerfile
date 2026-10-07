FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y
ENV MSSQL_PID=Developer

ENV MSQL_SA_PASSWORD=1234

EXPOSE 1433