using System;
using System.Collections.Generic;
using System.Text;

namespace TestEntretien.Refactoring
{
    public class TestRefacto_1
    {
        public static void Run()
        {
            PersonA personA = new PersonA("john doe");
            PersonB personB = new PersonB("alice doe");          

            Client client = new Client();
            client.Display(personA);          
            // TO DO client afficher personB name sans modifier Client
            //personB.
        }
    }
    
    public class Client
    {       
        public void Display(IPerson person)
        {
            person.DisplayFullname();
        }
    }

    public interface IPerson
    {
        void DisplayFullname();
    }

    public class PersonA : IPerson
    {
        private string fullname;

        public PersonA(string fullname) => this.fullname = fullname;
        
        public void DisplayFullname()
        {
            Console.WriteLine("PersonA Type - fullname :" + fullname);
        }
    }
    public class PersonB
    {
        private string fullname;

        public PersonB(string fullname) => this.fullname = fullname;
        public void DisplayName()
        {
            Console.WriteLine("PersonB Type - fullname :" + fullname);
        }
    }

    


}
