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
    // int age = (int) ES.Load("SaveFiles/Save1.json", "age", 18);
    public static Variant Load(string filePath, string propertyName, Variant defaultValue) {
        Dictionary dict = GetDictionary(filePath);
        if (dict.ContainsKey(propertyName)) {
            return dict[propertyName];
        }
        return defaultValue;
    }

    // Overloaded method for Load that returns a Vector2
    public static Vector2 Load(string filePath, string propertyName, Vector2 defaultValue) {
        Dictionary dict = GetDictionary(filePath);
        if (dict.ContainsKey(propertyName)) {
            return StringToVector2((string)dict[propertyName]);
        }
        return defaultValue;
    }

    // Overloaded method for Load that returns a Vector3
    public static Vector3 Load(string filePath, string propertyName, Vector3 defaultValue) {
        Dictionary dict = GetDictionary(filePath);
        if (dict.ContainsKey(propertyName)) {
            return StringToVector3((string)dict[propertyName]);
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

    //  Parse the string representation of a Vector2 and returns a Vector2
    private static Vector2 StringToVector2(string vector2String) {
        try {
            vector2String = vector2String.Trim('(', ')');
            string[] parts = vector2String.Split(',');
            return new Vector2(float.Parse(parts[0]), float.Parse(parts[1]));
        } catch {
            throw new System.Exception("Invalid string representation of Vector2");
        }
    }

    //  Parse the string representation of a Vector3 and returns a Vector3
    private static Vector3 StringToVector3(string vector3String) {
        try {
            vector3String = vector3String.Trim('(', ')');
            string[] parts = vector3String.Split(',');
            return new Vector3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]));
        } catch {
            throw new System.Exception("Invalid string representation of Vector3");
        }
    }
}
