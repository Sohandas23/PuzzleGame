using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Utility
{
   public static int ColorIndex = 0;
   public static int ShapeIndex;
   public enum Colors{
      Red = 0,
      Green = 1,
      Blue = 2,
      Yellow = 3,
      Black = 4,
      White = 5,
      Orange = 6,
      Purple = 7,
      Pink = 8,
      Brown = 9,
   }
   
   public enum Shapes{
      Circle = 0,
      PartOneTriangle = 1,
      PartTwoTriangle = 2, 
      PartThreeTriangle = 3,
      PartFourTriangle = 4,
      Rectangle = 5,
      PartOneOfSemiCircle = 6,
      PartTwoOfSemiCircle = 7,
      PartThreeOfSemiCircle = 8,
      PartFourOfSemiCircle = 9,
   }
   public static Color GetColorFromIndex(int index)
   {
      return index switch
      {
         0 => Color.red,
         1 => Color.green,
         2 => Color.blue,
         3 => Color.yellow,
         4 => Color.black,
         5 => Color.white,
         6 => new Color(1f, 0.5f, 0f),   // Orange
         7 => new Color(0.5f, 0f, 0.5f), // Purple
         8 => new Color(1f, 0.4f, 0.7f), // Pink
         9 => new Color(0.6f, 0.3f, 0f), // Brown
         _ => Color.white,
      };
   }
}
