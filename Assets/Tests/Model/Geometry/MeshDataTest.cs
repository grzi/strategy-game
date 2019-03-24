

using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class MeshDataTest
    {
        [Test]
        public void merge_null_should_do_nothing()
        { 
            MeshData someMesh = GeometryEngine.createQuad(GeometryEngine.Cubeside.FRONT);
            MeshData sample = GeometryEngine.createQuad(GeometryEngine.Cubeside.FRONT);
            someMesh.Merge(null);

            Assert.AreEqual(someMesh.Vertices, sample.Vertices);
            Assert.AreEqual(someMesh.UVs, sample.UVs);
            Assert.AreEqual(someMesh.Normals, sample.Normals);
            Assert.AreEqual(someMesh.Triangles, sample.Triangles);
        }

        [Test]
        public void merge_ok_should_merge_with_updated_normals()
        {
            MeshData someMesh = new MeshData(
                 new List<Vector3> { new Vector3(1, 1, 1) },
                 new List<Vector3> { new Vector3(2, 2, 2) },
                 new List<int> { 1 },
                 new List<Vector2> { new Vector2(3, 3) }
                );
            MeshData sample = new MeshData(
                 new List<Vector3> { new Vector3(1, 2, 3) },
                 new List<Vector3> { new Vector3(2, 4, 5) },
                 new List<int> { 1 },
                 new List<Vector2> { new Vector2(3, 4) }
                );

            someMesh.Merge(sample);

            Assert.AreEqual(new List<Vector3> { new Vector3(1, 1, 1), new Vector3(1, 2, 3) }, someMesh.Vertices);
            Assert.AreEqual(new List<Vector3> { new Vector3(2, 2, 2), new Vector3(2, 4, 5) }, someMesh.Normals);
            Assert.AreEqual(new List<int> { 1, 2 }, someMesh.Triangles);
            Assert.AreEqual(new List<Vector2> { new Vector3(3, 3), new Vector2(3, 4) }, someMesh.UVs);


        }
    }
}
