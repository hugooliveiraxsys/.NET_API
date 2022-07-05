using System;

namespace Models.Requests
{
    public class PersonRequest
    {
        public int? Id { get; set; }
        public string Cpf { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}
