using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests {
    class JsonReaderTests {

        class Test {
            public int Property1 { get; set; }
            public string Property2 { get; set; }
            public bool Property3 { get; set; }
        }

        [Test]
        public  void read_valid_json_should_return_object() {
            Test test = JsonReader<Test>.read("Assets/Tests/Engine/test_ok.json");
            Assert.AreEqual(5, test.Property1);
        }

        [Test]
        public void read_invalid_json_should_throw_exception() {
            Assert.Throws<JsonReaderException>(
                delegate {
                    JsonReader<Test>.read("Assets/Tests/Engine/test_ko.json");
                }
            );
        }

    }
}
