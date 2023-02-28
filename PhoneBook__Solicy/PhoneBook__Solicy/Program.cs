using PhoneBook__Solicy;

Console.WriteLine("Please Insert File Name");
var fileName = Console.ReadLine();
PhoneBook phoneBook = new PhoneBook(fileName);
phoneBook.PrintMassages();

if(PhoneBook.check)
    phoneBook.Insertion();





