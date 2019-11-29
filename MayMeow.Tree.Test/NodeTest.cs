using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MayMeow.Tree.Test
{
    [TestClass]
    public class NodeTest
    {
        private IEnumerable<Location> getLocations()
        {
            return new List<Location>
            {
                new Location {Id = 1, Name = "Europe"},
                new Location {Id = 2, Name = "America"},
                new Location {Id = 3, Name = "Slovakia", ParentId = 1},
                new Location {Id = 4, Name = "Kosice", ParentId = 3},
                new Location {Id = 5, Name = "New York", ParentId = 2}
            };
        }

        [TestMethod]
        public void testNode()
        {
            var locations = getLocations();

            var rootNodes = Node<Location>.CreateTree(locations, l => l.Id, l => l.ParentId);

            var rNode = rootNodes.Where(l => l.IsRoot);

            foreach (var node in rNode)
            {
                Assert.IsTrue(node.Value.ParentId == null);
            }

            var Europe = rootNodes.SingleOrDefault(l => l.Value.Name == "Europe");

            Assert.IsTrue(Europe.Value.Id == 1);

            var Slovakia = Europe.Descendants.SingleOrDefault(n => n.Value.Name == "Slovakia");

            Assert.IsTrue(Slovakia.Value.Id == 3);
        }
    }

    public class Location
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
    }
}
