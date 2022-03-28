using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        class transport
        {
           
            internal enum ТипType
            {
                Наземный,
                Подземный
            }
            internal enum КомфортType
            {
                Комфорт,
                VIP
            }

            public int Размер { get; set; }
            public int Экипаж { get; set; }
            public int Скорость { get; set; }

            
        }

        class camel : transport
           {
            public int Порода { get; set; }
            public int Колличество_горбов { get; set; }
            public int Выносливость { get; set; }
        }

        class train : transport
        { 
            public ТипType Тип { get; set; }
            public int Мощность{ get; set; }
            public КомфортType Комфорт { get; set; } 
        }
        class plane : transport
        {
            public string Вид_крыла { get; set; } 
            public string Назначение { get; set; }
            public int Дальность_полета { get; set; }
        }
        class sailboat : transport
        {
            public int Запас_топлива { get; set; }
            public int Колличество_парусов { get; set; }
            public int Дедвейт { get; set; }
        }
        
    }

}
