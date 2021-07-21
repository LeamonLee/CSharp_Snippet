$currentPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
$deploymentFilePath = -Join($currentPath, "\deployment.yaml")
$serviceFilePath = -Join($currentPath, "\service.yaml")
$ingressFilePath = -Join($currentPath, "\ingress.yaml")

kubectl apply -f $deploymentFilePath
kubectl apply -f $serviceFilePath
kubectl apply -f $ingressFilePath
pause