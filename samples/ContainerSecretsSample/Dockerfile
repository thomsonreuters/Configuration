# docker build -t container-secrets-sample -f Dockerfile ../../

FROM buildpack-deps:stretch-scm

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        libc6 \
        libcurl3 \
        libgcc1 \
        libgssapi-krb5-2 \
        libicu57 \
        liblttng-ust0 \
        libssl1.0.2 \
        libstdc++6 \
        libunwind8 \
        libuuid1 \
        zlib1g \
        unzip \
    && rm -rf /var/lib/apt/lists/*


ENV PATH="/root/.dotnet/:${PATH}"

COPY . ./

RUN ./run.sh install-tools \
    && dotnet help

RUN dotnet restore /samples/ContainerSecretsSample/ContainerSecretsSample.csproj
RUN dotnet publish -c Release --framework netcoreapp2.1 -o /app /samples/ContainerSecretsSample/ContainerSecretsSample.csproj

WORKDIR /app
ENTRYPOINT ["dotnet", "ContainerSecretsSample.dll"]


