using System;

namespace WebApplication1.Models
{
    public class Duckbill
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Friends { get; set; }
    }

    public class DuckbillFriend
    {
        public Guid FriendId1 { get; set; }

        public Guid FriendId2 { get; set; }
    }
}