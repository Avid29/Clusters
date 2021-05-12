﻿// Adam Dernis © 2021

using ClusterNet.Kernels;
using ComputeSharp;
using System.Numerics;

namespace ClusterNet.GPU.MeanShift
{
    /// <summary>
    /// A ComputerShader generated shader for shifting points in a MeanShift operation.
    /// </summary>
    /// <remarks>
    /// This Shader is hard coded for Vector3s, Euclidean distances, and GuassianKernels.
    /// This is kind of just play time for until ComputerShader supports generics.
    /// </remarks>
    [AutoConstructor]
    internal readonly partial struct PointShiftShader : IComputeShader
    {
        /// <summary>
        /// The cluster being shifted towards the points.
        /// </summary>
        public readonly Vector3 _cluster;

        /// <summary>
        /// The original points to shift around.
        /// </summary>
        public readonly ReadOnlyBuffer<Vector3> _pointBuffer;

        /// <summary>
        /// A buffer to write the resulting weighted distances from points to the cluster.
        /// </summary>
        public readonly ReadWriteBuffer<double> _weights;

        /// <summary>
        /// The Kernel to weight use when weighting distances.
        /// </summary>
        public readonly GaussianKernel _kernel;

        /// <summary>
        /// Finds the euclidean distance between 2 Vector3s.
        /// </summary>
        /// <param name="it1">The first vector.</param>
        /// <param name="it2">The second vector.</param>
        /// <returns>The euclidean distance between the vectors.</returns>
        public static double FindDistanceSquared(Vector3 it1, Vector3 it2)
        {
            float x = it1.X - it2.X;
            float y = it1.Y - it2.Y;
            float z = it1.Z - it2.Z;

            return (x * x) + (y * y) + (z * z);
        }

        /// <inheritdoc/>
        public unsafe void Execute()
        {
            int offset = ThreadIds.X;
            Vector3 point = _pointBuffer[offset];
            Vector3Shape shape = default;

            // double weight = FindDistanceSquared(point, _cluster);
            double weight = shape.FindDistanceSquared(point, _cluster);

            weight = _kernel.WeightDistance(weight);
            _weights[offset] = weight;
        }
    }
}
