﻿namespace lec2WebSecurity.Models
{
    public class GuestbookEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime DatePosted { get; set; }

    }
}
