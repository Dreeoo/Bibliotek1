﻿namespace Library.Domain
{
    public class Member
    {
        public int Id { get; set; }
        public int SSN { get; set; }
        public string Name { get; set; }
        public Loan Loan { get; set; }
    }
}
