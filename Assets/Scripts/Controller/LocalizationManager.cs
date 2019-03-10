using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour{

    private Dictionary<string, string> localizedText;
    
    public void LoadLocalizedText(string filepath) {
        localizedText = JsonReader<Dictionary<string, string>>.read(filepath);
    }
    
    public Dictionary<string, string> LocalizedText {
        get { return localizedText; }
    }

}


