using System;

namespace HaircutTemplateMethod
{
    public abstract class Haircut
    {
        public void TemplateMethod()
        {
            PrepareHair();
            CutHair();
            FinalizeHaircut();
        }

        private void PrepareHair()
        {
            Console.WriteLine("Шаг 1: Моем и расчесываем волосы.");
        }

        private void FinalizeHaircut()
        {
            Console.WriteLine("Шаг 3: Завершаем стрижку — укладка и обрезка деталей.");
        }

        public abstract void CutHair(); // Этот шаг будет изменяться в подклассах
    }

    public class ShortHaircut : Haircut
    {
        public override void CutHair()
        {
            Console.WriteLine("Шаг 2: Стрижка коротких волос с помощью машинки.");
        }
    }

    public class LongHaircut : Haircut
    {
        public override void CutHair()
        {
            Console.WriteLine("Шаг 2: Стрижка длинных волос ножницами.");
        }
    }

    public class CurlyHaircut : Haircut
    {
        public override void CutHair()
        {
            Console.WriteLine("Шаг 2: Стрижка вьющихся волос с учетом текстуры.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Стрижка коротких волос:");
            Haircut shortHaircut = new ShortHaircut();
            shortHaircut.TemplateMethod();

            Console.WriteLine("\nСтрижка длинных волос:");
            Haircut longHaircut = new LongHaircut();
            longHaircut.TemplateMethod();

            Console.WriteLine("\nСтрижка вьющихся волос:");
            Haircut curlyHaircut = new CurlyHaircut();
            curlyHaircut.TemplateMethod();
        }
    }
}