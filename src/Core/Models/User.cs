namespace Core.Models;

public class User
{
    public Guid id { get; private set; }
    public string email { get; private set; }

    public string password { get; private set; }

    // Constructor privado para garantizar que solo se creen instancias válidas
    private User() { }

    public User(Guid id, string email, string password)
    {
        this.id = id;
        this.password = password;
        this.email = email;

        Validate();
    }

    // Validar que el email sea válido
    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("El email es obligatorio.");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("La contraseña es obligatoria");
    }

}
