public class Contact
{
    public string Name { get; set; }
    public string Phone { get; set; }

    public Contact(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Phone: {Phone}";
    }
}
