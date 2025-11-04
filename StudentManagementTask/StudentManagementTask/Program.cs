internal class Program
{
    static void Main(string[] args)
    {
        Student[] students = new Student[0];
    repeat:
        //burada usera optionlari gosteririk ve 0-5 arasinda sechim ede biler
        Console.WriteLine("---Student Management---");
        Console.WriteLine("1. Yeni telebe elave et");
        Console.WriteLine("2. Telebe sil");
        Console.WriteLine("3. Telebeye qiymet elave et");
        Console.WriteLine("4. Butun telebeleri goster");
        Console.WriteLine("5. Chixish");
        Console.Write("Sechiminiz: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        /*int choice2;
        int.TryParse(Console.ReadLine(), out choice2); */
        //burada yoxlanish apaririq ki sechimlerde kenar sechim daxil olarsa, error mesajimiz ekrana cixsni
        if (choice <= 0 || choice > 5)
            Console.WriteLine("Duzgun secim etmemisiniz. yeniden cehd edin");



        switch (choice)
        {
            //telebenin sayinin artirilmasi     
            case 1:
                Console.Write("Telebenin Adi: ");
                string name = Console.ReadLine();
                Console.Write("Telebenin Soyadi: ");
                string surname = Console.ReadLine();
                Student newStudent = new Student(name, surname);

                Student[] newArray = new Student[students.Length + 1];

                for (int i = 0; i < students.Length; i++)
                {
                    newArray[i] = students[i];

                }
                newArray[newArray.Length - 1] = newStudent;
                students = newArray;
                Console.WriteLine("Teze telebe elave edildi.");
                goto repeat;







            case 2:
                //telebeni id ile silmek
                Console.WriteLine("Silinecek telebe ID-si daxil edin: ");
                int removeId = Convert.ToInt32(Console.ReadLine());
                Student[] postDeletion = new Student[students.Length - 1];
                int j = 0;
                bool run = false;

                for (int i = 0; i < students.Length; i++)
                {
                    if (removeId == students[i].Id)
                    {
                        run = true;
                        continue;
                    }
                    if (j < postDeletion.Length)
                    {
                        postDeletion[j++] = students[i];

                    }
                }
                if (!run)
                {
                    students = postDeletion;
                    Console.WriteLine("Telebe sililndi");
                }
                else
                {
                    Console.WriteLine("bu id-e uygun telebe tapilmadi");
                }
                goto repeat;

            //telebeye qiymet elave etmek
            case 3:
                Console.Write("Telebenin id-sini daxin edlin: ");
                int getId = Convert.ToInt32(Console.ReadLine());

                Student getStudent = null;

                for (int i = 0; i < students.Length; i++)
                {
                    if (getId == students[i].Id)
                    {
                        getStudent = students[i];
                        break;
                    }
                }
                if (getStudent != null)
                {
                    Console.WriteLine("Arzu etdiyiniz qiymeit daxil edin: ");
                    int qiymet = Convert.ToInt32(Console.ReadLine());
                    if(qiymet<0 || qiymet>100)
                    {
                        Console.WriteLine("Duzgun araliqda qiymet daxil edilmedi.");
                        goto repeat;
                    }
                    int[] newGrades = new int[getStudent.Grades.Length + 1];

                    for (int i = 0; i < getStudent.Grades.Length; i++)
                    {
                        newGrades[i] = getStudent.Grades[i];
                    }
                    newGrades[newGrades.Length - 1] = qiymet;
                    getStudent.Grades = newGrades;
                    Console.WriteLine("Qiymetiniz qeyd alindi.");
                }
                else
                {
                    Console.WriteLine("id-e uygun telebe yoxdur");
                }
                goto repeat;



            //butun teleberi gosterir
            case 4:
                Console.WriteLine("Butun teleberl: ");
                for (int i = 0; i < students.Length; i++)
                {
                    students[i].ShowInfo();
                }
                goto repeat;

            //programdan cixisilmasi exit
            case 5:
                Console.WriteLine("cixish");
                break;
            default:
                Console.WriteLine("yanlis secim");
                goto repeat;




        }
    }
}

//eger dese ki niye hersey program/csdedi deyersen ki bize muallem servicede yazmagi gostermisdi ya da adi classda prosto dedim birden indi ele istemezsiz ona goretm