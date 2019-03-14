using NUnit.Framework;
using System;
using UnityEngine;

namespace Tests
{
    class GeometryEngineTest
    {
        [Test]
        public void createQuad_front_should_create_a_good_quad()
        {
            MeshData data = GeometryEngine.createQuad(GeometryEngine.Cubeside.FRONT);

            Vector3[] vertices = new Vector3[] { 
                new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(0.5f, 0.5f, -0.5f),
                new Vector3(0.5f, -0.5f, -0.5f), new Vector3(-0.5f, -0.5f, -0.5f) };

            Assert.AreEqual(vertices, data.Vertices); 
        }
         
        [Test]
        public void createQuad_back_should_create_a_good_quad()
        {
            MeshData data = GeometryEngine.createQuad(GeometryEngine.Cubeside.BACK);

            Vector3[] vertices = new Vector3[] {
                new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(0.5f, 0.5f, 0.5f),
                new Vector3(0.5f, -0.5f, 0.5f), new Vector3(-0.5f, -0.5f, 0.5f) };

            Assert.AreEqual(vertices, data.Vertices);
        }

        [Test]
        public void createQuad_left_should_create_a_good_quad()
        {
            MeshData data = GeometryEngine.createQuad(GeometryEngine.Cubeside.LEFT);

            Vector3[] vertices = new Vector3[] {
                new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(-0.5f, 0.5f, 0.5f),
                new Vector3(-0.5f, -0.5f, 0.5f), new Vector3(-0.5f, -0.5f, -0.5f) };

            Assert.AreEqual(vertices, data.Vertices);
        }

        [Test]
        public void createQuad_right_should_create_a_good_quad()
        {
            MeshData data = GeometryEngine.createQuad(GeometryEngine.Cubeside.RIGHT);

            Vector3[] vertices = new Vector3[] {
                new Vector3(0.5f, 0.5f, -0.5f), new Vector3(0.5f, 0.5f, 0.5f),
                new Vector3(0.5f, -0.5f, 0.5f), new Vector3(0.5f, -0.5f, -0.5f) };

            Assert.AreEqual(vertices, data.Vertices);
        }

        [Test]
        public void createQuad_top_should_create_a_good_quad()
        {
            MeshData data = GeometryEngine.createQuad(GeometryEngine.Cubeside.TOP);

            Vector3[] vertices = new Vector3[] {
                new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(-0.5f, 0.5f, 0.5f),
                new Vector3(0.5f, 0.5f, 0.5f), new Vector3(0.5f, 0.5f, -0.5f) };

            Assert.AreEqual(vertices, data.Vertices);
        }

        [Test]
        public void createQuad_bottom_should_create_a_good_quad()
        {
            MeshData data = GeometryEngine.createQuad(GeometryEngine.Cubeside.BOTTOM);

            Vector3[] vertices = new Vector3[] {
                new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(-0.5f, -0.5f, 0.5f),
                new Vector3(0.5f, -0.5f, 0.5f), new Vector3(0.5f, -0.5f, -0.5f) };

            Assert.AreEqual(vertices, data.Vertices);
        }
    }
}
