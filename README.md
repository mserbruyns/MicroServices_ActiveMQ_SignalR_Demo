# Demo Docker/OpenShift/ActiveMQ

### Benodigdheden
- Virtualization -> BIOS vtx
- Hyper-V
- Docker
  - Docker toolbox voor w7
- VS2017
  - Net core

### SQL
- SQL lokaal installeren of 
  - Docker
    - https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker
    - https://hub.docker.com/r/microsoft/mssql-server-linux/
    - Genoeg geheugen nodig
    - Sa passwoord kiezen
    - Via SQL management connecteren poort 192.168.99.100,1401
      - Sa
      - 33t@dmin
    - Database aanmaken
      - Pakjes
    - Login aanmaken
      - Pakjes
      - Enforce pw policy uitzetten
      - Pakjes
      - User mapping
      - Pakjes DB
        - Db_owner
- Connectionstring aanpassen in appsettings.json
- Package manager console
  - Set default .db
  - Update-database
    - Gaat migrations runnen

### Message Broker
#### Rabbitmq 
Staat momenteel op docker in container geinstalleerd (kan ook lokaal)  
https://hub.docker.com/_/rabbitmq/  

docker run -d --hostname my-rabbit --name some-rabbit rabbitmq:3  
docker run -d --hostname my-rabbit --name some-rabbit rabbitmq:3-management

OF

docker run -d --hostname my-rabbit --name some-rabbit -p 4369:4369 -p 5671:5671 -p 5672:5672 -p 15672:15672 rabbitmq  
docker exec some-rabbit rabbitmq-plugins enable rabbitmq_management

address aanpassen: 192.168.99.100:5672
management = 192.168.99.100:15672
Lokaal -> Erlang nodig

#### ActiveMQ
Lokaal -> geen image op dockerhub  
Download Java JRE  
Set JAVA_HOME -> Systeemvariabele naar pad JRE en restart pc  
Download activemq  
Bin\activemq run  
Web console -> http://127.0.0.1:8161/admin/  
Queue ->  http://127.0.0.1:5762  
url aanpassen in appsettings  

Links:
https://github.com/pencil42be/workshop-netcore
https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/multi-container-microservice-net-applications/integration-event-based-microservice-communications
https://docs.microsoft.com/en-us/azure/architecture/patterns/event-sourcing
OpenShiftURL: https://openshift.gentgrp.gent.be:8443
