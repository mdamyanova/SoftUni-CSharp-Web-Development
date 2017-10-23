import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;

public class Examples {
    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence
                .createEntityManagerFactory("blog-db");
        EntityManager em = emf.createEntityManager();

        try {
            // generateNewUser(em);
            // generateNewUserAndPosts(em);
            // listAllPosts(em);
            // getUserPosts(em);
            // editExistingUser(em);
            // deleteExistingUser(em);
            // executeNativeSQL(em);
        }
        finally {
            em.close();
            emf.close();
        }
    }

    private static void generateNewUser(EntityManager em) {
        User newUser = new User();
        newUser.setUsername("pesho");
        newUser.setFullName("pesho peshkata");
        em.getTransaction().begin();
        em.persist(newUser);
        em.getTransaction().commit();
        System.out.println("Created new user #" + newUser.getId());
    }

    private static void generateNewUserAndPosts(EntityManager em){
        em.getTransaction().begin();
        User newUser = new User();
        newUser.setUsername("pesho" + new Date().getTime());
        newUser.setPasswordHash("pass12345"); newUser.setFullName("P.Petrov");
        em.persist(newUser);
        System.out.println("Created new user #" + newUser.getId());
        for (int i = 1; i <= 10; i++) {
            Post newPost = new Post();
            newPost.setTitle("Post Title " + i);
            newPost.setBody("<p>Body" + i + "</p>");
            newPost.setAuthor(newUser);
            em.persist(newPost);
            System.out.println("Created new post #" + newPost.getId());
        }
        em.getTransaction().commit();
    }

    private static void listAllPosts(EntityManager em){
        Query allPostsQuerySlow = em.createQuery(
                "SELECT p FROM Post p");
        Query allPostsQuery = em.createQuery(
                "SELECT p FROM Post p JOIN FETCH p.author");
        List<Post> posts =
                allPostsQuery.getResultList();
        for (Post post : posts) {
            System.out.println(post);
        }
    }

    private static void getUserPosts(EntityManager em){
        Query peshoPosts =
                em.createQuery(
                        "FROM Post p JOIN FETCH p.author " +
                                "WHERE p.author.username " +
                                "LIKE CONCAT(:username, '%') ")
                        .setParameter("username", "pesho");
        List<Post> posts = peshoPosts.getResultList();
        for (Post post : posts) {
            System.out.println(post);
        }
    }

    private static void editExistingUser(EntityManager em){
        // Load an existing user by ID
        User firstUser = em.find(User.class, 1L);

        // Modify the User
        firstUser.setPasswordHash("" + new Date().getTime());
        firstUser.setFullName(firstUser.getFullName() + "2");

        // Persist pending changes
        em.getTransaction().begin();
        em.persist(firstUser);
        em.getTransaction().commit();
        System.out.println(
                "Edited existing user #" + firstUser.getId());
    }

    private static void deleteExistingUser(EntityManager em){
        /*Load an existing user by ID
        User firstUser = em.find(User.class, 1L);

        // Delete the user along with its posts
        em.getTransaction().begin();
        for (Post post : firstUser.getPosts())
            em.remove(post);
        em.remove(firstUser);
        em.getTransaction().commit();
        System.out.println("Deleted existing user #" +
                firstUser.getId()); */
    }

    private static void executeNativeSQL(EntityManager em){
        LocalDateTime startDate =
                LocalDateTime.parse("2016-05-19T12:00:00");
        LocalDateTime endDate = LocalDateTime.now();
        Query postsQuery = em.createNativeQuery(
                "SELECT id, title, date, body, author_id FROM posts " +
                        "WHERE CONVERT(date, Date) " +
                        "BETWEEN :startDate AND :endDate", Post.class)
                .setParameter("startDate", startDate)
                .setParameter("endDate", endDate);
        List<Post> posts = postsQuery.getResultList();
        for (Post post : posts)
            System.out.println(post);
    }
}