using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ContactFileService
{
    private static readonly string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "contacts.txt");
    private List<Contact> contacts;

    public ContactFileService()
    {
        contacts = ReadContactsFromFile();
    }

    public void AddContact(string name, string phone)
    {
        if (contacts.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase) || c.Phone.Equals(phone)))
        {
            Console.WriteLine("Error: The contact with the same name or phone number already exists.");
            return;
        }

        contacts.Add(new Contact(name, phone));
        WriteContactsToFile();
        Console.WriteLine("Contact added successfully.");
    }

    public void RemoveContact(string name, string phone)
    {
        var contact = contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && c.Phone.Equals(phone));
        if (contact != null)
        {
            contacts.Remove(contact);
            WriteContactsToFile();
            Console.WriteLine("Contact removed successfully.");
        }
        else
        {
            Console.WriteLine("Error: Contact not found.");
        }
    }

    public void UpdateContact(string oldName, string oldPhone, string newName, string newPhone)
    {
        if (contacts.Any(c => (c.Name.Equals(newName, StringComparison.OrdinalIgnoreCase) || c.Phone.Equals(newPhone)) &&
                               !(c.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase) && c.Phone.Equals(oldPhone))))
        {
            Console.WriteLine("Error: The new name or phone number is already in use by another contact.");
            return;
        }

        var contact = contacts.FirstOrDefault(c => c.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase) && c.Phone.Equals(oldPhone));
        if (contact != null)
        {
            contact.Name = newName;
            contact.Phone = newPhone;
            WriteContactsToFile();
            Console.WriteLine("Contact updated successfully.");
        }
        else
        {
            Console.WriteLine("Error: Contact not found.");
        }
    }

    public void ShowAllContacts()
    {
        contacts = ReadContactsFromFile();
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public void SearchContactByName(string name)
    {
        var results = contacts.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        if (results.Count > 0)
        {
            foreach (var contact in results)
            {
                Console.WriteLine(contact);
            }
        }
        else
        {
            Console.WriteLine("No contacts found.");
        }
    }

    private static List<Contact> ReadContactsFromFile()
    {
        var contacts = new List<Contact>();
        if (File.Exists(FilePath))
        {
            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    contacts.Add(new Contact(parts[0], parts[1]));
                }
            }
        }
        return contacts;
    }

    private void WriteContactsToFile()
    {
        var lines = contacts.Select(c => $"{c.Name},{c.Phone}").ToArray();
        File.WriteAllLines(FilePath, lines);
    }
}
