﻿using ClusterNet.Shapes;
using System;

namespace Tests.Shapes
{
    public struct DoubleShape : IPoint<double>
    {
        public bool AreEqual(double it1, double it2)
        {
            return it1 == it2;
        }

        public bool AreEqual(double it1, double it2, double error = 0)
        {
            return FindDistanceSquared(it1, it2) <= error;
        }

        public double Average(double[] items)
        {
            double sum = 0;
            int count = 0;
            foreach (var item in items)
            {
                sum += item;
                count++;
            }
            return sum /= count;
        }

        public double Divide(double it, double count)
        {
            it /= count;
            return it;
        }

        public double FindDistanceSquared(double it1, double it2)
        {
            return Math.Abs(it1 - it2);
        }

        public double WeightedAverage((double, double)[] items)
        {
            double sum = 0;
            double totalWeight = 0;
            foreach (var item in items)
            {
                sum += item.Item1 * item.Item2;
                totalWeight += item.Item2;
            }
            return sum / totalWeight;
        }
    }
}
