# Description: Build and push docker image to registry
docker build -t docker-dashboard:latest . 
 
docker tag docker-dashboard:latest registry.null.care/docker-dashboard:latest
 
docker push registry.null.care/docker-dashboard:latest