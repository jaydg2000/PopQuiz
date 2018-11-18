echo off
docker start popquiz_sql
echo "popquiz_sql running at ip:"
docker inspect --format '{{.NetworkSettings.Networks.nat.IPAddress}}' popquiz_sql
