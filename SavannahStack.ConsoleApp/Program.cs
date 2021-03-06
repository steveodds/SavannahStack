// See https://aka.ms/new-console-template for more information
var showMenu = true;

// Loop through menu until user exits
while (showMenu)
{
    showMenu = MainMenu();
}


// Main menu method
bool MainMenu()
{
    Console.Clear();
    Console.WriteLine("Please select an option:");
    Console.WriteLine(
@"1. Add one item to the stack
2. Add multiple items to the stack
3. Add complex object to the stack
4. Exit");

    var userSelection = Console.ReadKey();
    var choice = true; // loop through each submenu until user exits
    switch (userSelection.KeyChar)
    {
        case '1':
            Console.Clear();
            while (choice)
            {
                choice = AddSingle();
            }
            return true;
        case '2':
            Console.Clear();
            while (choice)
            {
                choice = AddMultiple();
            }
            return true;
        case '3':
            Console.Clear();
            while (choice)
            {
                choice = AddComplex();
            }
            return true;
        case '4':
            return false;
        default:
            return true; // wrong options just rerender the menu
    }
}

// Add items one at a time to stack
bool AddSingle()
{
    var userSingleItems = new SavannahStack.Stack_S<string>();
    var addSingleActions = true;
    while (addSingleActions)
    {
        Console.WriteLine("Please provide an item to store in the stack:");
        string? item = Console.ReadLine();
        while (item == null) // make sure user actually provides input
            item = Console.ReadLine();
        // add to stack
        userSingleItems.Push(item);
        Console.WriteLine("Save another item? (Y/N)");
        var restart = Console.ReadKey();
        Console.WriteLine("\n");
        if (restart.KeyChar.ToString().ToLowerInvariant() == "n") // if user doesn't decline, loop through this menu again
            return StackActions(userSingleItems);
    }
    return false;
}

// Add multiple items at once
bool AddMultiple()
{
    var userMultiItems = new SavannahStack.Stack_S<string>();
    var addMultiActions = true;
    while (addMultiActions)
    {
        Console.WriteLine("Please provide items to store in the stack (separate with commas):");
        string? items = Console.ReadLine();
        while (items == null)
            items = Console.ReadLine();
        // split into array then add with overloaded method
        var splitItems = items.Split('\u002C');
        userMultiItems.Push(splitItems);
        return StackActions(userMultiItems);
    }
    return false;
}

// Leveraging generics by adding a non-primitive variable
bool AddComplex()
{
    var userComplexItems = new SavannahStack.Stack_S<SavannahStack.Test.Person>(); // reusing person class in test
    var addComplexActions = true;
    while (addComplexActions)
    {
        var person = new SavannahStack.Test.Person();
        Console.WriteLine("Please provide a complex object (Person with Title, Name, Age) to store in the stack:");
        Console.Write("Add Title: ");
        string? title = Console.ReadLine();
        while (title == null)
            title = Console.ReadLine();
        person.Title = title;
        
        Console.Write("Add Name: ");
        string? name = Console.ReadLine();
        while (name == null)
            name = Console.ReadLine();
        person.Name = name;
        
        Console.Write("Add Age: ");
        string? age = Console.ReadLine();
        while (age == null)
            age = Console.ReadLine();
        person.Age = age;
        // add to stack
        userComplexItems.Push(person);
        Console.WriteLine("Save another item? (Y/N)");
        var restart = Console.ReadKey();
        Console.WriteLine("\n");
        if (restart.KeyChar.ToString().ToLowerInvariant() == "n")
            return StackComplexActions(userComplexItems); // use separate actions method
    }
    return false;
}

// Actions that make use of the stack helper functions ("extra functionality")
bool StackActions(SavannahStack.Stack_S<string> items)
{
    var showActions = true;
    while (showActions) // loop through until user exits
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine(
@"1. Show stack stats
2. Print stack items (Pop)
3. Add more items
4. Search for item
5. Clear stack (use other menu items to verify)
6. Exit");
        var selectedStackOption = Console.ReadKey();
        Console.WriteLine(selectedStackOption.ToString());
        switch (selectedStackOption.KeyChar)
        {
            case '1':
                Console.WriteLine("\n");
                Console.WriteLine("========================");
                try
                {
                    // info about stack
                    Console.WriteLine($"| Items in stack: {items.GetTotalCount()}");
                    Console.WriteLine($"| Last added item (Peek): {items.Peek()}");
                    Console.WriteLine($"| Is Stack empty?: {items.IsEmpty()}");

                }
                catch (InvalidOperationException)
                {
                    // operations fail if performed on an empty stack
                    Console.WriteLine("| Stack is empty");
                }
                Console.WriteLine("========================");
                Console.WriteLine("\n");
                break;
            case '2':
                Console.WriteLine("\n");
                Console.WriteLine("========================");
                var totalItems = items.GetTotalCount(); // prefetch total as it changes with each pop
                for (int i = 0; i < totalItems; i++)
                {
                    Console.WriteLine(items.Pop());
                }
                Console.WriteLine("========================");
                Console.WriteLine("\n");
                break;
            case '3':
                return true;
            case '4':
                Console.WriteLine("Type the item you want to search for:");
                var searchItem = Console.ReadLine();
                while (searchItem != null)
                    searchItem = Console.ReadLine();

                // throws null warning but the while loop forces input
                Console.WriteLine("\n");
                Console.WriteLine("========================");
                Console.WriteLine(items.Contains(searchItem) ? $"{searchItem} found!" : $"{searchItem} is not in the stack!");
                Console.WriteLine("========================");
                Console.WriteLine("\n");
                break;
            case '5':
                try
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("========================");
                    items.Clear();
                    Console.WriteLine("Cleared stack (Run stack stats)");
                    Console.WriteLine("========================");
                    Console.WriteLine("\n");

                }
                catch (InvalidOperationException)
                {
                    // in case user tries to clear again
                    Console.WriteLine("Stack is already empty!");
                    Console.WriteLine("========================");
                    Console.WriteLine("\n");
                }
                break;
            case '6':
                return false;
            default:
                return false;
        }
    }
    
    return false;
}

// same as StackActions but without search
bool StackComplexActions(SavannahStack.Stack_S<SavannahStack.Test.Person> items)
{
    var showActions = true;
    while (showActions)
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine(
@"1. Show stack stats
2. Print stack items (Pop)
3. Add more items
4. Clear stack (use other menu items to verify)
5. Exit");
        var selectedStackOption = Console.ReadKey();
        Console.WriteLine(selectedStackOption.ToString());
        switch (selectedStackOption.KeyChar)
        {
            case '1':
                Console.WriteLine("\n");
                Console.WriteLine("========================");
                try
                {
                    Console.WriteLine($"| Items in stack: {items.GetTotalCount()}");
                    var person = items.Peek();
                    // print object in readable form
                    Console.WriteLine($"| Last added item (Peek): {person.Title} {person.Name} of age {person.Age}");
                    Console.WriteLine($"| Is Stack empty?: {items.IsEmpty()}");

                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("| Stack is empty");
                }
                Console.WriteLine("========================");
                Console.WriteLine("\n");
                break;
            case '2':
                Console.WriteLine("\n");
                Console.WriteLine("========================");
                var totalItems = items.GetTotalCount();
                for (int i = 0; i < totalItems; i++)
                {
                    var person = items.Pop();
                    Console.WriteLine($"{person.Title} {person.Name} of age {person.Age}");
                }
                Console.WriteLine("========================");
                Console.WriteLine("\n");
                break;
            case '3':
                return true;
            case '4':
                try
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("========================");
                    items.Clear();
                    Console.WriteLine("Cleared stack (Run stack stats)");
                    Console.WriteLine("========================");
                    Console.WriteLine("\n");

                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Stack is already empty!");
                    Console.WriteLine("========================");
                    Console.WriteLine("\n");
                }
                break;
            case '5':
                return false;
            default:
                return false;
        }
    }
    
    return false;
}