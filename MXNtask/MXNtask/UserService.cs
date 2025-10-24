namespace MXNtask
{
    public class UserService
    {
        private User[] users;

        public UserService() {

            users = new User[5];
            users[0] = new User(1, "Aysel", "aysel@code.edu.az");
            users[1] = new User(2, "Vilayat muallem", "vilayat@code.edu.az");
            users[2] = new User(3, "Natavan", "natavan@code.edu.az");
            users[3] = new User(4, "Mehri", "mehri@ciode.edu.az");
            users[4] = new User(5, "Mehin", "mehin@code.edu.az");



        }

        public void Create(User user) {

            for (int i = 0; i < users.Length; i++) {
                if (users[i] != null && users[i].Id == user.Id) {
                    Console.WriteLine("bu id uje var");
                    return;
                }
            }
            for (int i = 0; i < users.Length; i++) {
                if (users[i] == null) {
                    users[i] = user;
                    Console.WriteLine("new user elave olundu");
                    return;

                }
            }

            Console.WriteLine("massiv doludur, add etmek impossible");
        }
        public User GetById(int id)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i] != null && users[i].Id == id)
                {
                    return users[i];
                }
            }
                return null;
            }

        public void GetAll()
        {
            for (int i = 0; i < users.Length; i++) {
                if (users[i] != null)
                    Console.WriteLine(users[i].Id + "-" + users[i].Name + "-" + users[i].Email);
            }
        }
        public void Delete(int id)
        {
            for (int i = 0; i < users.Length; i++) {
                if (users[i] != null && users[i].Id == id) {
                    users[i] = null;
                    Console.WriteLine("user is deleted");
                    return;
                }
            }
            Console.WriteLine("bu id tapilmadi");
        }
    }
}