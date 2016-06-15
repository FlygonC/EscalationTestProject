using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalationTestProject
{
    class Entity
    {
        public enum EntityType : ushort { HealthPickup = 0, Chest, Trap, Troll, Imp, Ogre, }


        public ushort id;
        public EntityType type;
        public Vector2 position = new Vector2();
        public Vector2 forwardNormal = new Vector2();

        public float CollisionRadius
        {
            get
            {
                switch (type)
                {
                    case EntityType.HealthPickup:
                        return 10;
                    case EntityType.Chest:
                        return 20;
                    case EntityType.Trap:
                        return 64;
                    case EntityType.Troll:
                        return 12;
                    case EntityType.Imp:
                        return 10;
                    case EntityType.Ogre:
                        return 25;

                    default:
                        return 0;
                }
            }
        }

        public float FieldOfView
        {
            get
            {
                switch (type)
                {
                    case EntityType.Troll:
                        return 45;
                    case EntityType.Imp:
                        return 65;
                    case EntityType.Ogre:
                        return 90;

                    default:
                        return 0;
                }
            }
        }


        public bool TestCollision(Entity _other)
        {
            Vector2 difference = _other.position - position;

            float distance = difference.Magnitude;

            if (distance <= CollisionRadius + _other.CollisionRadius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Entity[] TestCollision( Entity[] _others)
        {
            List<Entity> hits = new List<Entity>();

            foreach (Entity i in _others)
            {
                if (i == this)
                {
                    continue;
                }
                if (TestCollision(i))
                {
                    hits.Add(i);
                }
            }

            return hits.ToArray();
        }

        public bool TestView( Entity _other )
        {
            
            return Vector2.DotPoduct(new Vector2(position - _other.position).Normal, forwardNormal) >= Math.Cos((FieldOfView * Vector2.DegToRad) / 2);
            
        }
        public Entity[] TestView(Entity[] _others)
        {
            List<Entity> hits = new List<Entity>();

            foreach (Entity i in _others)
            {
                if (i == this)
                {
                    continue;
                }
                if (TestView(i))
                {
                    hits.Add(i);
                }
            }

            return hits.ToArray();
        }




        public void Write(bool _printForward)
        {
            Console.WriteLine("Entity ID: " + id + " Type: " + type);
            Console.WriteLine("\tPosition: " + position.x + ", " + position.y);

            if (_printForward)
                Console.WriteLine("\tForward: " + forwardNormal.x + ", " + forwardNormal.y);
        }
    }
}
