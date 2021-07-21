$currentPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
$dockerfilePath = -Join($currentPath, "\dockerfile")
$manifestPath = -Join($currentPath, "\manifest.yml")
$dockerImageTag = "registry.cn-hangzhou.aliyuncs.com/lungchito/xxl-job-admin"

docker build -f $dockerfilePath --force-rm -t $dockerImageTag $currentPath
docker push $dockerImageTag
cf push -f $manifestPath
pause