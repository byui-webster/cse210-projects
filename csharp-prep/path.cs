using System;
namespace DemoApplication{
   public class Program{
      public static void Main(){
         string desktopPath =
         Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         Console.WriteLine($"Desktop Path: {desktopPath}");
         Console.ReadLine();
      }
   }
}