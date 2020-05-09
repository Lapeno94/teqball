# teqball

## Run
Mongodb instance in docker. https://hub.docker.com/_/mongo
Appsettings.json add the connection url of the cluster and the database name. 

```
      "Connections": {
        "MongoDbCluster": "mongodb://172.17.0.2:27017",
        "MongoDatabase": "test"
      }
```
Docker inspect for get the ipaddress if it is unbinded to localhost.

## MongoDB setting
Create index on StarDateTime and EndDateTime for query optimalization.
