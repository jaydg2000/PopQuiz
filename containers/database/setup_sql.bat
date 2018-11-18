docker volume create sql-data
REM docker network create --subnet=172.18.0.0/16 local_galaxy_net
REM docker run -e ACCEPT_EULA=Y -e SA_PASSWORD=P0pQu!z1313 -p 1433:1433 --name popquiz_sql -d microsoft/mssql-server-windows-developer -v sql-data:C:/temp/:C:/temp/ REM attach_dbs="[{'dbName':'PopQuiz', 'dbFiles':['C:\\temp\\PopQuiz.mdf', 'C:\\temp\\PopQuiz_log.ldf']}]"

docker run -d -p 1433:1433 --name popquiz_sql -e sa_password=P0pQu!z1313 -e ACCEPT_EULA=Y -v C:/temp/:C:/temp/ -e attach_dbs="[{'dbName':'PopQuiz', 'dbFiles':['C:\\temp\\PopQuiz.mdf', 'C:\\temp\\PopQuiz_log.ldf']}]" microsoft/mssql-server-windows-developer
docker inspect --format '{{.NetworkSettings.Networks.nat.IPAddress}}' popquiz_sql

REM --net local_galaxy_net --ip 172.18.0.22
REM 



