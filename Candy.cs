using System;
using System.Collections.Generic;
using System.Text;

/**
 * Class Candy stores the data for each type of candy
 */
class Candy
{
   //The name of the Candy type
   public string Name { get; set; }

   //The cost of buying the candy from the vending machine
   public decimal Price { get; set; }

   // Art corresponds to each row of art to display in the vending machine,
   // with 0 as the highest row
   public string[] art = new string[5];

   /**
   * Basic constructor reads & assigns incoming attributes of each piece
   * of candy
   */
   public Candy(string newName, string newPrice, string newArt1,
                string newArt2, string newArt3, string newArt4, string newArt5)
   {
      Name = newName;
      Price = Convert.ToDecimal(newPrice);

      art[0] = newArt1;
      art[1] = newArt2;
      art[2] = newArt3;
      art[3] = newArt4;
      art[4] = newArt5;
   }

   public override string ToString()
   {
      return Name;
   }

}
