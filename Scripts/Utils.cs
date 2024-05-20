using Godot;
using System;

public class Utils
{
	public static void PrintArray<T>(T[] array) {
        foreach (var item in array) {
            GD.Print(item + " " + item.GetType());
        }
    }
}
