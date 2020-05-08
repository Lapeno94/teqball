using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.TeqBall.Host.Infrastructure
{
    public class ConnectionOptions
    {
        public string MongoDbCluster { get; set; }

        public string MongoDatabase { get; set; }
    }
}
