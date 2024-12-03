using System;

class Program
{
    static void Main(string[] args)
    {
        var service = new ContactFileService();

        // Sample AddContacts
        service.AddContact("Emil Mammadov", "123456789");
        service.AddContact("Hesen Aghayev", "987654321");

        // Show All Contacts
        Console.WriteLine("\nAll Contacts:");
        service.ShowAllContacts();

        // Search Contact by Name
        Console.WriteLine("\nSearch Results for 'Emil':");
        service.SearchContactByName("Emil");

        // Update a Contact
        Console.WriteLine("\nUpdating 'Emil Mammadov'...");
        service.UpdateContact("Emil Mammadov", "123456789", "Emil Mamedov", "111222333");

        // Show All Contacts After Update
        Console.WriteLine("\nAll Contacts After Update:");
        service.ShowAllContacts();

        // Remove a Contact
        Console.WriteLine("\nRemoving 'Ali Veli'...");
        service.RemoveContact("Ali Veli", "987654321");

        // Show All Contacts After Removal
        Console.WriteLine("\nAll Contacts After Removal:");
        service.ShowAllContacts();
    }
}
