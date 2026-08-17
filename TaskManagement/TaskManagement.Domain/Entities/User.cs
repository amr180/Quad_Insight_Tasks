namespace TaskManagement.Domain.Entities;

public class User
{
    private string _name = string.Empty;
    private string _email = string.Empty;

    public int Id { get; private set; }

    public string Name
    {
        get => _name;
        private set => _name = value.Trim();
    }

    public string Email
    {
        get => _email;
        private set => _email = value.Trim();
    }

    public ICollection<TaskItem> Tasks { get; private set; }
        = new List<TaskItem>();

    // EF Core
    private User()
    {
    }

    public User(string name, string email)
    {
        SetName(name);
        SetEmail(email);
    }

    public void Update(string name, string email)
    {
        SetName(name);
        SetEmail(email);
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        _name = name.Trim();
    }

    private void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty.");

        _email = email.Trim();
    }
}