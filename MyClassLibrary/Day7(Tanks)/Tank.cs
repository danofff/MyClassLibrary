using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public enum TankName { T34, Pantera }

    public class Tank
    {

        /*
         * ПОМНИМ избыточное обращение с испольованием this не нужно. 
         * this применяется только тогда когда у вас присутствуют одинаковыеимена, или же 
         * вам необходимо использовать именно это свойство, в этом классе, т.к. такое же есть в базовом классе
         */
        public TankName Name { get; private set; }
        public int Armor { get; private set; }
        public int Amunition { get; private set; }
        public int Mobility { get; private set; }

        private static Random rnd = new Random();

        public Tank() : this(TankName.T34)
        {
            this.Name = (TankName)rnd.Next(0, 2);
        }

        public Tank(TankName name) : this(name, 0, 0, 0) { }

        public Tank(TankName name, int armor, int amunition, int mobility)
        {
            this.Armor = rnd.Next(0, 101);
            this.Amunition = rnd.Next(0, 101);
            this.Mobility = rnd.Next(0, 101);

            if (armor > 0 && armor <= 100)
                this.Armor = armor;
            else
                this.Armor = rnd.Next(0, 101);

            if (amunition > 0 && amunition <= 100)
                this.Amunition = amunition;
            else
                this.Amunition = rnd.Next(0, 101);

            if (mobility > 0 && mobility <= 100)
                this.Mobility = mobility;
            else
                this.Mobility = rnd.Next(0, 101);

            this.Name = name;
        }

        /// <summary>
        /// Метод вывода информации о Танке
        /// </summary>
        public void PrintInfo()
        {
            Console.ForegroundColor = Name == TankName.T34 ? ConsoleColor.Green : ConsoleColor.Red;

            Console.WriteLine("--------------------");
            Console.WriteLine("MODEL: {0}", Name);
            Console.WriteLine("ARMOR: {0}", Armor);
            Console.WriteLine("AMUNITION: {0}", Amunition);
            Console.WriteLine("MOBILITY: {0}", Mobility);
            Console.WriteLine("--------------------");

            Console.ResetColor();
        }

        /// <summary>
        /// АДСКАЯ Перегрузка оператора
        /// </summary>
        /// <param name="tank1">Танк 1</param>
        /// <param name="tank2">Танк 2</param>
        /// <returns></returns>
        public static int operator ^(Tank tank1, Tank tank2)
        {
            //условие когда все три показателя равны
            if (tank1.Amunition == tank2.Amunition && tank1.Mobility == tank2.Mobility && tank1.Armor == tank2.Armor)
            {
                return 0;
            }
            else
            {
                //условия когда два показателя из трех равны
                if (tank1.Amunition == tank2.Amunition && tank1.Armor == tank2.Armor)
                {
                    return (tank1.Mobility > tank2.Mobility) ? 1 : 2;
                }
                if (tank1.Amunition == tank2.Amunition && tank1.Mobility == tank2.Mobility)
                {
                    return (tank1.Armor > tank2.Armor) ? 1 : 2;
                }
                if (tank1.Mobility == tank2.Mobility && tank1.Armor == tank2.Armor)
                {
                    return (tank1.Amunition > tank2.Amunition) ? 1 : 2;
                }
                //условия, когда один показатель из трех равен
                if (tank1.Armor == tank2.Armor)
                {
                    if (tank1.Amunition > tank2.Amunition && tank1.Mobility > tank2.Mobility)
                    {
                        return 1;
                    }
                    if (tank1.Amunition < tank2.Amunition && tank1.Mobility < tank2.Mobility)
                    {
                        return 2;
                    }
                    if (tank1.Amunition > tank2.Amunition && tank1.Mobility < tank2.Mobility)
                    {
                        return (tank1.Amunition - tank2.Amunition > tank2.Mobility - tank1.Mobility) ? 1 : 2;
                    }
                    if (tank1.Amunition < tank2.Amunition && tank1.Mobility > tank2.Mobility)
                    {
                        return (tank2.Amunition - tank1.Amunition > tank1.Mobility - tank2.Mobility) ? 1 : 2;
                    }

                }
                if (tank1.Amunition == tank2.Amunition)
                {
                    if (tank1.Armor > tank2.Armor && tank1.Mobility > tank2.Mobility)
                    {
                        return 1;
                    }
                    if (tank1.Amunition < tank2.Amunition && tank1.Mobility < tank2.Mobility)
                    {
                        return 2;
                    }
                    if (tank1.Armor > tank2.Armor && tank1.Mobility < tank2.Mobility)
                    {
                        return (tank1.Armor - tank2.Armor > tank2.Mobility - tank1.Mobility) ? 1 : 2;
                    }
                    if (tank1.Armor < tank2.Armor && tank1.Mobility > tank2.Mobility)
                    {
                        return (tank2.Armor - tank1.Armor > tank1.Mobility - tank2.Mobility) ? 1 : 2;
                    }
                }
                if (tank1.Mobility == tank2.Mobility)
                {
                    if (tank1.Armor > tank2.Armor && tank1.Amunition > tank2.Amunition)
                    {
                        return 1;
                    }
                    if (tank1.Amunition < tank2.Amunition && tank1.Armor < tank2.Armor)
                    {
                        return 2;
                    }
                    if (tank1.Armor > tank2.Armor && tank1.Amunition < tank2.Amunition)
                    {
                        return (tank1.Armor - tank2.Armor > tank2.Amunition - tank1.Amunition) ? 1 : 2;
                    }
                    if (tank1.Armor < tank2.Armor && tank1.Amunition > tank2.Amunition)
                    {
                        return (tank2.Armor - tank1.Armor > tank1.Amunition - tank2.Amunition) ? 1 : 2;
                    }
                }
                //условия, когда все показатели отличны
                if (tank1.Mobility > tank2.Mobility && tank1.Armor > tank2.Armor ||
                    tank1.Mobility > tank2.Mobility && tank1.Amunition > tank2.Amunition ||
                    tank1.Armor > tank2.Armor && tank1.Amunition > tank2.Amunition)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }
    }
}
