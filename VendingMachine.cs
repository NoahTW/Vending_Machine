using System;
using System.IO;
using System.Collections.Generic;

   /** Class VendingMachine initializes and stores the data
   * associated with the vending machine, it's available items
   * and the graphics associated.
   * This class does not store the Customers information such as balance
   * */
class VendingMachine
{
   static List<Candy> candies = new List<Candy>();

   // The inventory of which item is stored in which slot.
   // Each number stored in this array will correspond to the candy list index.
   static int[] inventory = new int[9];
   public VendingMachine()
   {
      ReadCandyData();
      StockVendingMachine();
   }


   public void DisplayVendingMachine()
   {
      int i = 1;
      int r;
      Console.Clear();
      Console.Write(
         " ____________________________________________\n" +
         "|############################################|\n" +
         "|#|    1       2        3     |##############|\n" +
        $"|#| {Ca(i, r = 0)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |##|````````|##|\n" +
       $@"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |##| ENTER  |##|" + "\n" +
        $"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |##| ITEM   |##|\n" +
       $@"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |##| NUMBER |##|" + "\n" +
       $@"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |##|________|##|" + "\n" +
         "|#|===========================|##############|\n" +
         "|#|````4```````5````````6`````|##############|\n" +
        $"|#| {Ca(i += 3, r = 0)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |##############|\n" +
       $@"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |#|`````````|##|" + "\n" +
       $@"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |#| _______ |##|" + "\n" +
       $@"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |#| |1|2|3| |##|" + "\n" +
       $@"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |#| |4|5|6| |##|" + "\n" +
         "|#|===========================|#| |7|8|9| |##|\n" +
         "|#|````7```````8````````9`````|#| ``````` |##|\n" +
        $"|#| {Ca(i += 3, r = 0)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |#|[=======]|##|\n" +
       $@"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |#|  _   _  |##|" + "\n" +
       $@"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |#| ||| ( ) |##|" + "\n" +
       $@"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |#| |||  `  |##|" + "\n" +
       $@"|#| {Ca(i, r)} {Ca(i + 1, r)}  {Ca(i + 2, r++)}  |#|  ^      |##|" + "\n" +
         "|#|===========================|#|_________|##|\n" +
         "|#|```````````````````````````|##############|\n" +
         "|############################################|\n" +
         "|#|||||||||||||||||||||||||||||####```````###|\n" +
        @"|#||||||||||||PUSH|||||||||||||####\|||||/###|" + "\n" +
         "|############################################|\n" +
         " |________________________________|    |___|\n");
   }
   /**
   * Ca returns one line of Candy Art
   * @param itemNumber Contains the Candy's shelf id number
   * @param rowNum Contains the row (0-4) of the candy art needed
   */
   static string Ca(int itemNumber, int rownum)
   {
      return candies[inventory[itemNumber - 1]].art[rownum];
   }



   /**
   * ReadCandyData reads the Candy List file and creates
   * Candy objects from each list entry.
   * @pre CandyList.csv exists and is located in the source folder.
   * @pre CandyList is formatted with each line having 7 entries, formatted as
   * name, price, and 5 art sections
   * */
   void ReadCandyData()
   {
      string filePath = @"..\..\..\";
      string fileName = "CandyList.csv";

      // Exit program with error if filedoes not exist at location
      if (!File.Exists(filePath + fileName))
      {
         Console.WriteLine(fileName + " does not exist at this location.");
         Environment.Exit(1);
      }

      //Open the file, start streaming the info
      StreamReader inFile = new StreamReader(new FileStream(filePath +
                                             fileName, FileMode.Open));
      string record;

      //Skip the file title and column names
      inFile.ReadLine();
      inFile.ReadLine();

      //Fill in the list of all candy types to be referenced later
      while ((record = inFile.ReadLine()) != null)
      {
         string[] data = record.Split(',');
         candies.Add(new Candy(data[0], data[1], data[2], data[3], data[4], data[5], data[6]));
      }
      inFile.Close();
   }// End ReadCandyData


   /**
   * StockVendingMachine assigns int values to each shelf in the
   * vending machine. These will correspond to the index of each Candy item.
   * @pre EmptyShelf Candy item index is 0
   */
   void StockVendingMachine()
   {

      //Get customer input on whether to use random candies to stock machine
      Console.WriteLine("Stock the vending Machine Randomly?");
      string choice = Console.ReadLine().ToUpper();
      int i = 0;
      if (choice == "YES" || choice == "Y") //Stock the items randomly
      {
         Random randomNumbers = new Random();

         // Get customer input on whether to  include empty slots
         Console.WriteLine("Include possible empty slots?");
         string emptySlotChoice = Console.ReadLine().ToUpper();

         //Stock with items 0-9 (including empty item 0)
         if (emptySlotChoice == "YES" || emptySlotChoice == "Y")
         {
            foreach (int shelf in inventory)
            {
               inventory[i++] = randomNumbers.Next(10);
            }
         }
         else// Stock with items 1-9 (skipping empty candy item "0")
         {
            foreach (int shelf in inventory)
            {
               inventory[i++] = randomNumbers.Next(1, 10);
            }
         }
      }
      else// Stock the machine with items 1-9 (skipping empty candy item "0")
      {
         foreach (int shelf in inventory)
         {
            inventory[i++] = i;
         }
      }
   }

   public decimal DisplayShelfItem(int itemChoice)
   {
      Candy candyInShelf = candies[inventory[itemChoice]];
      if (inventory[itemChoice] == 0)
      {
         Console.WriteLine("This slot on the vending machine is empty.");
      }
      else
      {
         Console.WriteLine($"{candyInShelf}. This costs: {candyInShelf.Price}");
      }
      return candyInShelf.Price;
   }
   public void ClearShelf(int shelfNumber)
   {
      inventory[shelfNumber] = 0;
   }
}// End Class VendingMachine
