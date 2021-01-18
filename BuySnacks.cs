using System;

/**
* @author Noah Wardell
*/
class BuySnacks
{
   static void Main(string[] args)
   {
      int itemChoice;
      Boolean exit;

      decimal balance = SetRandomBalance();
      VendingMachine machine = new VendingMachine();

      do
      {
         exit = true;
         UpdateDisplay(machine,balance);
         itemChoice = GetItemChoice();
         decimal itemCost = machine.DisplayShelfItem(itemChoice);
         if (itemCost > (decimal)0.01)
         {
            Console.WriteLine($"You have {balance:C2}. Purchase this item?");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "YES" || choice == "Y")
            {
               if (balance >= itemCost)
               {
                  machine.ClearShelf(itemChoice);
                  balance -= itemCost;
               }
               else
               {
                  Console.WriteLine("You cannot afford this.");
               }
            }
         }
         Console.ReadLine();
         UpdateDisplay(machine, balance);
         Console.WriteLine("Buy more candy from the vending machine?");
         string continueChoice = Console.ReadLine().ToUpper();
         if (continueChoice == "YES" || continueChoice == "Y")
         {
            exit = false;
         }
      } while (exit == false);
   } // end Main

   static int GetItemChoice()
   {
      int itemChoice;
      do
      {
         Console.Write("Select an item: ");
         try
         {
            itemChoice = int.Parse(Console.ReadLine());
         }
         catch
         {
            itemChoice = -1;
         } // end catch
         if (itemChoice < 1 || itemChoice > 9)
         {
            Console.WriteLine("Not a valid shelf number (1-9)");
         }
      }
      while (itemChoice < 1 || itemChoice > 9);

      return itemChoice - 1;

   }


   static void UpdateDisplay(VendingMachine machine, decimal balance)
   {
      machine.DisplayVendingMachine();
      Console.WriteLine($"\nCurrent Balance: {balance:C2}");
   }

   static decimal SetRandomBalance()
   {
      const int MAX_LIMIT = 850; //Max $ (Divided by 100) generated for Balance
      const int MIN_LIMIT = 200; //Min $ (Divided by 100) generated for Balance

      Random randomNumbers = new Random();
      return Convert.ToDecimal(randomNumbers.Next(MIN_LIMIT - 1, MAX_LIMIT) / 100.00);
   }

}// end Class