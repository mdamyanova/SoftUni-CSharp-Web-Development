using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsShop.Models
{
    public class UserFriend
    {
        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        public User User { get; set; }

        [Key, Column(Order = 2)]
        public int FriendId { get; set; }

        public User Friend { get; set; }
    }
}