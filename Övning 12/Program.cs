using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_12
{
   
    struct Person
    {
        public string firstName;
        public string lastName;
        public string phoneNumber;
        public string email;

    public Person(string fname, string lname, string phone, string mail)
        {
            firstName = fname;
            lastName = lname;
            phoneNumber = phone;
            email = mail;
        }
    }


    class Program
    {
        static Person[] contactList = { };
        static bool running = true;
        static void Main(string[] args)
        {
            do
            {
                Meny();
                Menyval();
            } while (running);
        }

        private static void Menyval()
        {
            bool wrongChoice = true;
            do
            {
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "l":
                        AddContact();
                        wrongChoice = false;
                        break;

                    case "t":
                        contactList = RemoveContact();
                        wrongChoice = false;
                        break;

                    case "s":
                        SortList();
                        wrongChoice = false;
                        break;

                    case "v":
                        ShowList();
                        wrongChoice = false;
                        break;

                    case "a":
                        running = false;
                        wrongChoice = false;
                        break;

                    case "f":
                        Console.Clear();
                        ChangeMeny();
                        wrongChoice = false;
                        break;
                         
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen");
                        break;
                }
            } while (wrongChoice);
            Console.Clear();
        }

        private static void ChangeMeny()
        {
            Console.WriteLine("Välj vad du vill ändra:");
            Console.WriteLine("[F]örnamn");
            Console.WriteLine("[E]fternamn");
            Console.WriteLine("[T]elefonnummer");
            Console.WriteLine("[M]ail");
            string menuChoice = Console.ReadLine().ToLower();
            switch (menuChoice)
            {
                case "f":
                    ChangeFirstName();
                    break;

                case "e":
                    ChangeLastName();
                    break;

                case "t":
                    ChangePhoneNumber();
                    break;

                case "m":
                    ChangeEMail();
                    break;

                default:
                    Console.WriteLine("Ogiltigt val");
                    break;
            }
        }

        private static void ShowList()
        {
            PrintContacts(contactList);
            Console.ReadKey();
        }

        private static void SortList()
        {
            Person[] temp = new Person[1];
            for (int i = 0; i < contactList.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < contactList.Length; j++)
                {
                    if (contactList[minIndex].firstName.CompareTo(contactList[j].firstName) > 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex == i)
                {
                    temp[0] = contactList[i];
                    contactList[i] = contactList[minIndex];
                    contactList[minIndex] = temp[0];
                }
            }
            Console.WriteLine("Nu har kontaktlistan sorterats efter förnamn.");
            ShowList();
        }

        private static Person[] RemoveContact()
        {
            Console.WriteLine("Vem vill du radera? Ange förnamn.");
            Person[] tempList = new Person[contactList.Length - 1];
            string deleteName = Console.ReadLine();
            int deleteNameIndex = 0;
            bool contactExists = false;
            for (int i = 0; i < contactList.Length; i++)
            {
                if(deleteName == contactList[i].firstName)
                {
                    contactExists = true;
                    deleteNameIndex = i;
                }
            }
            if(contactExists)
            {
                for (int i = 0; i < (deleteNameIndex); i++)
                {
                    tempList[i] = contactList[i];
                }
                for (int i = deleteNameIndex + 1; i < contactList.Length; i++)
                {
                    tempList[i-1] = contactList[i];
                }
                Console.WriteLine($"{deleteName} raderades.");
                Console.ReadKey();
                return tempList;
            }
            else
            {
                Console.WriteLine("Kontakten hittades inte.");
                Console.ReadKey();
                return contactList;
            }
 
        }

        private static void AddContact()
        {
            Person person1 = BuildContact(contactList, contactList.Length);
            contactList = AddToContacts(person1);
            Console.ReadKey();
        }

        private static void Meny()
        {
            Console.WriteLine("Välkommen till din telefonbok!");
            Console.WriteLine("[L]ägg till kontakt");
            Console.WriteLine("[T]a bort kontakt");
            Console.WriteLine("[F]örändra kontakt");
            Console.WriteLine("[S]ortera kontaktlistan");
            Console.WriteLine("[V]isa kontaktlistan");
            Console.WriteLine("[A]vsluta");
        }

        private static Person[] AddToContacts(Person person)
        {
            int i = 0;
            Person[] tempContacts = new Person[contactList.Length + 1];
            foreach (var item in contactList)
            {
                tempContacts[i] = item;
                i++;
            }
            tempContacts[contactList.Length] = person;
            return tempContacts;
        }

        private static Person BuildContact(Person[] contactList, int i)
        {
            Console.WriteLine("Skriv in ett förnamn:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Skriv in ett efternamn:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Skriv in ett telefonnummer:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Skriv in en emailadress:");
            string email = Console.ReadLine();
            Person person = new Person(firstName, lastName, phoneNumber, email);
            return person;
        }

        private static void ChangeFirstName()
        {
            Console.WriteLine("Skriv in förnamnet du vill byta ut:");
            string oldName = Console.ReadLine();
            Console.WriteLine("Skriv in förnamnet du vill byta till:");
            string newName = Console.ReadLine();
            bool correctChange = false;
            for (int i = 0; i < contactList.Length; i++)
            {
                if(contactList[i].firstName == oldName)
                {
                    contactList[i].firstName = "Oops, något blev fel!";
                    correctChange = true;
                    break;
                }
            }
            if(correctChange == false)
            {
                Console.WriteLine("Namnet hittades inte.");
                Console.ReadKey();
            }
        }

        private static void ChangeLastName()
        {
            Console.WriteLine("Skriv in efternamnet du vill byta ut:");
            string oldName = Console.ReadLine();
            Console.WriteLine("Skriv in efternamnet du vill byta till:");
            string newName = Console.ReadLine();
            bool correctChange = false;
            for (int i = 0; i < contactList.Length; i++)
            {
                if (contactList[i].lastName == oldName)
                {
                    contactList[i].lastName = newName;
                    correctChange = true;
                    break;
                }
            }
            if (correctChange == false)
            {
                Console.WriteLine("Namnet hittades inte.");
                Console.ReadKey();
            }
        }

        private static void ChangePhoneNumber()
        {
            Console.WriteLine("Skriv in telefonnumret du vill byta ut:");
            string oldNumber = Console.ReadLine();
            Console.WriteLine("Skriv in telefonnumret du vill byta till:");
            string newNumber = Console.ReadLine();
            bool correctChange = false;
            for (int i = 0; i < contactList.Length; i++)
            {
                if (contactList[i].phoneNumber == oldNumber)
                {
                    contactList[i].phoneNumber = newNumber;
                    correctChange = true;
                    break;
                }
            }
            if (correctChange == false)
            {
                Console.WriteLine("Numret hittades inte.");
                Console.ReadKey();
            }
        }

        private static void ChangeEMail()
        {
            Console.WriteLine("Skriv in email du vill byta ut:");
            string oldEmail = Console.ReadLine();
            Console.WriteLine("Skriv in email du vill byta till:");
            string newEmail = Console.ReadLine();
            bool correctChange = false;
            for (int i = 0; i < contactList.Length; i++)
            {
                if (contactList[i].email == oldEmail)
                {
                    contactList[i].email = newEmail;
                    correctChange = true;
                    break;
                }
            }
            if (correctChange == false)
            {
                Console.WriteLine("Mailadressen hittades inte.");
                Console.ReadKey();
            }
        }
        private static void PrintContacts(Person[] contacts)
        {
            foreach (var person in contacts)
            {
                Console.WriteLine($"{person.firstName} {person.lastName}, {person.phoneNumber}, {person.email}");
            }
        }

        private static void PrintContact(Person contact)
        {
            Console.WriteLine($"{contact.firstName} {contact.lastName}, {contact.phoneNumber}, {contact.email}");
        }
    }
}
