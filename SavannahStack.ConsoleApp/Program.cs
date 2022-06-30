// See https://aka.ms/new-console-template for more information
var showMenu = true;
var invalidChoice = false;

while (showMenu)
{
    if(invalidChoice)
        Console.WriteLine("Invalid selection. Try again.");
    invalidChoice = false;
    Console.WriteLine("Please select an option:");
    Console.WriteLine(
@"1. Add one item to the stack
2. Add multiple items to the stack
3. Add complex object to the stack
4. Exit");
    var userSelection = Console.ReadKey();
    switch (userSelection.KeyChar)
    {
        case '1':
            var choiceOne = true;
            Console.Clear();
            while (choiceOne)
            {
                var userSingleItems = new SavannahStack.Stack_S<string>();
                Console.WriteLine("\nPlease provide an item to store in the stack:");
                string? item = Console.ReadLine();
                while (item == null)
                    item = Console.ReadLine();
                // store
                userSingleItems.Push(item);
                Console.WriteLine("Save another item? (Y/N)");
                var restart = Console.ReadKey();
                if (restart.KeyChar.ToString().ToLowerInvariant() == "n")
                {
                    Console.WriteLine("Select an action below:");
                    choiceOne = false;
                }

                // display
            }
            break;
        case '2':
            break;
        case '3':
            break;
        case '4':
            showMenu = false;
            break;
        default:
            invalidChoice = true;
            break;
    }
    Console.Clear();
}
