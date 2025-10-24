using System.ComponentModel.Design;
using System.Reflection.Metadata;

namespace MXNtask
{
    class Program
    {
        static void Main()
        {
            UserService service = new UserService();

            Console.WriteLine("all users");
            service.GetAll();


            Console.WriteLine("nw user is being added");
            Random rnd = new Random();
            int randomId = rnd.Next(6, 100);
            User newUser = new User(randomId, "aylin", "aylin@code.edu.az");
            service.Create(newUser);

            Console.WriteLine("Idsi 3 olan user");
            User found = service.GetById(3);
            if (found != null)
            {
                Console.WriteLine(found.Name + " - " + found.Email);

            }
            else
            {
                Console.WriteLine("not found");

            }
            Console.WriteLine("uSer silinri (id=2)");
            service.Delete(2);
            Console.WriteLine("Updated user list: ");
            service.GetAll();

        }
    }
}