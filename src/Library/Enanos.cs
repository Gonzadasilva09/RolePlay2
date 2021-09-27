using System;
using System.Collections;

namespace roleplay
{
    public class Dwarf : IPersonaje
    {
        public string Name{get;set;}
        public int Defense{get;set;}
        public int Hp{get;set;}
        public string Power{get;set;}
        public int Damage{get;set;}
        public bool Pocket{get; set;}
        public int HpMax{get;set;}

        public Dwarf (string name, int defense, int hpmax, string power, int damage)// Constructor para los enanos
        {
            this.Name = name;
            this.Defense = defense;
            this.Hp = hpmax;
            this.Power = power;
            this.Damage = damage;
            this.HpMax = hpmax;
            this.Pocket = false;

            Console.WriteLine("Se ha creado el Enano!");
        }

        public void AddItem(Item item)// Metodo para agregar item a los enanos
        {
            if (!Pocket)
            {
                this.Damage += item.Damage;
                this.Hp     += item.Hp;
                this.Defense+= item.Defense;
                Console.WriteLine($"Gracias a recibir el item {item.Name}, {this.Name} a aumentado sus estadisticas");
                Console.WriteLine ($"Sus estadisticas son...");
                Console.WriteLine ($"Vida = {this.Hp}");
                Console.WriteLine ($"Daño = {this.Damage}");
                Console.WriteLine ($"Defensa = {this.Defense}");
                Pocket=true;
            }
            else
            {
                Console.WriteLine("El personaje tiene un item equipado");
            }
        }
        public void RemoveItem(Item item)// Metodo para remover items de los enanos
        {
            if (Pocket)// Pocket verifica si el personaje tiene un objeto equipado o no, en case de ser falsa el bolsillo esta vacio y permite equipar un objeto, de lo contrario devolvera un mensaje diciendo que no se puede equipar un objeto 
            {
                this.Damage -= item.Damage;
                this.Hp     -= item.Hp;
                this.Defense-= item.Defense;
                Console.WriteLine($"Se le elimino el item {item.Name}, {this.Name} a perdido estadisticas");
                Console.WriteLine ($"Sus estadisticas son...");
                Console.WriteLine ($"Vida = {this.Hp}");
                Console.WriteLine ($"Daño = {this.Damage}");
                Console.WriteLine ($"Defensa = {this.Defense}");
                Pocket=false;
            }
            else
            {
                Console.WriteLine("El personaje no tiene un item equipado");
            }
        }

        public void Atack(IPersonaje personaje) // Decidimos que era mas facil hacer una clase con toda la logica del juego, esta tiene la responsabilidad de cambiar los datos de los objetos de tipo personaje basado en las acciones que toman, y colabora con ellas para saber y modificar sus valores
        {
            Console.WriteLine($"{this.Name} a realizado su ataque {this.Power}");

            if(personaje.Defense < this.Damage)
            {
                int damage = this.Damage - personaje.Defense;
                personaje.Hp = personaje.Hp - damage ;
                Console.WriteLine($"{personaje.Name} a recibido {damage} daño...");

                if(personaje.Hp > 0){

                    Console.WriteLine($"{personaje.Name} tiene {personaje.Hp} vida restante");
                }else{
                    Console.WriteLine($"{personaje.Name} a muerto a mano de {this.Name}");
                }
            }
            else
            {
            Console.WriteLine($"{personaje.Name} no a recibido daño ...");
            }
        }
    }
}