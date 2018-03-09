docker build -t container-secrets-sample -f Dockerfile ../../

kubectl delete secret test-secret
kubectl create -f secret.yaml

kubectl delete job container-secrets-sample-job
kubectl create -f job.yaml

kubectl describe -f job.yaml
