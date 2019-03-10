
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Tests {
    public class LocalizationManagerTests {
        [Test]
        public void load_localized_with_ok_path_shouldwork() {
            LocalizationManager test = new LocalizationManager();
            test.LoadLocalizedText("Assets/Tests/Controller/tst_locales.json");

            Assert.AreEqual("value", test.LocalizedText["something"]);
            Assert.AreEqual("valueelse", test.LocalizedText["something.else"]);
        }
    }
}
