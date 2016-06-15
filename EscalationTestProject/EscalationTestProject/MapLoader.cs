using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EscalationTestProject
{
    class MapLoader
    {

        public Entity[] entities;

        // "../../res/EscalationProgrammerTest.bin"
        public void Load(string _path)
        {
            byte[] fileBytes = File.ReadAllBytes(_path);

            byte[] numberOfEntitiesBytes = ByteSlicer(fileBytes, 0, 4);
            uint numberOfEntities = (uint)BitConverter.ToInt32(numberOfEntitiesBytes, 0);

            entities = new Entity[numberOfEntities];

            for (uint i = 0; i < numberOfEntities; i++)
            {
                // Get Entity Data
                byte[] entityData = new byte[32];
                entityData = ByteSlicer(fileBytes, (Int32)(4 + (32 * i)), 32);

                entities[i] = ReadEntity(entityData);
            }

            //WriteEntities();
        }

        Entity ReadEntity(byte[] _entityData)
        {
            Entity returnEntity = new Entity();
            // ID
            byte[] idBytes = ByteSlicer(_entityData, 0, 2);
            // Type
            byte[] typeBytes = ByteSlicer(_entityData, 2, 2);
            // PosX
            byte[] posXBytes = ByteSlicer(_entityData, 4, 4);
            // PosY
            byte[] posYBytes = ByteSlicer(_entityData, 8, 4);
            // ForNX
            byte[] ForNXBytes = ByteSlicer(_entityData, 12, 4);
            // ForNY
            byte[] ForNYBytes = ByteSlicer(_entityData, 16, 4);

            returnEntity.id = (ushort)BitConverter.ToInt16(idBytes, 0);
            returnEntity.type = (Entity.EntityType)BitConverter.ToInt16(typeBytes, 0);
            returnEntity.position.x = (float)BitConverter.ToSingle(posXBytes, 0);
            returnEntity.position.y = (float)BitConverter.ToSingle(posYBytes, 0);
            returnEntity.forwardNormal.x = (float)BitConverter.ToSingle(ForNXBytes, 0);
            returnEntity.forwardNormal.y = (float)BitConverter.ToSingle(ForNYBytes, 0);
            
            return returnEntity;
        }

        void WriteEntities()
        {
            foreach (Entity i in entities)
            {
                i.Write(false);
            }
        }

        public byte[] ByteSlicer(byte[] _data, Int32 _start, Int32 _length)
        {
            byte[] retBytes = new byte[_length];

            for (uint i = 0; i < _length; i++)
            {
                retBytes[i] = _data[_start + i];
            }

            return retBytes;
        }
    }
}
