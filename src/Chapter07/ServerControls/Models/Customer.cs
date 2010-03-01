namespace ServerControls.Models
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
        private string _phone;

        public Customer()
        {
        }

        public Customer(string firstName, string lastName, string phone)
        {
            _firstName = firstName;
            _lastName = lastName;
            _phone = phone;
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
    }
}