using System;
using System.Collections.Generic;

namespace Tasks7
{
    class Program
    {
        static void Main()
        {
			// Создали список
			List<Skeleton> listOfSkelet = new List<Skeleton> ();

			Console.WriteLine($"How many skeleton you want to kill today?");
			int x = int.Parse(Console.ReadLine());

			// Добавили			
			for(int i = 0; i < x; i++)
            {
				listOfSkelet.Add(new Skeleton());
            }
			// Подписали
			for(int i = 0; i < listOfSkelet.Count; i++)
            {
				listOfSkelet[i].OnDeath += Beholder.AddListener;
            }
			// Убили
			for(int i = 0; i < listOfSkelet.Count; i++)
            {
				listOfSkelet[i].Kill();
            }

			Console.ReadKey();
        }

	}


	/*
	♦ Наблюдатель

	Создать класс Скелет
	• Создать статическое целочисленное поле lastID
	• Создать поле id
	• Создать событие OnDeath, реализовать через делегат Action<int>
	• Создать конструктор по умолчанию, которые присваивает полю id уникальное значение (в качестве счетчика использовать статическое поле lastID)
	• Создать метод Kill, который убивает скелета и вызывает событие OnDeath (в качесиве параметра передавать id скелета)

	Создать статический класс Наблюдатель
	• Создать в нём статический метод void AddListener(int) который выводит принимаемое число

	Объявить List с произвольным количеством скелетов
	Подписаться классом Наблюдатель на события всех скелетов из списка
	Вызвать метод Kill у всех скелетов
	*/


	class Skeleton
    {
		public static int lastID;

		public int id;

		public event Action<int> OnDeath;

		public Skeleton()
        {
			this.id = lastID++;
        }

		public void Kill()
        {
			OnDeath?.Invoke(this.id);
        }
		

    }


	static class Beholder
    {
		public static void AddListener(int id)
        {
			Console.WriteLine($"You killed poor skeleton with ID number {id} ");
        }

	}




}
