using NUnit.Framework;
using System;

namespace Tests {
    class JsonReaderTests {

        class Test {
            public int Property1;
            public string Property2;
            public bool Property3;
        }

        [Test]
        public  void read_valid_json_should_return_object() {
            Test test = JsonReader<Test>.read("Assets/Tests/Engine/test_ok.json");
            Assert.AreEqual(5, test.Property1);
        }

        [Test]
        public void read_invalid_json_should_throw_exception() {
            Assert.Throws<Exception>(
                delegate {
                    JsonReader<Test>.read("Assets/Tests/Engine/test_ko.json");
                }
            );
        }

    }
}
