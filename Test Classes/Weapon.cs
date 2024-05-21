using Godot.Collections;

public class Weapon
{
	private string name;
	private int damage;
	private bool upgraded;
	
	public Weapon(string name, int damage, bool upgraded) {
		this.name = name;
		this.damage = damage;
		this.upgraded = upgraded;
	}

	public Dictionary ToDictionaryFormat() {
		Dictionary dict = new Dictionary();
		dict["name"] = name;
		dict["damage"] = damage;
		dict["upgraded"] = upgraded;
		return dict;
	}

	public static Weapon FromDictionaryFormat(Dictionary dict) {
		return new Weapon((string) dict["name"], (int) dict["damaged"], (bool) dict["upgraded"]);
	}
}
