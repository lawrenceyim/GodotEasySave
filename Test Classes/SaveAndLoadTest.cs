using Godot;
using Godot.Collections;

// Run this test first to save values and then load them
public partial class SaveAndLoadTest : Node
{
	private string filePath = "SaveTest/SaveFiles/SaveTest1.json";

	public override void _Ready() {
		ES.Save(filePath, "int", 1);
		int intLoad = ES.Load(filePath, "int", 0);
		GD.Print(intLoad.Equals(1));

		ES.Save(filePath, "float", 1.0f);
		float floatLoad = ES.Load(filePath, "float", 0.0f);
		GD.Print(floatLoad.Equals(1.0f));

		ES.Save(filePath, "double", 1.0);
		double doubleLoad = ES.Load(filePath, "double", 0.0);
		GD.Print(doubleLoad.Equals(1.0));

		ES.Save(filePath, "bool", true);
		bool boolLoad = ES.Load(filePath, "bool", false);
		GD.Print(boolLoad.Equals(true));

		ES.Save(filePath, "string", "Hello");
		string stringLoad = ES.Load(filePath, "string", "World");
		GD.Print(stringLoad.Equals("Hello"));

		ES.Save(filePath, "vector2", new Vector2(1, 1));
		Vector2 vector2Load = ES.Load(filePath, "vector2", new Vector2(0, 0));
		GD.Print(vector2Load.Equals(new Vector2(1, 1)));

		ES.Save(filePath, "vector3", new Vector3(1, 1, 1));
		Vector3 vector3Load = ES.Load(filePath, "vector3", new Vector3(0, 0, 0));
		GD.Print(vector3Load.Equals(new Vector3(1, 1, 1)));

		ES.Save(filePath, "intArray", new int[] { 1, 2, 3 });
		int[] intArrayLoad = (int[])ES.Load(filePath, "intArray", new int[] { 1 });
		Utils.PrintArray(intArrayLoad);

		ES.Save(filePath, "doubleArray", new double[] { 1, 2, 3 });
		double[] doubleArrayLoad = (double[])ES.Load(filePath, "doubleArray", new int[] { 1 });
		Utils.PrintArray(doubleArrayLoad);
		
		Weapon weapon = new Weapon("slayer", 10, true);
		ES.Save(filePath, "Weapon", weapon.ToDictionaryFormat());
		GD.Print(ES.Load(filePath, "Weapon", new Weapon("null", 0, false).ToDictionaryFormat()));	
	}

}
