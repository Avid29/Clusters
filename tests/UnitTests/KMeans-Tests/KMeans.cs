using ClusterNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using Tests.Shapes;

namespace Tests.KMeans
{
    [TestClass]
    public class KMeans
    {
        [TestMethod]
        public void DoubleTest1()
        {
            ClusterAlgorithms.KMeans<double, DoubleShape>(
                DoubleTests.DoubleTest1.Input,
                DoubleTests.DoubleTest1.ExpectedClusterCount);
        }

        [TestMethod]
        public void Vector2Test1()
        {
            ClusterAlgorithms.KMeans<Vector2, Vector2Shape>(
                Vector2Tests.Vector2Test1.Input,
                Vector2Tests.Vector2Test1.ExpectedClusterCount);
        }
    }
}