class Student
{
    private static int _defaultIdSet = 0; //her telebe uchun avt id verilmesi uchun 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int[] Grades { get; set; }

    public Student(string name, string surname) //ctor-a name ve surname teyin edirik
    {
        Id = ++_defaultIdSet; //unique id verilir prefix elemesek 0dan baslayir
        Name = name;
        Surname = surname;
        Grades = new int[0]; //hal-hazirda qiymwt teyin olunmayib deye arrayimiz bosdur(hemcinin [] da yazmaq olar) 


    }


    public void ShowInfo() //telebnin infolarini ekrana gonderir
    {
        Console.WriteLine($"Id:{Id}, Name: {Name}, Surname: {Surname}, Average Grade: {GetAverage()}");
    }

    public double GetAverage() //orta qiymetin hesablanmasi
    {
        if (Grades.Length == 0)
        {
            return 0;
        }
        double sum = 0;
        foreach (var grade in Grades)
        {
            sum += grade;
        }
        return sum / Grades.Length;
    }

}

