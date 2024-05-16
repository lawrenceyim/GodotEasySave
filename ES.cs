using Godot;
using Godot.Collections;

// Easy Save class
public class ES {
    private static readonly Dictionary<string, Dictionary> dicts = new Dictionary<string, Dictionary>();

    /* API METHODS - USE THESE FUNCTIONS TO SAVE AND LOAD DATA IN THE GAME*/

    // Example usage
    // Vector2 position = new Vector(0, 0, 0);
    // ES.Save("SaveFiles/Save1.json", "position", position);
    public static void Save(string filePath, string propertyName, Variant valueToSave) {
        Dictionary dict = GetDictionary(filePath);
        dict[propertyName] = valueToSave;
        using FileAccess file = FileAccess.Open(filePath, FileAccess.ModeFlags.Write);
        file.StoreString(Json.Stringify(dicts[filePath]));
    }

    // This function requires explicit type-casting
    // Example usage
    // Vector2 position = (Vector2) ES.Load("SaveFiles/Save1.json", "position", new Vector2(0, 0))
    public static Variant Load(string filePath, string propertyName, Variant defaultValue) {
        Dictionary dict = GetDictionary(filePath);
        if (dict.ContainsKey(propertyName)) {
            return dict[propertyName];
        }
        return defaultValue;
    }

    /* INTERNAL METHODS - DO NOT USE THESE FUNCTIONS OUTSIDE OF THE ES CLASS */
    private static Dictionary GetDictionary(string filePath) {
        if (!dicts.ContainsKey(filePath)) {
            if (System.IO.File.Exists(filePath)) {
                using FileAccess file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read);
                string content = file.GetAsText();
                Dictionary dict = Json.ParseString(content).AsGodotDictionary();
                dicts[filePath] = dict;
            } else {
                string directoryPath = System.IO.Path.GetDirectoryName(filePath);
                if (directoryPath.Length > 0 && !System.IO.Directory.Exists(directoryPath)) {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                dicts[filePath] = new Dictionary();
            }
        }
        return dicts[filePath];
    }
}

