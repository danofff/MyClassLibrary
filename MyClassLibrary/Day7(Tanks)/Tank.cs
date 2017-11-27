using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public enum tankName { T_34, Pantera}
    public class Tank
    {
        private tankName name;
        public tankName Name
        {
            get { return name; }
        }
        private int armor;
        public int Armor
        {
            get { return armor; }
        }

        private int amunition;
        public int Amunition
        {
            get { return amunition; }
        }
        private int mobility;
        public int Mobility
        {
            get { return mobility; }
        }
        public static Random rnd = new Random();
        public Tank()
        {
            this.name = (tankName)rnd.Next(0, 2);
            this.armor = rnd.Next(0, 101);
            this.amunition = rnd.Next(0, 101);
            this.mobility = rnd.Next(0, 101);
        }
        public Tank(tankName name)
        {
            this.name = name;
            this.armor = rnd.Next(0, 101);
            this.amunition = rnd.Next(0, 101);
            this.mobility = rnd.Next(0, 101);
        }
        public Tank(tankName name,int armor, int amunition,int mobility)
        {
            if (armor > 0 && armor <= 100)
                this.armor = armor;
            else
                this.armor = rnd.Next(0, 101);

            if (amunition > 0 && amunition <= 100)
                this.amunition = amunition;
            else
                this.amunition = rnd.Next(0, 101);

            if (mobility > 0 && mobility <= 100)
                this.mobility = mobility;
            else
                this.mobility = rnd.Next(0, 101);

            this.name = name;
        }
        public void printInfo()
        {
            if (this.Name == tankName.T_34)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--------------------");
            Console.WriteLine($"MODEL: {this.Name}");
            Console.WriteLine($"ARMOR: {this.Armor}");
            Console.WriteLine($"AMUNITION: {this.Amunition}");
            Console.WriteLine($"MOBILITY: {this.Mobility}");
            Console.WriteLine("--------------------");
            Console.ResetColor();
        }
        public static int operator ^(Tank tank1,Tank tank2)
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
                        return (tank1.Amunition-tank2.Amunition>tank2.Mobility-tank1.Mobility)?1:2;
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
