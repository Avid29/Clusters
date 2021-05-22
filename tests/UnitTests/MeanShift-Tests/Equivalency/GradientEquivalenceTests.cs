﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using Tests.Shapes;
using Tests.Tests.Gradient;

namespace Tests.MeanShift.Equivalency
{
    [TestClass]
    public class GradientEquivalenceTests
    {
        [TestMethod]
        public void Weighted()
        {
            foreach (var test in GradientTests.All1D)
            {
                Equivalency.RunWeightedTest<double, DoubleShape, (double, double)>(test);
            }

            foreach (var test in GradientTests.All2D)
            {
                Equivalency.RunWeightedTest<Vector2, Vector2Shape, (Vector2, double)>(test);
            }
        }

        [TestMethod]
        public void MultiThreaded()
        {
            foreach (var test in GradientTests.All1D)
            {
                Equivalency.RunMultiThreadedTest<double, DoubleShape, (double, double)>(test);
            }

            foreach (var test in GradientTests.All2D)
            {
                Equivalency.RunMultiThreadedTest<Vector2, Vector2Shape, (Vector2, double)>(test);
            }
        }

        [TestMethod]
        public void WeightedMultiThreaded()
        {
            foreach (var test in GradientTests.All1D)
            {
                Equivalency.RunWeightedMultiThreadedTest<double, DoubleShape, (double, double)>(test);
            }

            foreach (var test in GradientTests.All2D)
            {
                Equivalency.RunWeightedMultiThreadedTest<Vector2, Vector2Shape, (Vector2, double)>(test);
            }
        }
    }
}