import javax.persistence.*;

@Entity
@Table(name = "users")
public class User {
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Column(nullable = false, length = 30, unique = true)
    private String username;
    @Column(length = 60)
    private String passwordHash;
    @Column(length = 100)
    private String fullName;

    public Long getId(){return id;}

    public void setId(Long id){this.id = id;}

    public String getUsername(){return username;}

    public void setUsername(String username){this.username = username;}

    public String getPasswordHash(){return passwordHash;}

    public void setPasswordHash(String passwordHash){this.passwordHash = passwordHash;}

    public String getFullName(){return fullName;}

    public void setFullName(String fullName){this.fullName = fullName;}

    @Override
    public String toString() {
        return "User{" +
                "id=" + id +
                ", username='" + username + '\'' +
                ", passwordHash='" + passwordHash + '\'' +
                ", fullName='" + fullName + '\'' +
                '}';
    }
}
