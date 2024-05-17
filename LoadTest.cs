using Godot;

// Run this test after the SaveAndLoadTest
public partial class LoadTest : Node
{
	private string filePath = "Save Test/SaveFiles/SaveTest1.json";

	public override void _Ready()
	{
		int intLoad = ES.Load(filePath, "int", 0);	
		GD.Print(intLoad.Equals(1));

		float floatLoad = ES.Load(filePath, "float", 0.0f);	
		GD.Print(floatLoad.Equals(1.0f));

		double doubleLoad = ES.Load(filePath, "double", 0.0);	
		GD.Print(doubleLoad.Equals(1.0));

		bool boolLoad = ES.Load(filePath, "bool", false);	
		GD.Print(boolLoad.Equals(true));

		string stringLoad = ES.Load(filePath, "string", "World");	
		GD.Print(stringLoad.Equals("Hello"));

		Vector2 vector2Load = ES.Load(filePath, "vector2", new Vector2(0, 0));	
		GD.Print(vector2Load.Equals(new Vector2(1, 1)));

		Vector3 vector3Load = ES.Load(filePath, "vector3", new Vector3(0, 0, 0));	
		GD.Print(vector3Load.Equals(new Vector3(1, 1, 1)));
	}
}
