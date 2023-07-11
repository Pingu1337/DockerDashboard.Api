# Usage: ./run.sh <api_key>
# Description: This script will pull the latest docker-dashboard image from the registry and run it with the provided api key
api_key=$1

docker stop docker-dashboard
 
docker remove docker-dashboard
 
docker pull registry.null.care/docker-dashboard:latest
 
docker run -e ApiKey=$api_key -p 5000:5000 -v /var/run/docker.sock:/var/run/docker.sock -d --name docker-dashboard registry.null.care/docker-dashboard:latest