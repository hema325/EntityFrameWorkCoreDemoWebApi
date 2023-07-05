namespace WebApiEntityFramework.Entities
{
    public class Actor
    {
        public int Id { get; set; }

        private string _name;
        public string Name {
            get => _name;
            set
            {
                var words = value.Split(" ");
                words = words.Select(word => Char.ToUpper(word[0]) + word.Substring(1).ToLower()).ToArray();
                _name = String.Join(" ", words);
            }
        }

        public string? Biography { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<MovieActor>? MovieActors { get; set; }

        public int Age
        {
            get
            {
                var dateOfBirth = DateOfBirth;
                var age = DateTime.Now.Year - dateOfBirth.Year;

                if (new DateTime(DateTime.Now.Year, dateOfBirth.Month, dateOfBirth.Day) > DateTime.Now)
                    --age;

                return age;
            }
        }

        public Address BillingAddress { get; set; }
        public Address HomeAddress { get; set; }
    }
}
