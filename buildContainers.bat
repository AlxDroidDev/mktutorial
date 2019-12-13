@ECHO OFF
@SET DOCKER_BUILDKIT=1

docker container stop caseconvweb
docker container rm caseconvweb

docker container stop caseconvapi
docker container rm caseconvapi

REM docker image rm caseconversionweb
REM docker image rm caseconversionapi
REM docker image rm simonettidti/caseconversionweb
REM docker image rm simonettidti/caseconversionapi

docker network rm ccbridge

for /F %%i in ('docker images --filter "dangling=true" --format "{{.ID}}"') do docker rmi -f %%i
@ECHO ON

@cls
@cd CaseConversion.API
docker build -t caseconversionapi .
docker tag caseconversionapi simonettidti/caseconversionapi:latest

@cd ..\CaseConversion.Web
docker build -t caseconversionweb .
docker tag caseconversionweb simonettidti/caseconversionweb:latest

@cd ..
for /F %%i in ('docker images --filter "dangling=true" --format "{{.ID}}"') do docker rmi -f %%i
docker image ls -a
docker network create --driver=bridge --subnet=172.1.1.0/29 ccbridge
docker run -d --name caseconvapi --network ccbridge --rm --net-alias caseconvapi -h caseconvapi -p 81:81 -t caseconversionapi caseconversionapi
docker run -d --name caseconvweb --network ccbridge --rm --net-alias caseconvweb -h caseconvweb --env "API_HOST=caseconvapi" --env "API_PORT=81" -p 80:80 -t caseconversionweb caseconversionweb
@timeout /nobreak 5
@start http://localhost

docker push simonettidti/caseconversionapi:latest
docker push simonettidti/caseconversionweb:latest



kubectl delete namespace learning
REM kubectl delete secret simonettidti.dkr
REM kubectl delete secret simonettidti.dkr -n learning
REM kubectl delete hpa caseconv-scaler -n learning
REM kubectl delete service caseconv-service -n learning
REM kubectl delete deployment caseconv-deployment -n learning
REM kubectl create secret docker-registry simonettidti.dkr --docker-server=https://index.docker.io/v1/ --docker-username=simonettidti --docker-email=alex.simonetti@dtidigital.com.br --docker-password=Pxu1540 -n learning
@timeout /nobreak 5
kubectl apply -f Deployment.yaml
@timeout /nobreak 5
kubectl get deploy,pod,hpa,svc,ingress -n learning -o wide
@echo "You can now navigate to http://kube.arbeit.cycore.io:<nodePort>"

@REM NAVIGATE TO : http://kube.arbeit.cycore.io:32401/
