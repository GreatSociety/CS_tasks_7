using System;
using System.Collections.Generic;

namespace Tasks7
{
    class Program
    {
        static void Main()
        {
            // Создали
            Application application = new Application();
            Admin admin = new Admin();
            List<User> users =  new List<User>();

            // Заполнили список 10 юзерам и подписались на ивент обновления. 
            for(int i = 0; i < 10; i++)
            {
                users.Add(new User());
                users[i].ListenUpdates(application);
            }

            // Узнаем кто тут закон 
            application.CreateUpdate(users[1].AccountType, "Version 1.2", "We are users");
            application.CreateUpdate(admin.AccountType, "Version 1.3", "I am the law");

            

            Console.ReadKey();
        }

	}


    /*
      ♦ Реализовать систему рассылки оповещений пользователям о выходе нового обновления
      
        Создать класс Application со следующими полями и методами:
        • Открытый делегат с сигнатурой void MessageDelegate(string, string)
        • Открытый событие event MessageDelegate OnUpdateRelease
        • Открытый метод CreateUpdate(AccountType accountType, string updateName, string updateDescription)
            в котором при условии, что accountType соответствует администратору, вызывать событие (с передачей в него updateName и updateDescription)
        
        Создать перечисление AccountType с двумя полями Admin и User

        Создать абстрактный класс AbstractUser и объявить в нем:
        • Защищенным поле accountType типа AccountType
        • Публичное свойство AccountType типа AccountType, обуспечив через него достук к полю accountType только для чтения

        Создать класс User и наследовать его от AbstractUser
        • Конструктор по умолчанию, инициализирующий поле accountType значением AccountType.User
        • Закрытый метод с сигнатурой void ShowMessage(string, string), который выводит информацию об обновлении (название обновления и его описание)
        • Метод ListenUpdates, который принимает в качестве параметра объект типа Application

        Создать класс Admin и наследовать его от AbstractUser
        • Создать конструктор по умолчанию, инициализирующий поле accountType значением AccountType.Admin

        Создать объект application класса Application
        Создать объект admin класса Admin
        Создать произвольное количество объектов класса User и подписаться ими на обновления приложения методом ListenUpdates
        Создать новое обновление приложения c помощью метода CreateUpdate
        
    */

    enum AccountType
    {
        User = 0,
        Admin = 1
    }

    class Application
    {
        public delegate void MessageDelegate(string x, string y);

        public event MessageDelegate OnUpdateRelease;

        public void CreateUpdate(AccountType accountType, string updateName, string updateDescription)
        {
            switch (accountType)
            {
                case AccountType.Admin:

                    OnUpdateRelease?.Invoke(updateName, updateDescription);
                    break;
            }
        }

    }

    abstract class AbstractUser
    {

        private readonly AccountType accountType;
        abstract public AccountType AccountType { get; }

    }

    class User : AbstractUser
    {
        private readonly AccountType accountType;

        public override AccountType AccountType
        {
            get
            {
                return accountType;
            }
        }

        public User()
        {
            this.accountType = AccountType.User;
        }

        private void ShowMessage(string updateName, string updateDescription)
        {
            Console.WriteLine($"Update: {updateName}\nWith description: {updateDescription}\n");
        }

        public void ListenUpdates (Application obj)
        {
            obj.OnUpdateRelease += ShowMessage;
        }


    }

    class Admin : AbstractUser
    {
        private readonly AccountType accountType;

        public override AccountType AccountType
        {
            get
            {
                return accountType;
            }
        }

        public Admin()
        {
            this.accountType = AccountType.Admin;
        }
    }
}
