import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "users")
public class User {

    private Integer id;

    private String username;

    private String fullname;

    private String passwordhash;

    private Set<Post> posts = new HashSet<>(0);

    private Set<Comment> comments = new HashSet<>(0);


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Column(nullable = false)
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getFullname() {
        return fullname;
    }

    public void setFullname(String fullname) {
        this.fullname = fullname;
    }

    @Column(nullable = false)
    public String getPasswordHash() {
        return passwordhash;
    }

    public void setPasswordHash(String passwordhash) {
        this.passwordhash = passwordhash;
    }

    @OneToMany(mappedBy = "author")
    public Set<Post> getPosts() {
        return posts;
    }

    public void setPosts(Set<Post> posts) {
        this.posts = posts;
    }

    @OneToMany(mappedBy = "author")
    public Set<Comment> getComments() {
        return comments;
    };

    public void setComments(Set<Comment> comments) {
        this.comments = comments;
    }
}