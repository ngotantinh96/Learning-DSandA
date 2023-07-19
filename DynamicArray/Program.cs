// See https://aka.ms/new-console-template for more information
using TinhNgo.DynamicArray;

DynamicArray<string> dynamicArray = new DynamicArray<string>();
dynamicArray.Add("T");
dynamicArray.Add("i");
dynamicArray.Add("n");
dynamicArray.Add("h");
dynamicArray.Add("N");
dynamicArray.Add("g");
dynamicArray.Add("o");
Console.WriteLine(dynamicArray.Size);
Console.WriteLine(dynamicArray.ToString());
Console.WriteLine(dynamicArray.Get(5));
Console.WriteLine(dynamicArray.IndexOf("h"));
dynamicArray.RemoveAt(4);
dynamicArray.Remove("n");
Console.WriteLine(dynamicArray.ToString());
